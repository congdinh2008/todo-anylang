# Define a route for the API
from flask import request, jsonify

from api import api
from api import db
from api.models import Category, Todo

# Using flask_restx to define the API
from flask_restx import Resource
from api.view_models.category_view_model import category_model

ns = api.namespace('categories', description='CATEGORY operations')

# Define the routes for the API
@ns.route('/api/v1/categories')
class Categories(Resource):
    @ns.doc('list_categories')
    def get(self):
        categories = Category.query.all()
        return jsonify([category.serialize() for category in categories])

    @ns.doc('create_category')
    @ns.expect(category_model)
    def post(self):
        data = request.get_json()
        category = Category(name=data['name'])
        db.session.add(category)
        db.session.commit()
        return jsonify(category.serialize())
    
@ns.route('/api/v1/categories/<id>')
class CategoryById(Resource):
    @ns.doc('get_category')
    def get(self, id):
        category = Category.query.get(id)
        return jsonify(category.serialize())

    @ns.doc('update_category')
    @ns.expect(category_model)
    def put(self, id):
        data = request.get_json()
        category = Category.query.get(id)
        category.name = data['name']
        db.session.commit()
        return jsonify(category.serialize())

    @ns.doc('delete_category')
    def delete(self, id):
        category = Category.query.get(id)
        category.isDeleted = True
        return jsonify(category.serialize())

# Define a route for the API
from flask import request, jsonify

from api import api
from api import db
from api.models import Todo

# Using flask_restx to define the API
from flask_restx import Resource
from api.view_models.todo_view_model import todo_model

ns = api.namespace('todos', description='TODO operations')

# Define the routes for the API
@ns.route('/api/v1/todos')
class Todos(Resource):
    @ns.doc('list_todos')
    def get(self):
        todos = Todo.query.all()
        return jsonify([todo.serialize() for todo in todos])

    @ns.doc('create_todo')
    @ns.expect(todo_model)
    def post(self):
        data = request.get_json()
        todo = Todo(title=data['title'], categoryId=data['categoryId'])
        db.session.add(todo)
        db.session.commit()
        return jsonify(todo.serialize())
    
@ns.route('/api/v1/todos/<id>')
class TodoById(Resource):
    @ns.doc('get_todo')
    def get(self, id):
        todo = Todo.query.get(id)
        return jsonify(todo.serialize())

    @ns.doc('update_todo')
    @ns.expect(todo_model)
    def put(self, id):
        data = request.get_json()
        todo = Todo.query.get(id)
        todo.title = data['title']
        todo.isCompleted = data['isCompleted']
        todo.categoryId = data['categoryId']
        db.session.commit()
        return jsonify(todo.serialize())

    @ns.doc('delete_todo')
    def delete(self, id):
        todo = Todo.query.get(id)
        todo.isDeleted = True
        return jsonify(todo.serialize())
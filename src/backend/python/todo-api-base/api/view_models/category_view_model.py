# Define todo view model to create or update

from api import api
from flask_restx import fields

category_model = api.model('Category', {
    'name': fields.String(required=True, description='The name of the category'),
})
# Define todo view model to create or update

from api import api
from flask_restx import fields

todo_model = api.model('Todo', {
    'title': fields.String(required=True, description='The title of the todo'),
    'isCompleted': fields.Boolean(required=True, description='The completion status of the todo'),
    'categoryId': fields.String(required=True, description='The category id of the todo'),
})
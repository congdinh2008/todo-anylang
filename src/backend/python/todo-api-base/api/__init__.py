# Define init api
import urllib
from flask import Flask
from flask_restx import Api
from flask_sqlalchemy import SQLAlchemy

app = Flask(__name__)

api = Api(app, version='1.0', title='Todo API', description='A simple Todo API')

# SQL Server configurations
database_password = urllib.parse.quote_plus('abcd@1234')
app.config['SQLALCHEMY_DATABASE_URI'] = f'mssql+pyodbc://sa:{database_password}@localhost:1433/todopythonapibase?driver=ODBC+Driver+18+for+SQL+Server&TrustServerCertificate=yes'
db = SQLAlchemy(app)

# Create the database tables categories and todos if they do not exist
with app.app_context():
    from api.models import Category, Todo
    db.create_all()


from api.controllers import category_controller
from api.controllers import todo_controller

if __name__ == '__main__':
    app.run(debug=True)
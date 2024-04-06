from sqlalchemy import text
import uuid
from sqlalchemy.dialects.mssql import UNIQUEIDENTIFIER as UUID
from api import db

class EntityBase(db.Model):
    __abstract__ = True
    id = db.Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4, unique=True, nullable=False, server_default=text("(newid())"))
    insertedAt = db.Column(db.DateTime, default=db.func.current_timestamp())
    updatedAt = db.Column(db.DateTime, default=db.func.current_timestamp(),
                           onupdate=db.func.current_timestamp())
    isDeleted = db.Column(db.Boolean, default=False)

# Configure one to many relationship between Category and Todo
class Category(EntityBase):
    __tablename__ = 'categories'
    name = db.Column(db.String(50), nullable=False)
    todos = db.relationship('Todo', backref='category', lazy=True)

    def __repr__(self):
        return f'<Category {self.name}>'
    
    def serialize(self, include_todos=True):
        data = {
            'id': self.id,
            'name': self.name,
        }
        if include_todos:
            data['todos'] = [todo.serialize(include_category=False) for todo in self.todos]
        return data
    
# Configure one to many relationship between Category and Todo
class Todo(EntityBase):
    __tablename__ = 'todos'
    title = db.Column(db.String(50), nullable=False)
    isCompleted = db.Column(db.Boolean, default=False)
    categoryId = db.Column(UUID(as_uuid=True), db.ForeignKey('categories.id'), nullable=False)

    def __repr__(self):
        return f'<Todo {self.title}>'
    
    def serialize(self, include_category=True):
        data = {
            'id': self.id,
            'title': self.title,
            'isCompleted': self.isCompleted,
            'categoryId': str(self.categoryId),
        }
        if include_category:
            data['category'] = self.category.serialize(include_todos=False)
        return data
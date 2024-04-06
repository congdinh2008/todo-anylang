// Define get all, get by id, create, update and delete routes for todos
const express = require('express');
const router = express.Router();
const Todo = require('../models/todo.model');

// Get all todos
router.get('/', async (req, res) => {
  const todos = await Todo.findAll();
  res.json(todos);
});

// Get a todo by id
router.get('/:id', async (req, res) => {
  const todo = await Todo.findByPk(req.params.id);
  if (todo) {
    res.json(todo);
  } else {
    res.status(404).send('Todo not found');
  }
});

// Create a new todo
router.post('/', async (req, res) => {
  const todo = await Todo.create(req.body);
  res.status(201).json(todo);
});

// Update a todo
router.put('/:id', async (req, res) => {
  const [numUpdated] = await Todo.update(req.body, {
    where: { id: req.params.id }
  });

  if (numUpdated) {
    const updatedTodo = await Todo.findByPk(req.params.id);
    res.json(updatedTodo);
  } else {
    res.status(404).send('Todo not found');
  }
});

// Delete a todo
router.delete('/:id', async (req, res) => {
  const numDeleted = await Todo.destroy({
    where: { id: req.params.id }
  });

  if (numDeleted) {
    res.status(204).send();
  } else {
    res.status(404).send('Todo not found');
  }
});

module.exports = router;
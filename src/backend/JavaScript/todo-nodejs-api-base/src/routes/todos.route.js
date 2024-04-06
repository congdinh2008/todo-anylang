// Define get all, get by id, create, update and delete routes for todos
const express = require('express');
const router = express.Router();
const Todo = require('../models/todo.model');

/**
 * @swagger
 * tags:
 *   name: Todos
 *   description: The todos managing API
 *
 * components:
 *   schemas:
 *     Todo:
 *       type: object
 *       required:
 *         - name
 *       properties:
 *         id:
 *           type: string
 *           description: The auto-generated id of the todo
 *         name:
 *           type: string
 *           description: The name of the todo
 *         insertedAt:
 *           type: string
 *           description: The date and time the todo was created
 *         updatedAt:
 *           type: string
 *           description: The date and time the todo was last updated
 *         isDeleted:
 *           type: boolean
 *           description: The status of the todo
 *       example:
 *         id: "1112c435-b91c-47dc-903a-8037033b8682"
 *         name: Todo 1
 *         insertedAt: 2021-01-01T00:00:00.000Z
 *         updatedAt: 2021-01-01T00:00:00.000Z
 *         isDeleted: false
 *
 * /todos:
 *   get:
 *     summary: Returns the list of all the todos
 *     tags: [Todos]
 *     responses:
 *       200:
 *         description: The list of the todos
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Todo'
 *
 *   post:
 *     summary: Create a new todo
 *     tags: [Todos]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Todo'
 *     responses:
 *       200:
 *         description: The todo was successfully created
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Todo'
 *
 * /todos/{id}:
 *   get:
 *     summary: Get the todo by id
 *     tags: [Todos]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: string
 *         required: true
 *         description: The todo id
 *     responses:
 *       200:
 *         description: The todo
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Todo'
 *
 *   put:
 *     summary: Update the todo by the id
 *     tags: [Todos]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *            type: string
 *         required: true
 *         description: The todo id
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Todo'
 *     responses:
 *       200:
 *         description: The todo was updated
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Todo'
 *
 *   delete:
 *      summary: Remove the todo by id
 *      tags: [Todos]
 *      parameters:
 *        - in: path
 *          name: id
 *          schema:
 *            type: string
 *          required: true
 *          description: The todo id
 *      responses:
 *        204:
 *          description: The todo was deleted
 *        404:
 *          description: The todo was not found
 *      
 */
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
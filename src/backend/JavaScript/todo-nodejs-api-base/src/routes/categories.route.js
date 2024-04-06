// Define get all, get by id, create, update and delete routes for categories
const express = require('express');
const router = express.Router();
const Category = require('../models/category.model'); // Import your Category model

// Get all categories
router.get('/', async (req, res) => {
  const categories = await Category.findAll();
  res.json(categories);
});

// Get a category by id
router.get('/:id', async (req, res) => {
  const category = await Category.findByPk(req.params.id);
  if (category) {
    res.json(category);
  } else {
    res.status(404).send('Category not found');
  }
});

// Create a new category
router.post('/', async (req, res) => {
  const category = await Category.create(req.body);
  res.status(201).json(category);
});

// Update a category
router.put('/:id', async (req, res) => {
  const [numUpdated] = await Category.update(req.body, {
    where: { id: req.params.id }
  });

  if (numUpdated) {
    const updatedCategory = await Category.findByPk(req.params.id);
    res.json(updatedCategory);
  } else {
    res.status(404).send('Category not found');
  }
});

// Delete a category
router.delete('/:id', async (req, res) => {
  const numDeleted = await Category.destroy({
    where: { id: req.params.id }
  });

  if (numDeleted) {
    res.status(204).send();
  } else {
    res.status(404).send('Category not found');
  }
});

module.exports = router;
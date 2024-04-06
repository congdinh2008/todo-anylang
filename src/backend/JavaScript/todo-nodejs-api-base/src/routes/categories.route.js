// Define get all, get by id, create, update and delete routes for categories
const express = require("express");
const router = express.Router();
const Category = require("../models/category.model"); // Import your Category model

/**
 * @swagger
 * tags:
 *   name: Categories
 *   description: The categories managing API
 *
 * components:
 *   schemas:
 *     Category:
 *       type: object
 *       required:
 *         - name
 *       properties:
 *         id:
 *           type: string
 *           description: The auto-generated id of the category
 *         name:
 *           type: string
 *           description: The name of the category
 *         insertedAt:
 *           type: string
 *           description: The date and time the category was created
 *         updatedAt:
 *           type: string
 *           description: The date and time the category was last updated
 *         isDeleted:
 *           type: boolean
 *           description: The status of the category
 *       example:
 *         id: "1112c435-b91c-47dc-903a-8037033b8682"
 *         name: Category 1
 *         insertedAt: 2021-01-01T00:00:00.000Z
 *         updatedAt: 2021-01-01T00:00:00.000Z
 *         isDeleted: false
 *
 * /categories:
 *   get:
 *     summary: Returns the list of all the categories
 *     tags: [Categories]
 *     responses:
 *       200:
 *         description: The list of the categories
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Category'
 *
 *   post:
 *     summary: Create a new category
 *     tags: [Categories]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Category'
 *     responses:
 *       200:
 *         description: The category was successfully created
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Category'
 *
 * /categories/{id}:
 *   get:
 *     summary: Get the category by id
 *     tags: [Categories]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: string
 *         required: true
 *         description: The category id
 *     responses:
 *       200:
 *         description: The category
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Category'
 *
 *   put:
 *     summary: Update the category by the id
 *     tags: [Categories]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *            type: string
 *         required: true
 *         description: The category id
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Category'
 *     responses:
 *       200:
 *         description: The category was updated
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Category'
 *
 *   delete:
 *      summary: Remove the category by id
 *      tags: [Categories]
 *      parameters:
 *        - in: path
 *          name: id
 *          schema:
 *            type: string
 *          required: true
 *          description: The category id
 *      responses:
 *        204:
 *          description: The category was deleted
 *        404:
 *          description: The category was not found
 *      
 */

// Get all categories
router.get("/", async (req, res) => {
  const categories = await Category.findAll();
  res.json(categories);
});

// Get a category by id
router.get("/:id", async (req, res) => {
  const category = await Category.findByPk(req.params.id);
  if (category) {
    res.json(category);
  } else {
    res.status(404).send("Category not found");
  }
});

// Create a category
router.post("/", async (req, res) => {
  const category = await Category.create(req.body);
  res.status(201).json(category);
});

// Update a category
router.put("/:id", async (req, res) => {
  const [numUpdated] = await Category.update(req.body, {
    where: { id: req.params.id },
  });

  if (numUpdated) {
    const updatedCategory = await Category.findByPk(req.params.id);
    res.json(updatedCategory);
  } else {
    res.status(404).send("Category not found");
  }
});

// Delete a category
router.delete("/:id", async (req, res) => {
  const numDeleted = await Category.destroy({
    where: { id: req.params.id },
  });

  if (numDeleted) {
    res.status(204).send();
  } else {
    res.status(404).send("Category not found");
  }
});

module.exports = router;

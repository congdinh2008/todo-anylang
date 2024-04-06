require('dotenv').config();

const express = require('express');
const app = express();
const port = process.env.PORT || 3000;

// Define api routes for categories, return right restful response
const categories = require('./routes/categories.route');
app.use('/categories', categories);

// Define api routes for todos, return right restful response
const todos = require('./routes/todos.route');
app.use('/todos', todos);

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`);
});
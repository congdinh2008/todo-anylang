require('dotenv').config();

const express = require('express');
const bodyParser = require('body-parser');
const swaggerJsDoc = require('swagger-jsdoc');
const swaggerUi = require('swagger-ui-express');

const app = express();
const port = process.env.PORT || 3000;

// parse application/x-www-form-urlencoded
app.use(bodyParser.urlencoded({ extended: false }));

// parse application/json
app.use(bodyParser.json());

const swaggerOptions = {
  definition: {
    openapi: '3.0.0',
    info: {
      title: 'My Express API',
      version: '1.0.0',
      description: 'A simple Express API',
    },
  },
  apis: ['./src/routes/*.js'], // files containing annotations as above
};

const swaggerDocs = swaggerJsDoc(swaggerOptions);
app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerDocs));

// Define api routes for categories, return right restful response
const categories = require('./src/routes/categories.route');
app.use('/categories', categories);

// Define api routes for todos, return right restful response
const todos = require('./src/routes/todos.route');
app.use('/todos', todos);



app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`);
});
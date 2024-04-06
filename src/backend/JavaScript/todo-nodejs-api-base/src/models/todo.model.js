const Category = require("./category.model");

const { Sequelize, DataTypes, Model } = require("sequelize");
const sequelize = new Sequelize(process.env.DATABASE_URL); // Use your database connection string


class Todo extends Model {}

Todo.init(
  {
    id: {
      type: DataTypes.UUID,
      defaultValue: DataTypes.UUIDV4,
      primaryKey: true,
    },
    title: {
      type: DataTypes.STRING,
      allowNull: false,
      validate: {
        notEmpty: true,
      },
    },
    isCompleted: {
      type: DataTypes.BOOLEAN,
      defaultValue: false,
      allowNull: false,
    },
    isDeleted: {
      type: DataTypes.BOOLEAN,
      defaultValue: false,
      allowNull: false,
    },
  },
  {
    sequelize,
    timestamps: true,
    createdAt: "insertedAt",
    modelName: "Todo",
  }
);

// Define the relationship
Category.hasMany(Todo, { foreignKey: "categoryId" });
Todo.belongsTo(Category, { foreignKey: "categoryId" });

Category.sync({ force: false }).then(() => {
  console.log("Category table created successfully");

  Todo.sync({ force: false })
    .then(() => {
      console.log("Todo table created successfully");
    })
    .catch((error) => {
      console.error("Error creating Todo table", error);
    });
});

module.exports = Todo;

const { Sequelize, DataTypes, Model } = require("sequelize");
const sequelize = new Sequelize(process.env.DATABASE_URL); // Use your database connection string

class Category extends Model {}

Category.init(
  {
    id: {
      type: DataTypes.UUID,
      defaultValue: DataTypes.UUIDV4,
      primaryKey: true,
    },
    name: {
      type: DataTypes.STRING,
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
    modelName: "Category",
  }
);

module.exports = Category;

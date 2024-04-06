package controllers

import (
	"net/http"

	"congdinh.com/todo-go-api-base/models"
	"congdinh.com/todo-go-api-base/startup"
	"github.com/gin-gonic/gin"
	"github.com/google/uuid"
)

func GetCategories(c *gin.Context) {
	var categories []models.Category
	startup.DB.Find(&categories)

	c.JSON(http.StatusOK, gin.H{
		"message":    "Get Categories",
		"categories": categories,
	})
}

func CreateCategory(c *gin.Context) {
	var category models.Category
	c.BindJSON(&category)
	id := startup.DB.Create(&category)

	if id.Error != nil {
		c.JSON(http.StatusBadRequest, gin.H{
			"message": id.Error.Error(),
		})
		return
	}

	// Return created category
	startup.DB.First(&category, id)

	c.JSON(http.StatusOK, gin.H{
		"message":  "Create Category",
		"category": category,
	})
}

func GetCategory(c *gin.Context) {
	var category models.Category
	id := c.Param("id")
	startup.DB.First(&category, id)

	// Check if category not found
	if category.Id == uuid.Nil {
		c.JSON(http.StatusNotFound, gin.H{
			"message": "Category not found",
		})
		return
	}

	c.JSON(http.StatusOK, gin.H{
		"message":  "Get Category",
		"category": category,
	})
}

func UpdateCategory(c *gin.Context) {
	var category models.Category

	id := c.Param("id")

	startup.DB.First(&category, id)

	// Check if category not found
	if category.Id == uuid.Nil {
		c.JSON(http.StatusNotFound, gin.H{
			"message": "Category not found",
		})
		return
	}

	c.BindJSON(&category)

	startup.DB.Save(&category)

	c.JSON(http.StatusOK, gin.H{
		"message":  "Update Category",
		"category": category,
	})
}

func DeleteCategory(c *gin.Context) {
	var category models.Category

	id := c.Param("id")

	startup.DB.First(&category, id)

	// Check if category not found

	if category.Id == uuid.Nil {
		c.JSON(http.StatusNotFound, gin.H{
			"message": "Category not found",
		})
		return
	}

	startup.DB.Delete(&category)

	c.JSON(http.StatusOK, gin.H{
		"message": "Delete Category",
	})
}

package controllers

import (
	"net/http"

	"github.com/gin-gonic/gin"
)

func GetCategories(c *gin.Context) {
	categories := []string{"Category 1", "Category 2", "Category 3"}

	c.JSON(http.StatusOK, gin.H{
		"message":    "Get Categories",
		"categories": categories,
	})
}

func CreateCategory(c *gin.Context) {
	c.JSON(http.StatusOK, gin.H{
		"message": "Create Category",
	})
}

func GetCategory(c *gin.Context) {
	c.JSON(http.StatusOK, gin.H{
		"message": "Get Category",
	})
}

func UpdateCategory(c *gin.Context) {
	c.JSON(http.StatusOK, gin.H{
		"message": "Update Category",
	})
}

func DeleteCategory(c *gin.Context) {
	c.JSON(http.StatusOK, gin.H{
		"message": "Delete Category",
	})
}

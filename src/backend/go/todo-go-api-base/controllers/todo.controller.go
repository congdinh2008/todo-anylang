package controllers

import (
	"net/http"

	"github.com/gin-gonic/gin"
)

func GetTodos(c *gin.Context) {
	c.JSON(http.StatusOK, gin.H{
		"message": "Get Categories",
	})
}

func CreateTodo(c *gin.Context) {
	c.JSON(http.StatusOK, gin.H{
		"message": "Create Category",
	})
}

func GetTodo(c *gin.Context) {
	c.JSON(http.StatusOK, gin.H{
		"message": "Get Category",
	})
}

func UpdateTodo(c *gin.Context) {
	c.JSON(http.StatusOK, gin.H{
		"message": "Update Category",
	})
}

func DeleteTodo(c *gin.Context) {
	c.JSON(http.StatusOK, gin.H{
		"message": "Delete Category",
	})
}

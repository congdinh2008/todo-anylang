package controllers

import (
	"net/http"

	"congdinh.com/todo-go-api-base/models"
	"congdinh.com/todo-go-api-base/startup"
	"github.com/gin-gonic/gin"
	"github.com/google/uuid"
)

func GetTodos(c *gin.Context) {
	var todos []models.Todo
	startup.DB.Find(&todos)

	c.JSON(http.StatusOK, gin.H{
		"message": "Get Todos",
		"todos":   todos,
	})
}

func CreateTodo(c *gin.Context) {
	var todo models.Todo
	c.BindJSON(&todo)
	todo.Id = uuid.New()
	result := startup.DB.Create(&todo)

	if result.Error != nil {
		c.JSON(http.StatusBadRequest, gin.H{
			"message": result.Error.Error(),
		})
		return
	}

	c.JSON(http.StatusOK, gin.H{
		"message": "Create Todo",
		"todo":    todo,
	})
}

func GetTodo(c *gin.Context) {
	var todo models.Todo
	id := c.Param("id")
	startup.DB.First(&todo, id)

	// Check if todo not found
	if todo.Id == uuid.Nil {
		c.JSON(http.StatusNotFound, gin.H{
			"message": "Todo not found",
		})
		return
	}

	c.JSON(http.StatusOK, gin.H{
		"message": "Get Todo",
		"todo":    todo,
	})
}

func UpdateTodo(c *gin.Context) {
	var todo models.Todo

	id := c.Param("id")
	todo.Id, _ = uuid.Parse(id)

	startup.DB.First(&todo, id)

	// Check if todo not found
	if todo.Id == uuid.Nil {
		c.JSON(http.StatusNotFound, gin.H{
			"message": "Todo not found",
		})
		return
	}

	c.BindJSON(&todo)

	startup.DB.Save(&todo)

	c.JSON(http.StatusOK, gin.H{
		"message": "Update Todo",
		"todo":    todo,
	})
}

func DeleteTodo(c *gin.Context) {
	var todo models.Todo

	id := c.Param("id")

	startup.DB.First(&todo, id)

	// Check if todo not found

	if todo.Id == uuid.Nil {
		c.JSON(http.StatusNotFound, gin.H{
			"message": "Todo not found",
		})
		return
	}

	startup.DB.Delete(&todo)

	c.JSON(http.StatusOK, gin.H{
		"message": "Delete Todo",
	})
}

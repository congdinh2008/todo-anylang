package main

// Import routes package

import (
	"os"

	"congdinh.com/todo-go-api-base/controllers"
	"congdinh.com/todo-go-api-base/startup"
	"github.com/gin-gonic/gin"
)

func init() {
	startup.LoadEnv()

	// Connect to SQL Server database
	startup.ConnectDB()

}

func main() {
	// Set the router as the default one shipped with Gin
	router := gin.Default()

	// Define the route for the /todos endpoint
	router.GET("/todos", controllers.GetTodos)
	router.POST("/todos", controllers.CreateTodo)
	router.GET("/todos/:id", controllers.GetTodo)
	router.PUT("/todos/:id", controllers.UpdateTodo)
	router.DELETE("/todos/:id", controllers.DeleteTodo)

	// Define the route for the /categories endpoint
	router.GET("/categories", controllers.GetCategories)
	router.POST("/categories", controllers.CreateCategory)
	router.GET("/categories/:id", controllers.GetCategory)
	router.PUT("/categories/:id", controllers.UpdateCategory)
	router.DELETE("/categories/:id", controllers.DeleteCategory)

	// Start serving the application
	port := os.Getenv("PORT")
	if port == "" {
		port = "3000"
	}
	router.Run(":" + port)
}

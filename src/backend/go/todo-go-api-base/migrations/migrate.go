package main

import (
	"congdinh.com/todo-go-api-base/models"
	"congdinh.com/todo-go-api-base/startup"
)

func init() {
	// Load environment variables
	startup.LoadEnv()
	// Connect to database
	startup.ConnectDB()
}

func main() {
	// Run migrations
	startup.DB.AutoMigrate(&models.Category{}, &models.Todo{})
}

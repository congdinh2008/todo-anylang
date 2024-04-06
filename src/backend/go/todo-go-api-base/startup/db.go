package startup

import (
	"log"
	"os"

	"gorm.io/driver/sqlserver"
	"gorm.io/gorm"
)

var DB *gorm.DB

func ConnectDB() {
	var err error
	// Connect to SQL Server database
	connectionString := os.Getenv("CONNECTION_STRING")
	DB, err = gorm.Open(sqlserver.Open(connectionString), &gorm.Config{})

	if err != nil {
		log.Fatal("Failed to connect to database!")
	}
}

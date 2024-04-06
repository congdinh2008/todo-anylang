package models

import "github.com/google/uuid"

// Create a new type named Todo that is a struct with fields: Id, Title, IsCompleted, InsertedAt, UpdatedAt, IsDeleted
// Todo extends Entity

type Todo struct {
	EntityBase
	Title       string    `gorm:"column:Title"`
	IsCompleted bool      `gorm:"column:IsCompleted"`
	CategoryId  uuid.UUID `gorm:"column:CategoryId"`
	Category    Category  `gorm:"foreignKey:CategoryId"`
}

package models

import (
	"time"

	"github.com/google/uuid"
	"gorm.io/gorm"
)

// Create a new type named Entity that is a struct with fields: Id, InsertedAt, UpdatedAt, IsDeleted

type EntityBase struct {
	Id        uuid.UUID      `gorm:"type:uniqueidentifier;default:newid();column:Id;primaryKey;"`
	CreatedAt time.Time      `gorm:"column:InsertedAt"`
	UpdatedAt time.Time      `gorm:"column:UpdatedAt"`
	DeletedAt gorm.DeletedAt `gorm:"column:DeletedAt"`
	IsDeleted bool           `gorm:"column:IsDeleted"`
}

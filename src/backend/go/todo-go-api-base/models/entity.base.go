package models

import "time"

// Create a new type named Entity that is a struct with fields: Id, InsertedAt, UpdatedAt, IsDeleted

type EntityBase struct {
	Id         string    `json:"id" bson:"_id"`
	InsertedAt time.Time `json:"insertedAt" bson:"insertedAt"`
	UpdatedAt  time.Time `json:"updatedAt" bson:"updatedAt"`
	IsDeleted  bool      `json:"isDeleted" bson:"isDeleted"`
}

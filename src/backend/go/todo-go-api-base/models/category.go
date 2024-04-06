package models

// Create a new type named Category that is a struct with fields: Id, Name, InsertedAt, UpdatedAt, IsDeleted
// Category extends Entity

type Category struct {
	EntityBase
	Name string `json:"name" bson:"name"`
}

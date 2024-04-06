package models

// Create a new type named Todo that is a struct with fields: Id, Title, IsCompleted, InsertedAt, UpdatedAt, IsDeleted
// Todo extends Entity

type Todo struct {
	EntityBase
	Title       string `json:"title" bson:"title"`
	IsCompleted bool   `json:"isCompleted" bson:"isCompleted"`
}

package com.congdinh.todoapibase.models;

import java.time.LocalDateTime;
import java.util.List;
import java.util.UUID;

import org.hibernate.validator.constraints.Length;

import jakarta.persistence.Entity;
import jakarta.persistence.OneToMany;
import jakarta.validation.constraints.NotBlank;

@Entity
public class Category extends EntityBase {
    @NotBlank
    @Length(max = 100, min = 3)
    private String name;

    protected Category() {
    }

    public Category(UUID id, String name, LocalDateTime insertedAt, LocalDateTime updatedAt, Boolean isDeleted) {
        super(id, insertedAt, updatedAt, isDeleted);
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @OneToMany(mappedBy = "category")
    private List<Todo> todos;

    public List<Todo> getTodos() {
        return todos;
    }

    public void setTodos(List<Todo> todos) {
        this.todos = todos;
    }
}

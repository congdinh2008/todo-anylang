package com.congdinh.todoapibase.models;

import java.time.LocalDateTime;
import java.util.UUID;

import org.hibernate.validator.constraints.Length;

import jakarta.persistence.Entity;
import jakarta.persistence.ManyToOne;
import jakarta.validation.constraints.NotBlank;

@Entity
public class Todo extends EntityBase {
    @NotBlank
    @Length(max = 100, min = 3)
    private String name;

    private Boolean isCompleted;

    protected Todo() {
    }

    public Todo(UUID id, String name, Boolean isCompleted, LocalDateTime insertedAt, LocalDateTime updatedAt,
            Boolean isDeleted) {
        super(id, insertedAt, updatedAt, isDeleted);
        this.name = name;
        this.isCompleted = isCompleted;
    }

    public String getName() {
        return name;
    }

    public Boolean getIsCompleted() {
        return isCompleted;
    }

    public void setName(String title) {
        this.name = title;
    }

    public void setIsCompleted(Boolean isCompleted) {
        this.isCompleted = isCompleted;
    }

    @ManyToOne
    private Category category;

    public Category getCategory() {
        return category;
    }

    public void setCategory(Category category) {
        this.category = category;
    }
}

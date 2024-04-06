package com.congdinh.todoapibase.models;

import java.time.LocalDateTime;
import java.util.UUID;

import jakarta.persistence.GeneratedValue;
import jakarta.persistence.Id;
import jakarta.persistence.MappedSuperclass;
import jakarta.persistence.PrePersist;
import jakarta.persistence.PreUpdate;

@MappedSuperclass
public abstract class EntityBase {

    @Id
    @GeneratedValue
    private UUID id;

    private LocalDateTime insertedAt;
    private LocalDateTime updatedAt;

    @PrePersist
    protected void onCreate() {
        insertedAt = LocalDateTime.now();
    }
    

    @PreUpdate
    protected void onUpdate() {
        updatedAt = LocalDateTime.now();
    }

    private Boolean isDeleted = false;

    protected EntityBase() {
    }
    
    public EntityBase(UUID id, LocalDateTime insertedAt, LocalDateTime updatedAt, Boolean isDeleted) {
        this.id = id;
        this.insertedAt = insertedAt;
        this.updatedAt = updatedAt;
        this.isDeleted = isDeleted;
    }

    public Boolean isDeleted() {
        return isDeleted;
    }

    public void setDeleted(Boolean isDeleted) {
        this.isDeleted = isDeleted;
    }

    public LocalDateTime getInsertedAt() {
        return insertedAt;
    }

    public void setInsertedAt(LocalDateTime insertedAt) {
        this.insertedAt = insertedAt;
    }


    public LocalDateTime getUpdatedAt() {
        return updatedAt;
    }

    public void setUpdatedAt(LocalDateTime updatedAt) {
        this.updatedAt = updatedAt;
    }

    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
        this.id = id;
    }
}

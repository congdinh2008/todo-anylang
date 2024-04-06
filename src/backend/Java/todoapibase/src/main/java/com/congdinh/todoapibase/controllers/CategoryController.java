package com.congdinh.todoapibase.controllers;

import java.util.List;
import java.util.UUID;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;

import com.congdinh.todoapibase.models.Category;
import com.congdinh.todoapibase.services.ICategoryService;

import io.swagger.v3.oas.annotations.Operation;

import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.GetMapping;

@RestController
@RequestMapping("/api/v1/categories")
public class CategoryController {

    @Autowired
    private ICategoryService _categoryService;

    @GetMapping
    @Operation(summary = "Get all categories")
    public ResponseEntity<List<Category>> findAll() {
        var categories = _categoryService.findAll();
        return ResponseEntity.ok(categories);
    }

    @GetMapping("/{id}")
    @Operation(summary = "Get a category by id")
    public ResponseEntity<Category> findById(@PathVariable UUID id) {
        var category = _categoryService.findById(id);
        return ResponseEntity.ok(category);
    }

    @PostMapping
    @Operation(summary = "Create a new category")
    public ResponseEntity<Category> create(@RequestBody Category category) {
        var newCategory = _categoryService.save(category);
        return ResponseEntity.ok(newCategory);
    }

    @PutMapping("/{id}")
    @Operation(summary = "Update a category")
    public ResponseEntity<Category> update(@PathVariable UUID id, @RequestBody Category category) {
        category.setId(id);
        var updatedCategory = _categoryService.update(category.getId(), category);
        return ResponseEntity.ok(updatedCategory);
    }

    @DeleteMapping("/{id}")
    @Operation(summary = "Delete a category")
    public ResponseEntity<Void> delete(@PathVariable UUID id) {
        _categoryService.deleteById(id);
        return ResponseEntity.noContent().build();
    }
}

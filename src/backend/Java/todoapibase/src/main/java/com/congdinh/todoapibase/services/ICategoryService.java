package com.congdinh.todoapibase.services;

import java.util.List;

import java.util.UUID;
import org.springframework.stereotype.Service;

import com.congdinh.todoapibase.models.Category;

@Service
public interface ICategoryService {
    // generate CRUD methods, and search by keyword and pagination, ordering
    // Set default value for page = 0, size = 10, sort = "id,asc"
    List<Category> findAll();

    Category findById(UUID id);
    
    Category save(Category category);
    
    Category update(UUID id, Category category);
    
    void deleteById(UUID id);
    
    List<Category> search(String keyword, int page, int size, String[] sort);
}

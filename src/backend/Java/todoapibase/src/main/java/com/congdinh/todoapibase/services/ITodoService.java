package com.congdinh.todoapibase.services;

import java.util.List;

import java.util.UUID;
import org.springframework.stereotype.Service;

import com.congdinh.todoapibase.models.Todo;

@Service
public interface ITodoService {
    // generate CRUD methods, and search by keyword and pagination, ordering
    // Set default value for page = 0, size = 10, sort = "id,asc"
    List<Todo> findAll();

    Todo findById(UUID id);
    
    Todo save(Todo todo);
    
    Todo update(UUID id, Todo todo);
    
    void deleteById(UUID id);
    
    List<Todo> search(String keyword, int page, int size, String[] sort);
}

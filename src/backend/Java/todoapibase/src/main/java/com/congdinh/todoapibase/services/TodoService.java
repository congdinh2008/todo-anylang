package com.congdinh.todoapibase.services;

import java.util.List;

import java.util.UUID;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.congdinh.todoapibase.models.Todo;
import com.congdinh.todoapibase.repositories.ITodoRepository;

@Service
public class TodoService implements ITodoService {

    @Autowired
    private ITodoRepository _todoRepository;
    
    @Override
    public List<Todo> findAll() {
        var todos = _todoRepository.findAll();
        return todos;
    }

    @Override
    public Todo findById(UUID id) {
        return _todoRepository.findById(id).orElse(null);
    }

    @Override
    public Todo save(Todo todo) {
        return _todoRepository.save(todo);
    }

    @Override
    public Todo update(UUID id, Todo todo) {
        return _todoRepository.save(todo);
    }

    @Override
    public void deleteById(UUID id) {
        _todoRepository.deleteById(id);
    }

    @Override
    public List<Todo> search(String keyword, int page, int size, String[] sort) {

        return _todoRepository.findAll();
    }

}

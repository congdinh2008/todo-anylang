package com.congdinh.todoapibase.controllers;

import java.util.List;
import java.util.UUID;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;

import com.congdinh.todoapibase.models.Todo;
import com.congdinh.todoapibase.services.ITodoService;

import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.GetMapping;

@RestController
@RequestMapping("/api/v1/todos")
public class TodoController {

    @Autowired
    private ITodoService _todoService;

    @GetMapping
    public ResponseEntity<List<Todo>> findAll() {
        var todos = _todoService.findAll();
        return ResponseEntity.ok(todos);
    }

    @PostMapping
    public ResponseEntity<Todo> create(@RequestBody Todo todo) {
        var newTodo = _todoService.save(todo);
        return ResponseEntity.ok(newTodo);
    }

    @PutMapping("/{id}")
    public ResponseEntity<Todo> update(@PathVariable UUID id, @RequestBody Todo todo) {
        todo.setId(id);
        var updatedTodo = _todoService.update(todo.getId(), todo);
        return ResponseEntity.ok(updatedTodo);
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> delete(@PathVariable UUID id) {
        _todoService.deleteById(id);
        return ResponseEntity.noContent().build();
    }
}

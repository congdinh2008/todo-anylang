package com.congdinh.todoapibase.services;

import java.util.List;

import java.util.UUID;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.congdinh.todoapibase.models.Category;
import com.congdinh.todoapibase.repositories.ICategoryRepository;

@Service
public class CategoryService implements ICategoryService {

    @Autowired
    private ICategoryRepository _categoryRepository;
    
    @Override
    public List<Category> findAll() {
        var categories = _categoryRepository.findAll();
        return categories;
    }

    @Override
    public Category findById(UUID id) {
        return _categoryRepository.findById(id).orElse(null);
    }

    @Override
    public Category save(Category category) {
        return _categoryRepository.save(category);
    }

    @Override
    public Category update(UUID id, Category category) {
        return _categoryRepository.save(category);
    }

    @Override
    public void deleteById(UUID id) {
        _categoryRepository.deleteById(id);
    }

    @Override
    public List<Category> search(String keyword, int page, int size, String[] sort) {

        return _categoryRepository.findAll();
    }

}

package com.congdinh.todoapibase.repositories;

import java.util.UUID;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.congdinh.todoapibase.models.Category;

@Repository
public interface ICategoryRepository extends JpaRepository<Category, UUID> {

}

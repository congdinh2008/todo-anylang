<?php
require_once 'curl_helper.php';
$restAPIBaseURL = "http://localhost/rest-api";

try {
    // Get all categories
    $categories = sendRequest($restAPIBaseURL . "/api.php/categories", "GET");
    $categories = json_decode($categories, true);

    // Get single category
    $categoryId = 1;
    $category = sendRequest($restAPIBaseURL . "/api.php/categories/$categoryId", "GET");
    $category = json_decode($category, true);

    // Create category
    $data = [
        'name' => 'Category 1',
        'isDeleted' => 0,
    ];
    $result = sendRequest($restAPIBaseURL . '/api.php/categories', 'POST', $data);
    $result = json_decode($result, true);

    // Update category
    $categoryId = 1;
    $data = [
        'name' => 'Category 1 Updated',
        'isDeleted' => 0,
    ];
    $result = sendRequest($restAPIBaseURL . "/api.php/categories/$categoryId", 'PUT', $data);
    $result = json_decode($result, true);

    // Delete category
    $categoryId = 1;
    $result = sendRequest($restAPIBaseURL . "/api.php/categories/$categoryId", 'DELETE');
    $result = json_decode($result, true);
} catch (Exception $ex) {
    echo '' . $ex->getMessage() . '';
}
?>
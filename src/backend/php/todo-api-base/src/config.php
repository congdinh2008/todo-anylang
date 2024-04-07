<?php
// Database configuration
$host = "localhost";
$username = "sa";
$password = "abcd@1234";
$database_name = "TodoPHPAPIBase";
// Create database connection using sql server
$connection = new mysqli($host, $username, $password, $database_name);
// Check connection
if ($connection->connect_error) {
    die("Connection failed: " . $connection->connect_error);
}
?>
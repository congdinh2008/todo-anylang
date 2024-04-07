<?php
require_once 'config.php';
require_once 'category.php';

$categories = new Category($connection);

$request_method = $_SERVER["REQUEST_METHOD"];
$request_url = $_SERVER["PATH_INFO"];

header("Content-Type: application/json; charset=UTF-8");

switch ($request_method) {
    case 'GET':
        if (isset($request_url)) {
            $id = intval(preg_replace('/[^0-9]/', '', $request_url));
            if ($id > 0) {
                $data = $categories->getSingleCategory($id);
                echo json_encode($data);
            } else {
                $data = $categories->getCategories();
                $categories_arr = array();
                while ($row = $data->fetch_assoc()) {
                    $categories_arr[] = $row;
                }
                echo json_encode($categories_arr);
            }
        }
        break;
    case 'POST':
        $data = json_decode(file_get_contents("php://input"), true);
        if ($categories->createCategory($data)) {
            echo json_encode(array("message" => "Category created successfully."));
        } else {
            echo json_encode(array("message" => "Category could not be created."));
        }
        break;
    case 'PUT':
        $id = intval(preg_replace('/[^0-9]/', '', $request_url));
        $data = json_decode(file_get_contents("php://input"), true);
        if ($categories->updateCategory($id, $data)) {
            echo json_encode(array("message" => "Category updated successfully."));
        } else {
            echo json_encode(array("message" => "Category could not be updated."));
        }
        break;
    case 'DELETE':
        $id = intval(preg_replace('/[^0-9]/', '', $request_url));
        if ($categories->deleteCategory($id)) {
            echo json_encode(array("message" => "Category deleted successfully."));
        } else {
            echo json_encode(array("message" => "Category could not be deleted."));
        }
        break;
    default:
        echo json_encode(array("message" => "Invalid request method."));
        break;
}
?>
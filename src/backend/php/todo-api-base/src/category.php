<?php
class Category
{
    // Connection
    private $connection;

    // Table
    private $db_table = "categories";

    // Columns
    public $id;
    public $name;
    public $insertedAt;
    public $updatedAt;
    public $deletedAt;
    public $isDeleted;

    public function __construct($db)
    {
        $this->connection = $db;
    }

    // GET ALL
    public function getCategories()
    {
        $sqlQuery = "SELECT [id], [name], [isDeleted] FROM " . $this->db_table . "";
        $data = $this->connection->query($sqlQuery);
        return $data;
    }

    // CREATE
    public function createCategory($data)
    {
        $sqlQuery = "INSERT INTO " . $this->db_table . " SET [Name] = :name, [IsDeleted] = 0, [InsertedAt] = GETDATE(), [UpdatedAt] = GETDATE(), [DeletedAt] = NULL";
        $stmt = $this->connection->prepare($sqlQuery);
        // sanitize
        $this->name = $data['name'];
        $this->isDeleted = $data['isDeleted'];
        // bind data
        $stmt->bindParam(":name", $this->name);
        $stmt->bindParam(":isDeleted", $this->isDeleted);
        if ($stmt->execute()) {
            return true;
        }
        return false;
    }

    // READ single
    public function getSingleCategory($id)
    {
        $sqlQuery = "SELECT [Id], [Name], [InsertedAt], [UpdatedAt] FROM " . $this->db_table . " WHERE [Id] = :id";
        $stmt = $this->connection->prepare($sqlQuery);
        $stmt->bindParam(":id", $id);
        $stmt->execute();
        $data = $stmt->fetch(PDO::FETCH_ASSOC);
        return $data;
    }

    // UPDATE
    public function updateCategory($id, $data)
    {
        $sqlQuery = "UPDATE " . $this->db_table . " SET [Name] = :name, [IsDeleted] = :isDeleted, [UpdatedAt] = GETDATE() WHERE [Id] = :id";
        $stmt = $this->connection->prepare($sqlQuery);
        $this->name = $data['name'];
        $this->isDeleted = $data['isDeleted'];
        $this->id = $id;
        // bind data
        $stmt->bindParam(":name", $this->name);
        $stmt->bindParam(":isDeleted", $this->isDeleted);
        $stmt->bindParam(":id", $this->id);
        if ($stmt->execute()) {
            return true;
        }
        return false;
    }

    // DELETE
    public function deleteCategory($id)
    {
        $sqlQuery = "DELETE FROM " . $this->db_table . " WHERE [Id] = :id";
        $stmt = $this->connection->prepare($sqlQuery);
        $this->id = $id;
        $stmt->bindParam(":id", $this->id);
        if ($stmt->execute()) {
            return true;
        }
        return false;
    }
}
?>
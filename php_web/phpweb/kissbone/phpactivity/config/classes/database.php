<?php

class Database {
    private $pdo;

    public function __construct($dsn, $db_user, $db_pw) {
        try {
            $this->pdo = new PDO($dsn, $db_user, $db_pw);
            $this->pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        } catch (PDOException $e) {
            die("Connection failed: " . $e->getMessage());
        }
    }

    public function lastInsertId() {
        return $this->pdo->lastInsertId();
    }

    function getLastRecord($table, $column, $orderBy = 'id') {
        try {
            // Assuming $this->pdo is your PDO connection set up in the constructor of your class
            $stmt = $this->pdo->prepare("SELECT * FROM `$table` ORDER BY `$orderBy` DESC LIMIT 1");
            $stmt->execute();
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
            return $result ? $result[$column] : null;
        } catch (PDOException $e) {
            error_log("Failed to retrieve last record: " . $e->getMessage());
            return null;
        }
    }

    public function sum($tablename, $column, $condition = "1=1") {
        try {
            // Construct SQL query
            $sql = "SELECT SUM({$column}) as total FROM {$tablename} WHERE {$condition};";
            $stmt = $this->pdo->prepare($sql);
            $stmt->execute();
            
            // Fetch the result as a number
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
            return $result['total'] ?? 0; // Return total or 0 if none found
        } catch (PDOException $e) {
            die("Database error: " . $e->getMessage());
        }
    }

    public function sumToday($tablename, $column, $dateColumn) {
        try {
            // Get today's date in YYYY-MM-DD format suitable for SQL queries
            $today = date('Y-m-d');
    
            // Construct SQL query to sum only if the date column matches today's date
            $sql = "SELECT SUM({$column}) as total FROM {$tablename} WHERE {$dateColumn} = :today;";
    
            // Prepare the SQL statement
            $stmt = $this->pdo->prepare($sql);
    
            // Bind the today parameter to the query
            $stmt->bindParam(':today', $today);
    
            // Execute the query
            $stmt->execute();
    
            // Fetch the result as a number
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
    
            // Return total or 0 if none found
            return $result['total'] ?? 0;
        } catch (PDOException $e) {
            die("Database error: " . $e->getMessage());
        }
    }
    

    public function authenticate($username, $password, $tablename) {
        $hashedPassword = "vhgsdsd" . md5($password) . "mnfdfgdv";
        $stmt = $this->pdo->prepare("SELECT * FROM {$tablename} WHERE username = ? AND password=?");
        $stmt->execute([$username, $hashedPassword]);
        return $stmt->fetch(PDO::FETCH_ASSOC);
    }

    public function validation($column, $value, $table) {
        $stmt = $this->pdo->prepare("SELECT * FROM {$table} WHERE {$column} = :value");
        $stmt->bindParam(':value', $value); 
        $stmt->execute(); 
    
        return $stmt->fetch(PDO::FETCH_ASSOC); 
    }

    public function insert($columns, $values, $tablename) {
        $columnNames = implode(',', $columns);
        $placeholders = implode(',', array_fill(0, count($columns), '?'));
        $stmt = $this->pdo->prepare("INSERT INTO {$tablename} ({$columnNames}) VALUES ({$placeholders})");
        $stmt->execute($values);
    }

    public function update($columns, $values, $tablename, $tableId, $id) {
        $columnNames = implode(' = ?, ', $columns) . ' = ?';
        $query = "UPDATE {$tablename} SET {$columnNames} WHERE {$tableId} = ?";
        $stmt = $this->pdo->prepare($query);
        $values[] = $id; 
        $stmt->execute($values);
    }

    public function display($tablename,$operation,$status,$data) {
        try {
            $stmt = $this->pdo->prepare("SELECT {$operation} FROM {$tablename} WHERE {$status} = ?;" );
            $stmt->execute([$data]);  
            return $stmt->fetchAll(PDO::FETCH_OBJ);  
        } catch (PDOException $e) {
            die("Database error: " . $e->getMessage());
        }
    }

    public function price($tablename, $operation, $status, $data) {
        try {
            $stmt = $this->pdo->prepare("SELECT {$operation} FROM {$tablename} WHERE {$status} = ?;");
            $stmt->execute([$data]);
            return $stmt->fetch(PDO::FETCH_OBJ);
        } catch (PDOException $e) {
            die("Database error: " . $e->getMessage());
        }
    }

    public function getId($tablename, $columnName, $whereColumn, $whereValue) {
        try {
            // Prepare the SQL statement with placeholders for table and column names
            $stmt = $this->pdo->prepare("SELECT {$columnName} FROM {$tablename} WHERE {$whereColumn} = ? LIMIT 1;");
            $stmt->execute([$whereValue]);
            
            // Fetch the result as an associative array
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
            
            // Return the specific column value (ID) if available
            return $result ? $result[$columnName] : null;
        } catch (PDOException $e) {
            die("Database error: " . $e->getMessage());
        }
    }

    public function getAmount($tablename, $amountColumn,$id) {
        try {
            $stmt = $this->pdo->prepare("SELECT {$amountColumn} FROM {$tablename} ORDER BY {$id} DESC LIMIT 1;");
            $stmt->execute();
            
            // Fetch the result as an associative array
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
            
            // Return the amount if available
            return $result ? $result[$amountColumn] : null;
        } catch (PDOException $e) {
            die("Database error: " . $e->getMessage());
        }
    }
    
    public function display1($tablename,$operation) {
        try {
            $stmt = $this->pdo->prepare("SELECT {$operation} FROM {$tablename};" );
            $stmt->execute();  
            return $stmt->fetchAll(PDO::FETCH_OBJ);  
        } catch (PDOException $e) {
            die("Database error: " . $e->getMessage());
        }
    }

    public function view($tablename,$operation,$status,$data,$operator) {
        try {
            $stmt = $this->pdo->prepare("SELECT {$operation} FROM {$tablename} WHERE {$status} {$operator} ?;" );
            $stmt->execute([$data]);  
            return $stmt->fetchAll(PDO::FETCH_OBJ);  
        } catch (PDOException $e) {
            die("Database error: " . $e->getMessage());
        }
    }
    

    public function joint($display,$condition){
        try {
            $stmt = $this->pdo->prepare("SELECT {$display} FROM {$condition}" );
            $stmt->execute();  
            return $stmt->fetchAll(PDO::FETCH_OBJ);  
        } catch (PDOException $e) {
            die("Database error: " . $e->getMessage());
        }
    }

    public function count($tablename, $conditionColumn, $conditionValue) {
        try {
            // Prepare a statement using COUNT(*) with a WHERE clause
            $stmt = $this->pdo->prepare("SELECT COUNT(*) AS total FROM {$tablename} WHERE {$conditionColumn} = :value;");
            
            // Bind the condition value to the placeholder
            $stmt->bindParam(':value', $conditionValue);
    
            // Execute the statement
            $stmt->execute();
    
            // Fetch the result as an associative array
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
    
            // Return the count of rows from the result
            return $result['total'];
        } catch (PDOException $e) {
            // Handle any errors that occur during the database operation
            die("Database error: " . $e->getMessage());
        }
    }

    function getAmounts($table, $column) {
        global $conn;
        $stmt = $conn->prepare("SELECT SUM($column) AS total FROM $table");
        $stmt->execute();
        return $stmt->fetch(PDO::FETCH_ASSOC)['total'] ?? 0;
    }
    
    function countRecords($table, $column, $value) {
        global $conn;
        $stmt = $conn->prepare("SELECT COUNT(*) AS total FROM $table WHERE $column = :value");
        $stmt->bindParam(':value', $value, PDO::PARAM_INT);
        $stmt->execute();
        return $stmt->fetch(PDO::FETCH_ASSOC)['total'];
    }



}

?>

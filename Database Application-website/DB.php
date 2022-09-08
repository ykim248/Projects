<?php
class DatabaseConnection {
    protected $db_username;
    protected $db_password;
    protected $db_databasename;
    protected $db_port;
    protected $mysqli;
    protected $db_table;

    function __construct() {
        $this->db_host = 'localhost';
        $this->db_username = 'Kim';
        $this->db_password =  '1234';
        $this->db_databasename = 'tba';
        $this->db_port = 3306;
        $this->db_connect();
    }

    private function db_connect() {        
        $this->mysqli = new mysqli($this->db_host, $this->db_username, $this->db_password, $this->db_databasename, $this->db_port);
        
        if ($this->mysqli->connect_error) {
            die('Connection Failed' . $this->mysqli->connect_error);
        }
    }

    function insertInput($Val1, $Val2, $Val3, $Val4, $Val5){
        $sql = sprintf("INSERT INTO Employees (FirstName, LastName, Email, Date, Department) VALUES ('%s', '%s', '%s', '%s', '%s')",
            $this->mysqli->real_escape_string($Val1),
            $this->mysqli->real_escape_string($Val2),
            $this->mysqli->real_escape_string($Val3),
            $this->mysqli->real_escape_string($Val4),
            $this->mysqli->real_escape_string($Val5)
        );
        $sql = $this->mysqli->query($sql);

        if($sql === true) {
            return $sql;
        } else {
            return "you";
        }
    
    }
    
    function SeeResults($db_table) {
        $this->db_connect();
        $sql = "SELECT * FROM " . $db_table;
        $sql = $this->mysqli->query($sql);
    
        return $sql;
    }

    function OnlyOneRow($id){
        $this->db_connect();
        $sql = "SELECT * FROM  employees  WHERE ID = " . $id;
        $sql = $this->mysqli->query($sql);
        $row = $sql->fetch_assoc();

        return $row;
    }

    function UpdateInput($Val1, $Val2, $Val3, $Val4, $Val5, $ValID){
        $this->db_connect();
        $sql = sprintf("UPDATE Employees SET FirstName = '%s', LastName = '%s', Email = '%s', Date = '%s', Department = '%s' WHERE id = '%d'",
            $this->mysqli->real_escape_string($Val1),
            $this->mysqli->real_escape_string($Val2),
            $this->mysqli->real_escape_string($Val3),
            $this->mysqli->real_escape_string($Val4),
            $this->mysqli->real_escape_string($Val5),
            $ValID
                        
        );
        $sql = $this->mysqli->query($sql);

        if($sql === true) {
            return $sql;
        } else {
            return " you";
        }
    
    }

    function DeleteEntry($id) {
        echo 'here';
        $sql = "DELETE FROM employees WHERE ID = " . $id;
        $sql = $this->mysqli->query($sql);

        if($sql === true) {
            return "Data deleted successfully";
        } else {
            return " me";
        }
    }

}
?>

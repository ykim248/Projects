<?php
require 'DB.php';
$UpdatedFN = '';
$UpdatedLN = '';
$UpdatedEmail = '';
$UpdatedDOB = '';
$UpdatedDept = '';


if($_SERVER['REQUEST_METHOD'] == 'POST'){
    $EmpID = $_POST['ID'];
    $UpdatedFN = $_POST['Fname'];
    $UpdatedLN = $_POST['Lname'];
    $UpdatedEmail = $_POST['Email'];
    $UpdatedDOB = $_POST['DOB'];
    $UpdatedDept = $_POST['Department'];  
}

$FUpdate = new DatabaseConnection();
$FUpdate->UpdateInput($UpdatedFN, $UpdatedLN, $UpdatedEmail, $UpdatedDOB, $UpdatedDept, $EmpID);
Header("Location: Read.php?msg=Employee has been taken care of.");
?>
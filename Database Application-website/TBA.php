<?php
require 'DB.php';
$inputFN = '';
$inputLN = '';
$inputEmail = '';
$inputDOB = '';
$inputDept = '';


if($_SERVER['REQUEST_METHOD'] == 'POST'){
    $inputFN = $_POST['Fname'];
    $inputLN = $_POST['Lname'];
    $inputEmail = $_POST['Email'];
    $inputDOB = $_POST['DOB'];
    $inputDept = $_POST['Department'];  
}

$FCreate = new DatabaseConnection();
$FCreate->insertInput($inputFN, $inputLN, $inputEmail, $inputDOB, $inputDept);
Header("Location: Read.php");

?>

<?php
require 'DB.php';

if(isset($_GET['id'])){
    $id = $_GET['id'];
}
else{
    echo 'crud';
}

$FDelete = new DatabaseConnection();
$FDelete->DeleteEntry($id);

Header('Location: Read.php?msg=Employee has been disposed of.');
?>
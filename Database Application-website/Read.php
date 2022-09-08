<?php
require 'DB.php';
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>THE MASTER BAITERS</title>
    <link rel="stylesheet" type="text/css" href="./CSS/Page 2.css">
</head>
<body>
<div id="header1">
            <h1><u><i><b>MASTER BAITER LTD</b></i></u></h1> 
</div>

<?php
$FRead = new DatabaseConnection();
$results = $FRead->SeeResults('employees');
?>
<div class = "container2">
    <table class="EmployeeTable">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">First Name</th>
                <th scope="col">Last Name</th>
                <th scope="col">Email</th>
                <th scope="col">DOB</th>
                <th scope="col">Department</th>
                <th scope="col">Action</th>
            </tr>
        </thead>

<?php   foreach ($results as $row):?>
            <tbody>
            <tr>
                <td><?=$row['ID']?></td>
                <td><?=$row['FirstName']?></td>
                <td><?=$row['LastName']?></td>
                <td><?=$row['Email']?></td>
                <td><?=$row['Date']?></td>
                <td><?=$row['Department']?></td>
                <td>
                    <button class='btnUpdate'><a href='Update.php?id=<?=$row['ID']?>'>Update</a></button> 
                    <button class='btnDelete'><a href='Delete.php?id=<?=$row['ID']?>'>Delete</a></button>
                </td>
            </tr>
            <?php endforeach; ?>
        </tbody>            
    </table>
</div>
<form method="POST" action="create.php">
    <input type="submit" class="Submit" name="Home" value="Home">
</form>
</body>
</html>
<?php
    require 'DB.php';
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>for you</title>
</head>
<body>
<?php

if(isset($_GET['id'])){
    $FUpdate = new DatabaseConnection();
    $results = $FUpdate->OnlyOneRow($_GET['id']);

}
else{
    header('Location: create.php');
}   
?>
<form action="MasterUpdater.php" method="post">
    <label for='ID'>ID:</label>
    <input type='text' id="ID" name="ID" value="<?=$_GET['id']?>" readonly><br><br>
    <label for='Fname'>First Name:</label>
    <input type="text" id="Fname" name="Fname" value="<?=$results['FirstName']?>"><br><br>
    <label for='Lname'>Last Name:</label>
    <input type="text" id="Lname" name="Lname" value="<?=$results['LastName']?>"><br><br>
    <label for='Email'>Email:</label><input type="text" id="Email" name="Email" value="<?=$results['Email']?>"><br><br>
    <label for='Department'>Department:</label><input type="text" id="Department" name="Department" value="<?=$results['Department']?>"><br><br>
    <label for='Date'>DOB: </label><input type="date" id="DOB" name="DOB" value="<?=$results['Date']?>"><br><br>

    <input type="submit" class="Submit" name="Submit" value="Submit"></br>
    
            
</form>

</body>
</html>
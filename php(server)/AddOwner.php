<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "dogbasebackend";

$dogOwner = $_POST["name"];
$dogOwnerAddress = $_POST["address"];


$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error){
    die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully.<br>.<br>";

$sql2 = "INSERT INTO `ownerlist`(`owner_name`, `owner_address`) 
VALUES ('".$dogOwner."','".$dogOwnerAddress."');";
 
if($conn->query($sql2)===TRUE){
    echo"new owner created successfully";
}else{
    echo "error:".$sql2."<br>".$conn->error;
}

$conn->close();

?>
<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "dogbasebackend";

$dogID = $_POST["dog_id"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error){
    die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully.<br>.<br>";

$sql = "DELETE FROM `petlist` WHERE pet_id = ".$dogID.";";

if($conn->query($sql)===TRUE){
    echo"delete dog record successfully";
}else{
    echo "error:".$sql."<br>".$conn->error;
}

$conn->close();

?>
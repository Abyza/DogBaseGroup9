<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "dogbasebackend";

$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error){
    die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully.<br>.<br>";

$sql = "SELECT username from users where username = '" . $loginUser."'";

$result = $conn->query($sql);

if($result->num_rows >0){
    echo "Username is already taken.";
    
}else{
    echo "Creating user...";

    $sql2 = "INSERT INTO users(username, password) VALUES ('".$loginUser."','".$loginPass."')";
 
    if($conn->query($sql2)===TRUE){
        echo"new record created successfully";
    }else{
        echo "error:".$sql2."<br>".$conn->error;
    }
}
$conn->close();

?>
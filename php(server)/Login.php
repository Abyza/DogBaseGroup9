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

$sql = "SELECT password from users where username = '" . $loginUser."'";

$result = $conn->query($sql);

if($result->num_rows >0){
    while($row = $result->fetch_assoc()){
        if($row["password"] == $loginPass){
            echo "Login Success.";
          
        }
      else{
        echo "Wrong Credentials.";
      }
    }
}else{
    echo "Username does not exist";
}
$conn->close();

?>
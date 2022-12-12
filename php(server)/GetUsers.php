<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "dogbasebackend";

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error){
    die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully.<br>.<br>";

$sql = "SELECT username from users";

$result = $conn->query($sql);

if($result->num_rows >0){
    while($row = $result->fetch_assoc()){
        echo "username: " . $row["username"]."<br>";
    }
}else{
    echo "0 results";
}
$conn->close();

?>
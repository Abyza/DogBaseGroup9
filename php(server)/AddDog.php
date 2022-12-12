<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "dogbasebackend";

$dogName = $_POST["name"];
$dogOwned = $_POST["owned"];
$dogOwnerid = $_POST["owner_id"];
$dogRegister_date = $_POST["register_date"];
$dogAge = $_POST["age"];
$dogWeight = $_POST["weight"];
$dogVaccine = $_POST["vaccinated"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error){
    die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully.<br>.<br>";

$sql2 = "INSERT INTO `petlist`(`pet_name`, `is_owned`, `owner_id`, `registered_date`, `pet_age`, `pet_weight`, `is_vaccinated_for_rabies`) 
VALUES ('".$dogName."',".$dogOwned.",".$dogOwnerid.",'".$dogRegister_date."',".$dogAge.",".$dogWeight.",".$dogVaccine.");";
 
if($conn->query($sql2)===TRUE){
    echo"new dog record created successfully";
}else{
    echo "error:".$sql2."<br>".$conn->error;
}

$conn->close();

?>
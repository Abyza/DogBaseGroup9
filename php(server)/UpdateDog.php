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
$dogID = $_POST["dog_id"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error){
    die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully.<br>.<br>";

$sql = "UPDATE petlist SET pet_name='".$dogName."',is_owned= ".$dogOwned." ,owner_id= ".$dogOwnerid." ,registered_date= 
'".$dogRegister_date."',pet_age= ".$dogAge." ,pet_weight=".$dogWeight.",is_vaccinated_for_rabies=".$dogVaccine." WHERE pet_id = ".$dogID."";

if($conn->query($sql)===TRUE){
    echo"updated dog record successfully";
}else{
    echo "error:".$sql."<br>".$conn->error;
}

$conn->close();

?>
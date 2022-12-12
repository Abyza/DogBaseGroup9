<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "dogbasebackend";



$dogName = $_POST["dog_id"];

$path = "http://localhost/dogbasebackend/dogimages/".$dogName.".png";

$image = file_get_contents($path);

echo $image;

$conn->close();

?>

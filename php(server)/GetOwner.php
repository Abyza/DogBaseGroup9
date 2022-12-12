<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "dogbasebackend";

$owner_id = $_POST["owner_id"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error){
    die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully.<br>.<br>";

$sql = "SELECT owner_name, owner_address from ownerlist where owner_id  = '".$owner_id."'" ;

$result = $conn->query($sql);

if($result->num_rows >0){
    $rows =array();
    while($row = $result->fetch_assoc()){
        $rows[]=$row;
    }
    echo json_encode($rows);
}else{
    echo "0 results";
}
$conn->close();

?>
<?php
session_start();
/*if(!($_SESSION['access']==1 || $_SESSION['access']==2)) 
{
    header("Location: http://www.ylw.idv.tw:81/~dajiare/index.html");
    die();
}*/
header("Expires: Tue, 03 Jul 2001 06:00:00 GMT");
header("Last-Modified: " . gmdate("D, d M Y H:i:s") . " GMT");
header("Cache-Control: no-store, no-cache, must-revalidate, max-age=0");
header("Cache-Control: post-check=0, pre-check=0", false);
header("Pragma: no-cache");
header("Connection: close");

$dbms="mysql";
$dbhost = 'localhost:3307';
$dbname = 'vreco';
$dbuser = 'vreco';
$dbpsw ='~Vrdct3028';
$dsn="$dbms:host=$dbhost;dbname=$dbname";

//if(no ligin) exit();
?>
<link rel="stylesheet" type="text/css" href="style2.css">
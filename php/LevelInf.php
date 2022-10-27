<?php
include_once('db.php');
?>
<?php
	$lid = $_GET['lid'];
	$sid = $_GET['sid'];
	$ldid = $_GET['mid'];
	#echo $lid." ".$sid." ".$mid."<br>";
	
	$pdo = new PDO($dsn, $dbuser, $dbpsw);
	$pdo->query("set names utf8");
	if ( !$pdo ) 
	{
		#echo "資料庫連接錯誤";
		exit();
	}
	else 
	{
		if($lid == "-1")
		{
			$sql = sprintf("INSERT INTO `LevelInf` (`lid`, `sid`, `ldid`, `st`, `et`) VALUES (NULL, '%s', '%s', current_timestamp(), current_timestamp());",$sid,$ldid);
			$query = $pdo->query($sql);
			$last_id = $pdo->lastInsertId();
			echo $last_id ;
		}else
		{
			$sql = sprintf("UPDATE `LevelInf` SET `et` = current_timestamp() WHERE `LevelInf`.`lid` = %s;",$lid);
			$query = $pdo->query($sql);
			echo $lid ;
		}
	}
	$pdo->close();
?>

<?php
include_once('db.php');
?>
<?php
	#$lid = $_GET['lid'];
	$sid = $_GET['sid'];
	#$mid = $_GET['mid'];
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
		
		#$sql = sprintf("SELECT * FROM `Mission` WHERE (`mid` = %s)",$mid);
		$sql = sprintf("INSERT INTO `UserData` (`sid`) VALUES ('%s');",$sid);
		#echo $sql."<br>";
		$query    = $pdo->query($sql);
		$datalist = $query->fetchAll();
		
		foreach ($datalist as $datainfo)
		{
        #echo $datainfo['ActionType'] . "<br>" .$datainfo['ActionTarget'];
		$sql2 = sprintf("INSERT INTO `Action`(`lid`, `mid`, `ActionType`, `ActionTarget`, `ActionTime`) VALUES ('%s','%s','%s','%s','%s')",$lid,$mid,$datainfo['ActionType'],$datainfo['ActionTarget'],date('y-m-d h:i:s'));
		#echo $sql2;

		$pdo->exec($sql2);
		echo "Success";
		}
		
		
		
		
	}
	#$pdo->close();
?>

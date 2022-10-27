<html>
<meta http-equiv="content-type" content="text/html; charset=utf-8">
<body>
<table border=1>
<?php
	$sid = $_GET['sid'];
	$ldid = $_GET['ldid'];
	$dbms="mysql";
	$dbhost = 'localhost:3307';
	$dbname = 'vreco';
	$dbuser = 'vreco';
	$dbpsw ='~Vrdct3028';
	$dsn="$dbms:host=$dbhost;dbname=$dbname";
	$pdo = new PDO($dsn, $dbuser, $dbpsw);
	$pdo->query("set names utf8");
	if ( !$pdo ) 
	{
		echo "資料庫連接錯誤";
		exit();
	}
	else 
	{
		echo "資料庫連接成功";
		//INSERT INTO LevelInf(sid, ldid) VALUES ("500", "2")
		/*if ($sid == 'aaa')
		{
			$sql_insert = "INSERT INTO UserData(sid) VALUES ('have')";
		}*/
		$sql_insert_userdata = sprintf("INSERT INTO UserData(sid) VALUES ('%s')", $sid);
		$sql_insert_levelinf = sprintf("INSERT INTO LevelInf(sid, ldid) VALUES ('%s', '%s')", $sid, $ldid);
		$pdo->exec($sql_insert_userdata);
		if ($pdo->query($sql_insert_userdata) === TRUE) 
		{
			echo "成功";
		} 
		else 
		{
			echo "Error: " . $sql_insert_userdata . "<br>" . $pdo->error;
		}
		$pdo->exec($sql_insert_levelinf);
		/*if ($pdo->query($sql_insert) === TRUE) 
		{
			echo "成功";
		} 
		else 
		{
			echo "Error: " . $sql_insert . "<br>" . $pdo->error;
		}*/
		//$pdo->query("set names utf8");
		//$query=$pdo->query("insert into UserData(sid) values ('200')");
	}
	$pdo->close();
?>
</table>
</body>
</html>
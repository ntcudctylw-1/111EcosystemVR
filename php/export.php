<?php 
include("server.php");
?>
<html>
<meta http-equiv="content-type" content="text/html; charset=utf-8">
<body>
<table border=1>
<?php
try 
{
    $pdo = new PDO($dsn, $dbuser, $dbpsw);
    $pdo->query("set names utf8");
    $query=$pdo->query("select * from UserData left join LevelInf on UserData.sid=LevelInf.sid left join Action on Action.lid=LevelInf.lid left join Mission on Mission.mid=Action.mid order by UserData.sid");
    $datalist = $query->fetchAll(PDO::FETCH_ASSOC);    
    foreach ($datalist as $datainfo)
    {            
        echo "<tr>";
        foreach($datainfo as $key => $value) echo "<th>".$key."</th>";          
        echo "</tr>";
        break;
    }
    $query=$pdo->query("select * from UserData left join LevelInf on UserData.sid=LevelInf.sid left join Action on Action.lid=LevelInf.lid left join Mission on Mission.mid=Action.mid order by UserData.sid");              
    $datalist = $query->fetchAll(PDO::FETCH_ASSOC);    
    foreach ($datalist as $datainfo)
    {            
        echo "\r\n<tr>";
        foreach($datainfo as $key => $value) echo "<td>".$value."</td>";          
        echo "</tr>";
    }      
}
catch (Exception $e) {die ("Error!: " . $e->getMessage() . "<br/>");}
?>
</table>
</body>
</html>
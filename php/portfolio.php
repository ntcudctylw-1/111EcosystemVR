<?php 
include("header.php");
include("server.php");
?>
<script type="text/javascript" language="javascript">
function changescene()
{
    alert(document.getElementById("st").value);
}
</script>
<body>
<?php 
include("funmenu.php");
$sid=$_POST['sid'];
$st=$_POST['st'];
$et=$_POST['et'];
?>
<form name=selectdata method=post>
姓名：<input name=sid type=text size=10><br><br>
期間：<input id=st name=st class=datetimepicker_es onchange=changescene()> 至 <input id=et name=et class=datetimepicker_es> <br><br>
<input type="submit" value="查詢">
<br><br>
<?php
try 
{
    $pdo = new PDO($dsn, $dbuser, $dbpsw);
    $pdo->query("set names utf8");
    
    if($sid!="" || $st!="" || $et!="")
    {
    	$qrs="";
    	echo "查詢條件為 ";
    	if($sid!="") {echo " 姓名是".$sid;if($qrs=="") $qrs="UserData.sid='".$sid."'"; else $qrs=$qrs." and UserData.sid='".$sid."'";}
    	if($st!="") {echo " 操作時間在".$st."之後";if($qrs=="") $qrs="ActionTime>'".$st."'"; else $qrs=$qrs." and ActionTime>'".$st."'";}
		if($et!="") {echo " 操作時間在".$et."之前";if($qrs=="") $qrs="ActionTime<'".$et."'"; else $qrs=$qrs." and ActionTime<'".$et."'";} 
		echo "<br>";			
	}
	$sharesql=" from UserData left join LevelInf on UserData.sid=LevelInf.sid left join Action on Action.lid=LevelInf.lid left join Mission on Mission.mid=Action.mid left join LevelData on LevelData.ldid=LevelInf.ldid";
	
	//報表模組--begin
	$anas=" LevelName,st,et,et-st as ct ";
	$anag=" group by LevelInf.ldid order by LevelInf.ldid ";
    $sql="select ".$anas.$sharesql;
	if($qrs!="") $sql=$sql." where ".$qrs;
	$sql=$sql.$anag;
	//echo $sql."<br>";
	$query=$pdo->query($sql);
    $datalist = $query->fetchAll(PDO::FETCH_ASSOC);
	echo "<table><tr><th colspan=2 bgcolor=#8ac6d1>學習時間</th></tr><tr><td bgcolor=#bbded6>單元</td><td bgcolor=#bbded6>開始時間</td><td bgcolor=#bbded6>結束時間</td><td bgcolor=#bbded6>時數(分)</td>";
	foreach ($datalist as $datainfo)
    {            
        echo "<tr>";
        $index=0;
        foreach($datainfo as $key => $value)
		{ 
			if($index<3) echo "<td bgcolor=#fae3d9>".$value."</td>"; 
			else
			{ 
				$tdw=500;
				$val=(int)($value/60);
				if($val<$tdw) $tdw=$val;
				echo "<td><table width=".$tdw."><tr><td bgcolor=#ffb6b9>".$val."</td></tr></table></td>";
			}
			$index++;
		}          
        echo "</tr>";        
    }
	echo "</table><br><br>";
	//報表模組--end  
	
	//報表模組--begin
	$anas=" LevelName,count(LevelInf.ldid) ";
	$anag=" group by LevelInf.ldid order by LevelInf.ldid ";
    $sql="select ".$anas.$sharesql;
	if($qrs!="") $sql=$sql." where ".$qrs;
	$sql=$sql.$anag;
	//echo $sql."<br>";
	$query=$pdo->query($sql);
    $datalist = $query->fetchAll(PDO::FETCH_ASSOC);
	echo "<table><tr><th colspan=2 bgcolor=#8ac6d1>活動參與度</th></tr><tr><td bgcolor=#bbded6>單元</td><td bgcolor=#bbded6>次數</td>";
	foreach ($datalist as $datainfo)
    {            
        echo "<tr>";
        $index=0;
        foreach($datainfo as $key => $value)
		{ 
			if($index==0) echo "<td bgcolor=#fae3d9>".$value."</td>"; else echo "<td><table width=".$value."><tr><td bgcolor=#ffb6b9>".$value."</td></tr></table></td>";
			$index++;
		}          
        echo "</tr>";        
    }
	echo "</table><br><br>";
	//報表模組--end    
	
	//報表模組--begin
	$anas=" MissionName,count(Mission.mid) ";
	$anag=" group by Mission.mid order by count(Mission.mid) desc";
    $sql="select ".$anas.$sharesql;
	if($qrs!="") $sql=$sql." where ".$qrs;
	$sql=$sql.$anag;
	$query=$pdo->query($sql);
    $datalist = $query->fetchAll(PDO::FETCH_ASSOC);
	echo "<table><tr><th colspan=2 bgcolor=#8ac6d1>任務清單</th></tr><tr><td bgcolor=#bbded6>名稱</td><td bgcolor=#bbded6>次數</td>";
	foreach ($datalist as $datainfo)
    {            
        echo "<tr>";
        $index=0;
        foreach($datainfo as $key => $value)
		{ 
			if($index==0) echo "<td bgcolor=#fae3d9>".$value."</td>"; else echo "<td><table width=".($value*2)."><tr><td bgcolor=#ffb6b9>".$value."</td></tr></table></td>";
			$index++;
		}          
        echo "</tr>";        
    }
	echo "</table><br><br>";
	//報表模組--end 
	
	//報表模組--begin
	$anas=" Action.ActionTarget,count(Action.ActionTarget) ";
	$anag=" group by Action.ActionTarget order by count(Action.ActionTarget) desc";
    $sql="select ".$anas.$sharesql;
	if($qrs!="") $sql=$sql." where ".$qrs;
	$sql=$sql.$anag;
	$query=$pdo->query($sql);
    $datalist = $query->fetchAll(PDO::FETCH_ASSOC);
	echo "<table><tr><th colspan=2 bgcolor=#8ac6d1>行為操作</th></tr><tr><td bgcolor=#bbded6>名稱</td><td bgcolor=#bbded6>次數</td>";
	foreach ($datalist as $datainfo)
    {            
        echo "<tr>";
        $index=0;
        foreach($datainfo as $key => $value)
		{ 
			if($index==0) echo "<td bgcolor=#fae3d9>".$value."</td>"; else echo "<td><table width=".($value*2)."><tr><td bgcolor=#ffb6b9>".$value."</td></tr></table></td>";
			$index++;
		}          
        echo "</tr>";        
    }
	echo "</table><br><br>";
	//報表模組--end       
}
catch (Exception $e) {die ("Error!: " . $e->getMessage() . "<br/>");}
?>
</body>
</html>
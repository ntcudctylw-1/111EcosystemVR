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
<a href=export.csv>匯出</a>
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
		echo "。";		
		$sql="select * from UserData left join LevelInf on UserData.sid=LevelInf.sid left join Action on Action.lid=LevelInf.lid left join Mission on Mission.mid=Action.mid where ".$qrs." order by UserData.sid";	
	}
    else 
		$sql="select * from UserData left join LevelInf on UserData.sid=LevelInf.sid left join Action on Action.lid=LevelInf.lid left join Mission on Mission.mid=Action.mid order by UserData.sid";
	$query=$pdo->query($sql);
    $datalist = $query->fetchAll(PDO::FETCH_ASSOC);
	$num=0;    
	$strbuf="";
	$myfile = fopen("export.csv", "w");
	fwrite($myfile, pack("CCC", 0xef, 0xbb, 0xbf));
    foreach ($datalist as $datainfo)
    {            
        if($num==0)
        {
			$strbuf="<table border=1><tr><th></th>";
	        foreach($datainfo as $key => $value) {$strbuf=$strbuf."<th>".$key."</th>";fwrite($myfile, $key.",");}          
	        $strbuf=$strbuf."</tr>";
        }        
        $num++;
        //break; //只顯示標題
    }
    fwrite($myfile, "\n");
    echo "共計 ".$num." 筆資料";
    echo $strbuf;
    $query=$pdo->query($sql);              
    $datalist = $query->fetchAll(PDO::FETCH_ASSOC);  
	$count=1;	
    foreach ($datalist as $datainfo)
    {            
        echo "\r\n<tr><td>".$count."</td>";
        foreach($datainfo as $key => $value) {echo "<td>".$value."</td>";fwrite($myfile, $value.",");}
		fwrite($myfile, "\n");            
        echo "</tr>";
        $count++;
    }
	fclose($myfile);      
}
catch (Exception $e) {die ("Error!: " . $e->getMessage() . "<br/>");}
?>
</table>
</body>
</html>
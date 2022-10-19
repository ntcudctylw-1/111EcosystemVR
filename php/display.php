<html>
<head>
<meta http-equiv="refresh" content="15" />
<meta http-equiv="content-type" content="text/html; charset=utf-8">
</head>
<body>
<h2><center>VR教學即時管理系統</center></h2>
<table width=95%>
<tr>
<?php
$rnum=$_GET["rnum"];
if(empty($rnum)) $rnum=4;
date_default_timezone_set('Asia/Taipei');
$today = date('Y/m/d H:i:s');
echo "<td width=33%>更新頻率：<select id=period onchange='changeint()'><option value=500>0.5秒</option><option value=1000>1秒</option><option value=1500>1.5秒</option><option value=2000>2秒</option><option value=3000>3秒</option></select></td>\r\n";
echo "<td width=33%>版面數量：<select id=rnum onchange='changenum()'>";
for($i=3;$i<8;$i++) if($rnum==$i) echo "<option value=".$i." selected>1行".$i."個</option>"; else echo "<option value=".$i.">1行".$i."個</option>";
echo "</select></td>";
echo "<td width=33% align=right>現在時間：".$today."</td>";
$file=glob("./screen/*");
$count=0;
?>
</tr></table>
<table border=1>
<tr>
<?php
foreach($file as $fn) 
{
    $tw=1500;
	echo "<td width=".(int)($tw/$rnum).">";
    $fn=substr($fn,9);
    echo "<img src='./screen/".$fn."/0.png' id='".$fn."' width=100%>";
    echo "<br>".$fn;
    echo "</td>\r\n";
    $count=$count+1;
    if($count%$rnum==0) echo "</tr><tr>\r\n";
}               
?>
</tr>
</table>
<script type="text/javascript">
var i=0;
var num=document.images.length;
var intid=setInterval("refresh()",document.getElementById('period').value/num);

function refresh()
{
	document.images.item(i).src='./screen/'+document.images.item(i).id+'/0.png?'+ new Date().getTime();
	i++;
	if(i>=num) i=0;
}
function changeint()
{
	clearInterval(intid);
	intid=setInterval("refresh()",document.getElementById('period').value/num);
}
function changenum()
{
	location = "http://www.ylw.idv.tw:81/~vreco/display.php?rnum="+document.getElementById('rnum').value;
}
</script>
</boay>
</html>
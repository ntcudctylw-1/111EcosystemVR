<?php
$_SESSION['access']=4;
if($_SESSION['access']>=4) echo "系統管理員";
else if($_SESSION['access']==3) echo "資料管理員";
else if($_SESSION['access']==2) echo "導覽管理員";
else if($_SESSION['access']==1) echo "一般使用者";
if($_SESSION['access']>=3) echo "[<a href=index.php>Raw Data</a>]";
if($_SESSION['access']>=4) echo "[<a href=portfolio.php>Portfolio</a>]";
if($_SESSION['access']>=4) echo "[<a href=import.php>Import</a>]";
if($_SESSION['access']>=4) echo "[<A href=display.php>VR即時教學管理系統</a>]";
echo "[<a href=logout.php>Logout</a>]";
?>
<hr>
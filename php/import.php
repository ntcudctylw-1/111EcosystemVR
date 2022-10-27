<?php 
include("header.php");
include("server.php");
?>
<body>
<?php 
include("funmenu.php");
?>
<form method="post" enctype="multipart/form-data">
<label for="avatar">選擇檔案:</label>
<input type="file" id="avatar" name="avatar" accept=".csv,.txt"><br>
<input type="submit" value="上傳匯入">
</body>
</html>
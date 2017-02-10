<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitInfo.aspx.cs" Inherits="FoodShareUI.SubmitInfo" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>添加个人作品</title>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all"/>
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="js/jquery-1.11.0.min.js"></script>
<!-- Custom Theme files -->
<link href="css/style.css" rel="stylesheet" type="text/css" media="all"/>
<!-- Custom Theme files -->
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Horse Farm Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!--Google Fonts-->
<link href='https://fonts.googleapis.com/css?family=Baumans' rel='stylesheet' type='text/css'/>
<link href='https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,300italic,700' rel='stylesheet' type='text/css'/>
<script type="text/javascript">
        $(function(){
            $("#returnmymainpage").click(function(){
                location.href="mymainpage.aspx";
            })
        })
    </script>
</head>
<body class="login">
    <form id="info" runat="server" enctype="multipart/form-data"  >
        <div class="container">
				<div class="single">
        <div class="comment-bottom">
             <input type="button" class="btn btn-lg btn-warning" id="returnmymainpage" value="返回我的主页" />
        <h3>作品上传</h3>
        <!------------作品上传--------->
        <div>
                <input type="file"   name="fileUpload"/>
        </div>
        <br />
        <div>
           <p>作品名称:<input type="text" name="wtitle" placeholder="作品名称..." /></p>
        </div>
       
        <div>
            作品介绍：
            <textarea placeholder="作品介绍..." name="wintroduce"></textarea>
            </div>

        <asp:Button ID="submitworks" runat="server" class="btn btn-lg btn-primary" Text="提交" OnClick="submitworks_Click" Visible="true" />
      
       
            </div>
    </div>
    </div>
    </form>
</body>
</html>

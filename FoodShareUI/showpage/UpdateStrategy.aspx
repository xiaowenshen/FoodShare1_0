<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateStrategy.aspx.cs" Inherits="FoodShareUI.showpage.UpdateStrategy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>一起用餐吧美食分享</title>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all"/>
    <link href="css/pageStyle.css" rel="stylesheet" />
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="js/jquery-1.11.0.min.js"></script>
<!-- Custom Theme files -->
    <link href="css/tableStytle.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet" type="text/css" media="all"/>
<!-- Custom Theme files -->
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Horse Farm Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!--Google Fonts-->
<link href='https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,300italic,700' rel='stylesheet' type='text/css'/>
<link href='https://fonts.googleapis.com/css?family=Baumans' rel='stylesheet' type='text/css'/>
<!-- start-->
<link rel="stylesheet" href="css/flexslider.css" type="text/css" media="screen" />
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all"/>

<link rel="stylesheet" type="text/css" href="css/style_common.css" />
<link rel="stylesheet" type="text/css" href="css/style3.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
	<div class="container">
		 <div class="header-main">
           <div class="container">
				<div class="single">
        <div class="comment-bottom">
        <h3>攻略展示</h3>
        <!------------showstrategy--------->
      
        <br />
       
                <img class="img-responsive" src="../<%=ms.Path %>"/>
             <h2>标题：</h2>
            <input type="text" name="title" value="<%=ms.STitle %>" />

            <br /> 
            <div>
                <br />
                <h2>攻略内容:</h2>

                <div class=" single-grid">
                    <input type="text" name="content"  value=" <%=ms.SContent %>"/>
                </div>

            </div>

            <div id="content">
               </div>
    <asp:Button ID="edit" class="btn btn-lg btn-warning" runat="server" Text="确认修改" OnClick="edit_Click" />&nbsp&nbsp&nbsp&nbsp
            <asp:Button ID="returnmypage" runat="server" class="btn btn-lg btn-warning" Text="返回我的主页" OnClick="returnmypage_Click" />
            </div>
    </div>
    </div>
             	  </div>
	</div>
 </div>
    </form>
</body>
</html>

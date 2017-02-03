﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateWork.aspx.cs" Inherits="FoodShareUI.showpage.UpdateWork" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="js/jquery-1.11.0.min.js"></script>
<!-- Custom Theme files -->
<link href="css/style.css" rel="stylesheet" type="text/css" media="all"/>
<!-- Custom Theme files -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Horse Farm Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!--Google Fonts-->
<link href='https://fonts.googleapis.com/css?family=Baumans' rel='stylesheet' type='text/css'>
<link href='https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,300italic,700' rel='stylesheet' type='text/css'>
</head>
<body>
  
    <form id="form1" runat="server">
          <div class="banner-two">
  <div class="header">
    <div>
      
        <div class="container">
				<div class="single">
        <div class="comment-bottom">
        <h3>作品展示</h3>
        <!------------showstrategy--------->
      
        <br />
                <img class="img-responsive"  style="width:600px;height:400px" src="../<%=work.path%>"/>
             <h2><span style="color:#e5cd68">作品标题：</span></h2>
            <input type="text" name="title" value="<%=work.WTitle %>" />

            <br /> 
            <div>
                <br />
                <h2><span style="color:#e5cd68">作品介绍：</span></h2>

                <div class=" single-grid">
                    <input type="text" name="content"  value=" <%=work.introduce %>"/>
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
</html>--%><!DOCTYPE HTML>
<html>
<head>
<title>Single</title>
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="js/jquery-1.11.0.min.js"></script>
<!-- Custom Theme files -->
<link href="css/style.css" rel="stylesheet" type="text/css" media="all"/>
<!-- Custom Theme files -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Horse Farm Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!--Google Fonts-->
<link href='https://fonts.googleapis.com/css?family=Baumans' rel='stylesheet' type='text/css'>
<link href='https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,300italic,700' rel='stylesheet' type='text/css'>
</head>
<body>
<!--header start here-->
<div class="banner-two">
  <div class="header">
	<div class="container">
		 <div class="header-main">
				<div class="logo">
					<h1><a href="index.html">Horse Farm</a></h1>
				</div>
				<div class="top-nav">
				<nav class="cl-effect-20">
					<span class="menu"> <img src="images/icon.png" alt=""/></span>
					<ul class="res">
					   <li><a href="index.html" class="active">Home</a></li> 
						<li><a href="about.html">About</a></li> 
						<li><a href="gallery.html">Gallery</a></li> 
						<li><a href="typo.html">Typo</a></li> 
						<li><a href="contact.html">Contact</a></li> 
				   </ul>
				</nav>
					<!-- script-for-menu -->
						 <script>
						   $( "span.menu" ).click(function() {
							 $( "ul.res" ).slideToggle( 300, function() {
							 // Animation complete.
							  });
							 });
						</script>
		        <!-- /script-for-menu -->
				</div>
		 <div class="clearfix"> </div>
	  </div>
	</div>
 </div>
</div>
<!--header end here-->
<!--single-->
			<div class="container">
				<div class="single">
						<img class="img-responsive" src="images/b1.jpg" alt="">
					<div class=" single-grid">
						<h2>Sed eget volutpat ipsum. Integer fring illa leo porttitor ultrices quam lobortis ligula</h2>				
							<div class="cal">
							<ul>
								<li><span><i class="glyphicon glyphicon-calendar"> </i>22.01.2015</span></li>
								<li><a href="#"><i class="glyphicon glyphicon-comment"> </i>24</a></li>
							</ul>
						</div>	  						
						<p>Cras consequat iaculis lorem, id vehicula erat mattis quis. Vivamus laoreet velit justo, in ven e natis purus pretium sit amet. Praesent lectus tortor, tincidu nt in consectetur vestibulum, ultrices nec neque. Praesent nec sagittis mauris. Fusce convallis nunc neque. Integer egestas aliquam interdum. Nulla ante diam, interdum nec tempus eu, feugiat vel erat. Integer aliquam mi quis accum san porta.
						Quisque nec turpis nisi. Proin lobortis nisl ut orci euismod, et lobortis est scelerisque. Sed eget volutpat ipsum. Integer fring illa leo porttitor, ultrices quam non, lobortis ligula. Aliquam vel consequat arcu.</p>
						<p>On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will, which is the same as saying through shrinking from toil and pain. These cases are perfectly simple and easy to distinguish.
							On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will, which is the same as saying through shrinking from toil and pain. These cases are perfectly simple and easy to distinguish.</p>
					</div>
					<div class="comments-top">
						<h3>Comments</h3>
						<div class="media">
					      	<div class="media-body">
						        <h4 class="media-heading">	Richard Spark</h4>
						        <p>oblame belongs</p>
					      	</div>
					      <div class="media-right">
					        <a href="#">
								<img src="images/si.png" alt=""> </a>
					      </div>
					 </div>
					  <div class="media">
					      <div class="media-left">
					        <a href="#">
					        	<img src="images/si.png" alt="">
					        </a>
					      </div>
					      <div class="media-body">
					        <h4 class="media-heading">Joseph Goh</h4>
					        <p>123132132132 </p>
					      </div>
					    </div>
    				</div>
    				<div class="comment-bottom">
    					<h3>Leave a Comment</h3>
    					<form>	
						<input type="text" placeholder="Name">
				        <input type="text" placeholder="Email">
						 <input type="text" placeholder="Subject">
						<textarea placeholder="Message"></textarea>
							<input type="submit" value="Send">
					</form>
    				</div>
				</div>	
			</div>			
<!--//single-->
<!--footer start here-->
<div class="footer">
	<div class="container">
		<div class="footer-main">
		    <div class="col-md-3 ftr-grid">
		    	<h3>About</h3>
		    	<p>At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias.</p>
		    </div>
		    <div class="col-md-3 ftr-grid">
		    	<h3>Wild life</h3>
		    	<ul>
		    		<li><a href="#">Qui blanditiis praesentium</a></li>
		    		<li><a href="#">Accusam dignissimos ducimu</a></li>
		    		<li><a href="#">deleniti atque  molestias.</a></li>
		    		<li><a href="#">voluptatum deleniti atque.</a></li>
		    	</ul>
		    </div>
		    <div class="col-md-3 ftr-grid">
		    	<h3>Contact</h3>
		    	<input type="text" value="Email" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Email';}">
		    	<input type="submit" value="Subscribe">
		    </div>
		    <div class="col-md-3 ftr-grid">
		    	<h3>Follow Us</h3>
		    	<ul>
		    		<li><a href="#">Facebook</a></li>
		    		<li><a href="#">Twitter</a></li>
		    		<li><a href="#">Google +</a></li>
		    		<li><a href="#">Skype</a></li>
		    	</ul>
		    </div>
			<div class="clearfix"> </div>
		</div>
		<div class="copy-right">
			   <p>Copyright &copy; 2015.Company name All rights reserved.<a target="_blank" href="http://www.cssmoban.com/">&#x7F51;&#x9875;&#x6A21;&#x677F;</a></p>
		</div>
	</div>
</div>
<!--footer end here-->
</body>
</html>
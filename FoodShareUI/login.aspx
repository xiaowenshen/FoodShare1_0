<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FoodShare1_0.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>一起用餐吧登陆</title>
    <link href="./login_file/style_log.css" rel="stylesheet" type="text/css"/>
<link rel="stylesheet" type="text/css" href="./login_file/style.css"/>
<link rel="stylesheet" type="text/css" href="./login_file/userpanel.css"/>
<link rel="stylesheet" type="text/css" href="./login_file/jquery.ui.all.css"/>
</head>

<body class="login" ><%--mycollectionplug="bind"--%>
    <form runat="server" id="loginform">
<div class="login_m">
<div class="login_logo"><img src="./login_file/logo.png" width="196" height="46"/></div>
<div class="login_boder">

<div class="login_padding" id="login_model">

  <h2>用户名</h2>
  <label>
    <input type="text" id="username" name="account" class="txt_input txt_input2" onfocus="if (value ==&#39;请输入用户名&#39;){value =&#39;&#39;}" onblur="if (value ==&#39;&#39;){value=&#39;请输入用户名&#39;}" value="请输入用户名"/>
      <span id="account"></span>
  </label>
  <h2>密码</h2>
  <label>
    <input type="password" name="pwd" id="userpwd" class="txt_input" onfocus="if (value ==&#39;******&#39;){value =&#39;&#39;}" onblur="if (value ==&#39;&#39;){value=&#39;******&#39;}" value="******"/>
  </label>
 
 

 
  <p class="forgot"><a id="iforget" href="ifoget.html">忘记密码?</a></p>
  <div class="rem_sub">
  <div class="rem_sub_l">
   <p class="forgot"><a id="iaccount" href="register.html">还没有账户?</a></p>
   </div>
    <label>
      <%--<input type="submit" class="sub_button" name="button" id="button" value="SIGN-IN" style="opacity: 0.7;"/>--%>
        <asp:Button ID="btnlogin" class="sub_button" runat="server" Text="登陆" style="opacity: 0.7;" OnClick="btnlogin_Click" />
    </label>
  </div>
</div>

<div id="forget_model" class="login_padding" style="display:none">
<br/>

 

 
  <div class="rem_sub">
  <div class="rem_sub_l">
   </div>
    <label>
     <input type="submit" class="sub_buttons" name="button" id="Retrievenow" value="Retrieve now" style="opacity: 0.7;"/>
     　　　
     <input type="submit" class="sub_button" name="button" id="denglou" value="Return" style="opacity: 0.7;"/>　　
    
    </label>
  </div>
</div>

<!--login_padding  Sign up end-->
</div><!--login_boder end-->
</div><!--login_m end-->


        </form>

</body></html>

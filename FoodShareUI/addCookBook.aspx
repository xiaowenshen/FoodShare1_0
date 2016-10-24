<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCookBook.aspx.cs" Inherits="FoodShareUI.addCookBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>添加个人菜谱</title>
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
        $(function () {
            $("#stepcount").click(function () {
                var count = $("#count").val();
                $.post("mymainpageoperation/UploadCookBook.ashx", { "count": count }, function (data) {
                    
                    $("#content").html(data);//
                   // addBind(count);
                });
            })
             $("#returnpage").click(function(){
                 
                 location.href="mymainpage.aspx";
             })
            
            
        });
        //function addBind(count)
        //{
        //    $("#confirm").click(function () {
        //        var jsondata = $("#content").serializeArray();
        //         $.post("addCookbookinfo.ashx",jsondata,function(data){
        //             alert("OOOOOO!");
        //             if(data == "OK")
        //             {
        //                //添加成功
        //                alert("添加成功！");
        //                location.href = "addCookBook.aspx"
        //             }
        //             else
        //             {
        //                 //添加失败
        //                 alert("添加失败！");
        //             }
                     
        //         })       

        //    });
       // }

    </script>
</head>
<body class="login">
  <form id="info" runat="server" enctype="multipart/form-data"  >
        <div class="container">
				<div class="single">
        <div class="comment-bottom">
        <h3>菜谱上传</h3>
        <!------------菜谱上传--------->
      
        <br />
       
        请输入步骤数目： <input type="text" name="stepcount" id="count" /> <input type="button" class="btn btn-lg btn-primary" value ="确认" id="stepcount" />
            <br />  <asp:Label ID="mycount" runat="server" ></asp:Label>
            <div>
                <input type="file"   name="fileUpload"/>
                菜谱名称：<input type="text" name ="CTitle" /> 
                <br />
                菜谱介绍:<input type="text" name="CIntroduce"/>
            </div>

            <div id="content">
               </div>
            <asp:Button class="btn btn-lg btn-primary" ID="Submit" runat="server" Text="确认上传"  OnClick="Submit_Click"/>
        <%--<input type="submit"  id="confirm" value ="确认上传" hidden="hidden" />--%>
        <input type="button" class="btn btn-lg btn-warning" id="returnpage" value="返回我的主页" />
            </div>
    </div>
    </div>
    </form>
</body>
</html>

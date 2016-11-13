﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mymainpage.aspx.cs" Inherits="FoodShareUI.mymainpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <title>个人主页</title>
        <meta name="description" content=""/>
        <script src="js/jquery-1.11.0.min.js"></script>
        <script src="js/jquery.easyui.min.js"></script>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <link href="css/pageStyle.css" rel="stylesheet" />
        <link rel="stylesheet" href="css/normalize.css"/>
        <link rel="stylesheet" href="css/font-awesome.css"/>
        <link rel="stylesheet" href="css/bootstrap.min.css"/>
        <link rel="stylesheet" href="css/templatemo-style.css"/>
        <link href="css/tableStytle.css" rel="stylesheet" />
        <script src="js/vendor/modernizr-2.6.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
           //添加作品
            $("#addMyWork").click(function () {
                location.href = "SubmitInfo.aspx";
            })
            //添加菜谱
            $("#addCookBook").click(function () {
                location.href = "addCookBook.aspx";
            })
            
            //加载攻略列表
            LoadStrategyInfo(1);
            //加载菜单
            LoadMenuInfo(1);
            //加载菜谱
            LoadCookBook(1);
            //加载收藏
            LoadCollect();
        })

        //加载收藏
        function LoadCollect()
        {
            $.post("mymainpageoperation/showCollection.ashx", {}, function (data) {
                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList.length;
                var string = "";
                for (var i = 0; i < jlength; i++) {
                    string = string + "<div class=\"col-md-4 col-sm-6\"><div class=\"project-item\" ><img src='" + jsondata.SList[i].path + "' style=\"width:433px;height:320px\"  /><div class=\"project-hover\">" +
                                                "<div class=\"inside\">" +
                                                    "<h5><a target='_blank' href=\"showpage/showcookbook.aspx?cid=" + jsondata.SList[i].CId + "\">" + jsondata.SList[i].CTitle + "</a></h5>" +
                                                    "<p>" + jsondata.SList[i].CIntroduce + "</p>" +
                                               " </div>" +
                                           " </div>" +
                                     " </div><input type=\"button\"  menuid =\"" + jsondata.SList[i].CId + "\" name=\"deletecollection\"  class=\"btn btn-1 btn-danger\" value =\"删除此菜谱\" /></div>";
                }
                $("#collectcontent").html(string);
                BindDelCollect();
            }, "text");
           
            

        }
        //加载菜谱
        function LoadCookBook(cookbookindex)
        {
           // $("#cookbookcontent").remove();
            $.post("mymainpageoperation/showCookBook.ashx", { "cbindex": cookbookindex }, function (data) {
                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList.length;
                var string = "";
                for (var i = 0; i < jlength; i++) 
                {
                    string = string + "<div class=\"col-md-4 col-sm-6\"><div class=\"project-item\" ><img src='" + jsondata.SList[i].path + "' style=\"width:433px;height:320px\"  /><div class=\"project-hover\">" +
                                                "<div class=\"inside\">" +
                                                    "<h5><a target='_blank' href=\"showpage/showcookbook.aspx?cid=" + jsondata.SList[i].CId + "\">" + jsondata.SList[i].CTitle + "</a></h5>" +
                                                    "<p>" + jsondata.SList[i].CIntroduce + "</p>" +
                                               " </div>" +
                                           " </div>" +
                                     " </div>" + "<input type=\"button\" name=\"addtocookbook\" class=\"btn btn-1 btn-info\" value =\"添加至菜单\" />" +
                                       " <input type=\"button\"  menuid =\"" + jsondata.SList[i].CId + "\" name=\"addtocollection\"  class=\"btn btn-1 btn-info\" value =\"添加至收藏夹\" /></div>";
                }
                $("#cookbookcontent").html(string);
               // alert(string);
                $("#cookbookpagebar").html(jsondata.PageBar);
                CookPageBar();
                //绑定添加菜谱至收藏夹
                BindAdd();
                BindDel();
            }, "text");
        }
        //加载分页条
        function CookPageBar()
        {
            $(".cbpages").click(function () {
                var cbindex = $(this).attr("href").split("=")[1];
                LoadCookBook(cbindex);
                //防止跳转
                return false;
            });
        }

        //加载攻略
        function LoadStrategyInfo(strategypageindex) {

            //清除数据
            $("#Strategylist tr:gt(0)").remove();
            $.post("mymainpageoperation/ShowMyStrategy.ashx", { "mspageindex": strategypageindex }, function (data) {
                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList.length;
                for (var i = 0; i < jlength; i++) {
                    $("<tr><td>" + jsondata.SList[i].STitle + "</td><td>" + jsondata.SList[i].Uname + "</td><td>" +
                        ChangeDateFormat(jsondata.SList[i].addtime) + "</td><td>" + "<a target=\"_blank\" href='<%=Page.ResolveUrl("~/showpage/showstrategy.aspx")%>?Sid="+jsondata.SList[i].SId+"' class='detail'>详情</a>" + "" +
                        "</td><td><a href='<%=Page.ResolveUrl("~/showpage/editstrategy.aspx")%>?Sid=" + jsondata.SList[i].SId + "' class='edit'>编辑</a></td>" + "<td><a href='javascript:void(0)' sid='" + jsondata.SList[i].SId + "' class='del'>删除</a></td>" + "</tr>").appendTo("#Strategylist");
                }
                $("#mspagebar").html(jsondata.PageBar);
                StrategyPageBar();
                BindDel();
                BindAdd();
            })
        }
        
        //显示页码条
        function StrategyPageBar() {
            $(".mspages").click(function () {
                var pageindex = $(this).attr("href").split("=")[1];
                //清除数据
                $("#Strategylist tr:gt(0)").remove();
                LoadStrategyInfo(pageindex);
                //不发生跳转
                return false;
            });
        }


        // //加载菜单
        function LoadMenuInfo(menupageindex){
            $.post("mymainpageoperation/ShowMenu.ashx", { "menupageindex": menupageindex }, function (data) {
                
                var jsondata = data ;//$.parsejson(data);
                var jlength = jsondata.SList.length;
                var string = "";
                //alert(jsondata.Index);
                for (var i = 0; i < jlength; i++) {
                   string = string + "<img src=\"" + jsondata.SList[i].path + "\"  style=\"width:100px;height:100px\"/>"
                            + "<p>介绍:</p>"
                            + "<p>"
                            + jsondata.SList[i].MenuIntroduce
                            + "..."
                            + "<a target='_blank' href='<%=Page.ResolveUrl("~/showpage/showmenu.aspx")%>?MenuId=" + jsondata.SList[i].MenuId + "' >详情</a>"
                            + "</p>"
                            + "<hr />"
                }
                BindAdd();
                $.parseHTML(string);
                $("#showmenu").html(string);
                $("#menupagebar").html(jsondata.PageBar);
                MenuPageBar();
            },"json");
        }
            //显示页码条
            function  MenuPageBar()
            {
                $(".menupages").click(function ()
                {
                    var menupageindex = $(this).attr("href").split("=")[1];
                  //  //清除数据   
                  //  $("#showmenu").remove();
                    LoadMenuInfo(menupageindex);
                    //不发生跳转
                    return false;
                });
            }
        //删除收藏
            function BindDelCollect()
            {
                $("input[name='deletecollection']").bind('click', function () {
                    if (!confirm("确认要删除吗？"))
                        return false;
                    else {
                        var menuid = $(this).attr("menuid");
                        $.post("mymainpageoperation/deleteCollection.ashx", { "menuid": menuid }, function (data) {
                            if (data == "OK") {
                                alert("删除成功！")
                                LoadCollect();
                            }
                            else {
                                alert("删除失败！请稍后再试！");
                            }
                        }, "text");
                    }

                });

            }
        //删除攻略
        function BindDel() {
            
            $('.del').click(function () {
                var sid = $(this).attr("sid");
                if (!confirm("确认要删除吗？"))
                    return false;
                else {
                    $.post("showpage/DelStrategy.ashx", { "sid": sid }, function (data) {
                        if (data == "ok") {
                            //清楚原有表格数据
                            //把tr从第一行的数据开始 全部清除
                            $("#Strategylist tr:gt(0)").remove();
                            //重新加载
                            LoadStrategyInfo();
                            alert("删除成功！");
                        }
                    });
                }

            });
        }
        //添加到收藏夹
        function AddToCollect()
        {
            $("input[name='addtocollection']").bind('click', function () {
                var menuid = $(this).attr("menuid");
                $.post("mymainpageoperation/addtocollection.ashx", { "menuid": menuid }, function (data) {
                    if (data == "OK") {
                        alert("添加成功！");
                        LoadCollect();
                    }
                    else if (data == "EXIST") {
                        alert("此菜谱已经添加过，请勿重复添加！");
                    }
                    else {
                        alert("添加失败，请稍后再试！");
                    }
                }, "text");
            });
        }
        //绑定添加项
        function BindAdd()
        {
            AddToCollect();
        }
      
        //将序列化成json格式后日期(毫秒数)转成日期格式
        function ChangeDateFormat(cellval) {
            var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
            var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
            var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
            return date.getFullYear() + "-" + month + "-" + currentDate;
        }
    </script>
<%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>--%>
 
</head>
    <body>
       
    
        <div class="responsive-header visible-xs visible-sm">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="top-section">
                            <div class="profile-image">
                                <img src="images/profile.jpg" alt="Volton"/>
                            </div>
                            <div class="profile-content">
                                <h3 class="profile-title"><%=Uinfo.name %></h3>
                                <p class="profile-description"><%=(Uinfo.introduce == "" ? "暂无介绍..." : Uinfo.introduce )  %></p>
                            </div>
                        </div>
                    </div>
                </div>
            
            </div>
        </div>
		
        <!-- SIDEBAR -->
        <div class="sidebar-menu hidden-xs hidden-sm">
            <div class="top-section">
                <div class="profile-image">
                    <img src="images/profile.jpg" alt="Volton"/>
                </div>
                <h3 class="profile-title"><%=Uinfo.name %></h3>
                <p class="profile-description"><%=(Uinfo.introduce == "" ? "暂无介绍..." : Uinfo.introduce )  %></p>
            </div> <!-- top-section -->
            <div class="main-navigation">
                <ul class="navigation">
                     <li><a href="#top"><i class="fa fa-link"></i>欢迎</a></li>
                    <%--<li><a href="#"><i class="fa fa-link"></i>我的厨房</a></li>--%>
                    <li><a href="#myworks"><i class="fa fa-link"></i>我的作品</a></li>
                    <li><a href="#newmycookbook"><i class="fa fa-link"></i>我的菜谱</a></li>
                    <li><a href="#mystrategy"><i class="fa fa-link"></i>我的攻略</a></li>
                    <li><a href="#cookmenu"><i class="fa fa-link"></i>我的菜单</a></li>
                    <li><a href="#mycollect"><i class="fa fa-link"></i>我的收藏</a></li>
                    <li><a href="#myconcern"><i class="fa fa-link"></i>关注的人</a></li>
                    <li><a href="#myboard"><i class="fa fa-link"></i>留言板</a></li>
                </ul>
            </div> <!-- .main-navigation -->
            
        </div> <!-- .sidebar-menu -->
        
        	
        <div class="banner-bg" id="top">
            <div class="banner-overlay"></div>
            <div class="welcome-text">
                <h2>欢迎来到我的主页 | <%=Uinfo.name %></h2>
                <h5><%=(Uinfo.introduce == "" ? "暂无介绍..." : Uinfo.introduce )  %></h5>
            </div>
        </div>

        <!-- MAIN CONTENT -->
        <div class="main-content">
            <div class="fluid-container">

                <div class="content-wrapper">
                    <!---myworks---->
                    <!-- PROJECTS -->
                    <form id="works" runat="server">

                    
                    <div class="page-section" id="myworks" >
                    <div class="row">
                        <div class="col-md-12">
                            <h4 style="font-size: 16px;font-family: 'robotobold';text-transform: uppercase;margin-bottom: 40px;"><%=Uinfo.name %>的作品</h4>
                        </div>
                    </div>
                        <div class="row projects-holder">
                        <asp:Repeater ID="Repeater1" runat="server">
                            
                                     <ItemTemplate>
                                
                                    <div class="col-md-4 col-sm-6">
                                        <div class="project-item">
                                            <img src="<%#Eval("path") %>" style="width:433px;height:320px" alt=""/>
                                            <div class="project-hover">
                                                <div class="inside">
                                                    <h5><a href="#"><%#Eval("WTitle") %></a></h5>
                                                    <p><%#Eval("introduce") %></p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                      
                            </ItemTemplate>
                                
                            <FooterTemplate>
                                <div class ="page">
                                    <br />

                                     <p><%=FoodShareCOMMON.PageBarHelper.GetPageBar(WorkIndex,WorkPageCount) %></p>
                                </div>
                                <div>
                                    <input type="button" id="addMyWork" class="btn btn-1 btn-primary" value ="添加个人作品"/>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                            </div>
                    </div>
                    <!---myworks-end--->

                         <!----newmycookbook----->    
                  <div class="page-section" id="newmycookbook" >
                   <div class="row">
                     <div class="col-md-12">
                        <h4 style="font-size: 16px;font-family: 'robotobold';text-transform: uppercase;margin-bottom: 40px;"><%=Uinfo.name %>的菜谱</h4>
                     </div>
                  </div>
                        <div class="row projects-holder" id="cookbookcontent"></div>
                             <div class="page" id="cookbookpagebar"></div>
                                <div>
                                    <input type="button" id="addCookBook" class="btn btn-1 btn-primary" value ="添加个人菜谱"/>
                                </div>
                     


                 </div>

                         <!----endnewmycookbook----->       

                    <!----mycookbook----->          
                <%--    <div class="page-section" id="mycookbook" >
                    <div class="row">
                        <div class="col-md-12">
                            <h4 style="font-size: 16px;font-family: 'robotobold';text-transform: uppercase;margin-bottom: 40px;"><%=Uinfo.name %>的菜谱</h4>
                        </div>
                    </div>
                        <div class="row projects-holder">
<%--                        <asp:Repeater ID="Repeater2" runat="server">
                            
                                     <ItemTemplate>
                                
                                    <div class="col-md-4 col-sm-6">
                                        <div class="project-item">
                                            <img src="<%#Eval("path") %>" alt=""/>
                                            <div class="project-hover">
                                                <div class="inside">
                                                    <h5><a target="_blank" href="showpage/showcookbook.aspx?cid=<%#Eval("CId")  %>"><%#Eval("CTitle") %></a></h5>
                                                    <p><%#Eval("CIntroduce") %></p>
                                                </div>
                                            </div>
                                        </div>
                                        <input type="button" name="addtocookbook" class="btn btn-1 btn-info" value ="添加至菜单" />
                                        <input type="button"  menuid ="<%#Eval("CId") %>" name="addtocollection"  class="btn btn-1 btn-info" value ="添加至收藏夹" />
                                    </div>
                            </ItemTemplate>
                                
                            <FooterTemplate>
                                <br />
                                <div class="page">
                                     <p><%=CookPageBar%></p>
                                </div>
                                <div>
                                    <input type="button" id="addCookBook" class="btn btn-1 btn-primary" value ="添加个人菜谱"/>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>--%>
                     <%--       </div>
                    </div> --%>
                        </form>
                    <!---mycookbook-end--->

                      <!----mystrategy------->
                     <div class="page-section" id="mystrategy" >
                     <center><h4 style="font-size:3px;color : gray">攻略</h4></center>
                      <div class="bann-strip">
	                    <div class="container">
		                    <div class="bann-strip-main">
                                <center>
                                    <table id="Strategylist">
                                        <tr><th>攻略名</th><th>作者</th><th>攻略添加时间</th><th>详情</th><th>编辑</th><th>删除</th></tr>
                    
                                    </table>
                                    <div id="mspagebar" class ="page">

                                    </div>
                                </center>
                            </div>
	                    </div>
                    </div>
                     <input type="button"   onclick="window.open('showpage/addstrategy.aspx')"  id="addStrategy" class="btn btn-1 btn-primary" value ="添加攻略"/>
                    </div>
                    <!----endmystrategy------->

                    <!-- cookmenu -->
                    <div class="page-section" id="cookmenu">
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="widget-title">菜单</h4>
                          
                            <div id="menucontent" >
                                <div id ="showmenu">

                            </div>
                                <div id="menupagebar" class="page">
                            </div>
                                <input type="button"   onclick="window.open('showpage/addcookmenu.aspx')"  id="addcookmenu" class="btn btn-1 btn-primary" value ="添加个人菜单"/>
                          </div>
                              
                        </div>
                    </div>
                         
                    </div>
                    <!-- endcookmenu -->

                    <!-- mycollect -->
                    <div class="page-section" id="mycollect">
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="widget-title">我的收藏</h4>
                            <p></p>
                        </div>
                    </div>
                    <div class="row projects-holder" id="collectcontent">
<%--                        <div class="col-md-4 col-sm-6">
                            <div class="project-item">
                                <img src="images/1.jpg" alt=""/>
                                <div class="project-hover">
                                    <div class="inside">
                                        <h5><a href="#">Pellentesque porta ligula</a></h5>
                                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam cursus</p>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                    </div>
            
                    </div> 
                    <!-- endmycollect -->、
                    <hr/>
                     <!----myconcern------->
                     <div class="page-section" id="myconcern" >
                     <center><h4 style="font-size:3px;color : gray">攻略</h4></center>
                      <div class="bann-strip">
	                    <div class="container">
		                    <div class="bann-strip-main">
                                <center>
                                    <table id="concernlist">
                                        <tr><th>攻略名</th><th>作者</th><th>攻略添加时间</th><th>详情</th><th>编辑</th><th>删除</th></tr>
                    
                                    </table>
                                    <div id="mcpagebar" class ="page">

                                    </div>
                                </center>
                            </div>
	                    </div>
                    </div>
                    </div>
                    <!----endmyconcern------->

                     <!----myboard------->
                     <div class="page-section" id="myboard" >
                     <center><h4 style="font-size:3px;color : gray">留言板</h4></center>
                      <div class="bann-strip">
	                    <div class="container">
		                    
	                    </div>
                    </div>
                    
                    </div>
                        <!----endmyboard------->


                    <!-- CONTACT -->
                    <div class="page-section" id="contact">
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="widget-title">PLACE TO TALK WITH ME</h4>
                            <p>Vestibulum ac iaculis erat, in semper dolor. Maecenas et lorem molestie, maximus justo dignissim, cursus nisl. Nullam at ante quis ex pharetra pulvinar quis id dolor. Integer lorem odio, euismod ut sem sit amet, imperdiet condimentum diam.</p>
                        </div>
                    </div>
                    <div class="row">
                        <form action="#" method="post" class="contact-form">
                            <fieldset class="col-md-4 col-sm-6">
                                <input type="text" id="your-name" placeholder="Your Name..."/>
                            </fieldset>
                            <fieldset class="col-md-4 col-sm-6">
                                <input type="email" id="email" placeholder="Your Email..."/>
                            </fieldset>
                            <fieldset class="col-md-4 col-sm-12">
                                <input type="text" id="your-subject" placeholder="Subject..."/>
                            </fieldset>
                            <fieldset class="col-md-12 col-sm-12">
                                <textarea name="message" id="message" cols="30" rows="6" placeholder="Leave your message..."></textarea>
                            </fieldset>
                            <fieldset class="col-md-12 col-sm-12">
                                <input type="submit" class="button big default" value="Send Message"/>
                            </fieldset>
                        </form>
                    </div> <!-- .contact-form -->
                    </div>
                    <hr/>

                    <div class="row" id="footer">
                        <div class="col-md-12 text-center">
                      </div>
                    </div>

                </div>

            </div>
        </div>

        <script src="js/vendor/jquery-1.10.2.min.js"></script>
        <script src="js/min/plugins.min.js"></script>
        <script src="js/min/main.min.js"></script>

    </body>
</html>
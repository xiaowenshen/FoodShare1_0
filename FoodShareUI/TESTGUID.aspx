<%@ Page Title="" Language="C#" MasterPageFile="~/guide.Master" AutoEventWireup="true" CodeBehind="TESTGUID.aspx.cs" Inherits="FoodShare1_0.TESTGUID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/pageStyle.css" rel="stylesheet" />
    <link href="css/relationship.css" rel="stylesheet" />
    <script  type="text/javascript">
        $(function () {
            //加载攻略
           // LoadStrategyInfo(1);
            //加载菜谱
            LoadCookBook(1);
            //加载菜单
         //   LoadMenuInfo(1);
            //加载top3
            loadTop();
            //加载所有人的主页链接
            LoadFocus(1);
        });
      

        //加载关注
        function LoadFocus(focusindex) {
            $.post("mymainpageoperation/showMemberInfo.ashx", { "index": focusindex }, function (data) {
                //$("#focuscontent").remove();
                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList.length;
                var string = "";
                for (var i = 0; i < jlength; i++) {
                    string = string +
                        "<div class=\"col-sm-6\"><dl>" +
                                      "<dt><a href='singlepage.aspx?cid="+jsondata.SList[i].UId+"' target='_blank'><img src='" + jsondata.SList[i].display + "'   /></a></dt>" +
                                      "<dd>" +
                                        "<h4><a href='singlepage.aspx?cid=" + jsondata.SList[i].UId + "' target='_blank' id='" + jsondata.SList[i].UId + "' title='" + jsondata.SList[i].name + "' class='user_name'>" + jsondata.SList[i].name + "</a></h4>" +
                                        "<p>" + jsondata.SList[i].introduce + "</p>" +
                                        "<div class=\"clearfix\">" +
                                         " <div class=\"pull-left\">" +
                                          "</div>" +
                                          "<div class=\"pull-right\">" +
                                           " <div class=\"follow \">" +
                                            "  <div class=\"text\" ><a href = 'singlepage.aspx?cid="+jsondata.SList[i].UId+"'>点击前往</a></div>" +
                                             " <div class=\"icon\"></div>" +
                                            "</div>" +
                                          "</div>" +
                                        "</div>" +
                                      "</dd>" +
                                    "</dl>" +
                                  "</div>"
                }
                $("#focuscontent").html(string);
                $("#foucuspagebar").html(jsondata.PageBar);
                FocusPageBar();

            });
        }

        function FocusPageBar() {
            $(".focuspages").click(function () {
                var index = $(this).attr("href").split("=")[1];
                LoadFocus(index);
                return false;
            });
        }
        function loadTop()
        {
            var string = "";
            $.post("GuideShow/showtop.ashx", {}, function (data) {

                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList == null ? 0 : jsondata.SList.length;
                jlength = jlength >=3 ? 3 : jlength;
                var string = "";
                for (var i = 0; i < jlength; i++) {
                    var shortcontent = jsondata.SList[i].CIntroduce;
                    shortcontent = shortcontent.substring(0, 15);
                    if (jsondata.SList[i].CIntroduce.length > 20) {
                        shortcontent = shortcontent + "...";
                    }
                    if (shortcontent == "") {
                        shortcontent = "很抱歉，此菜谱作者暂无留下介绍...";
                    }
                    string = string + " <li>" +
                           "<div class=\"col-md-4 banner-left\">" +
                              "<h3>" + jsondata.SList[i].CTitle + " <span class=\"bann-sli-text\">" + shortcontent + "...</span></h3>" +
                           "</div>" +
                            "<div class=\"col-md-8 banner-right\">" +
                               "<img  class=\"img-responsive\" style=\"width:800px;height:473.38px\" src=\"" + jsondata.SList[i].path + "\" />" +
                             "</div> " +
                            "<div class=\"clearfix\"> </div>" +
                      "</li>";

                }
                $("#top3").html(string);
                });
            
            }
         // //加载菜单
        function LoadMenuInfo(menupageindex){
            $.post("GuideShow/ShowMenu.ashx", { "menupageindex": menupageindex }, function (data) {
                
                var jsondata = data ;//$.parsejson(data);
                var jlength = jsondata == null ? 0 : jsondata.SList.length;
                var string = "<div class=\"comments-top\"><center><h3>CookMenu</h3></center>";
                //alert(jsondata.Index);
                for (var i = 0; i < jlength; i++) {
                  <%--  string = string + "<div class=\"media\">" +
                                        "<div class=\"media-left\">" +
                                        " <a href=''>" +
                      "<img src='" + jsondata.SList[i].path + "' alt='' style=\"width:100px;height:100px\">" +
                  "</a>" +
                "</div>" +
                "<div class=\"media-body\">" +
                 " <h4 class=\"media-heading\">介绍</h4>" +
                 " <p>" + jsondata.SList[i].MenuIntroduce + "</p>" +
                 "...<a target='_blank' href='<%=Page.ResolveUrl("~/showpage/showmenu.aspx")%>?MenuId=" + jsondata.SList[i].MenuId + "' >详情</a></div></div>";
                    --%>
                    string = string + "<div class=\"can-help\">" +
	                "<div class=\"container\">"+
		            "<div class=\"can-help-main\">"+
			               "<div class=\"col-md-6 can-help-left\">"+
			   	            " <a target='_blank' href='<%=Page.ResolveUrl("~/showpage/showmenu.aspx")%>?MenuId=" + jsondata.SList[i].MenuId + "' >"+ "<img src='" + jsondata.SList[i].path + "' alt='' style=\"width:540px;height:230px\">"+"</a>"+
			               "</div>"+
			               "<div class=\"col-md-6 can-help-right\">"+
			   	            "<h4><a target='_blank' href='<%=Page.ResolveUrl("~/showpage/showmenu.aspx")%>?MenuId=" + jsondata.SList[i].MenuId + "' >" + jsondata.SList[i].MenuName+ "</a></h4>" +
			   	            "<p> 介绍：<br/>"+jsondata.SList[i].MenuIntroduce+"</p>"+
			   	            "<a class='help-btn' target='_blank' href='<%=Page.ResolveUrl("~/showpage/showmenu.aspx")%>?MenuId=" + jsondata.SList[i].MenuId + "' >View More</a>"+
			               "</div>"+
			            "<div class=\"clearfix\"> </div>"+
		            "</div>"+
	            "</div>"+
            "</div>";
                }
                string = string + "</div>";
             
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
        //加载菜谱
        function LoadCookBook(cookbookindex) {
            // $("#cookbookcontent").remove();
            $.post("GuideShow/ShowCookBook.ashx", { "cbindex": cookbookindex }, function (data) {
                var jsondata = $.parseJSON(data);
                var jlength = jsondata.SList == null ? 0 : jsondata.SList.length;
                var string = "";
                for (var i = 0; i < jlength; i++) {
                    var shortcontent = jsondata.SList[i].CIntroduce;
                    shortcontent = shortcontent.substring(0, 15);
                    if (jsondata.SList[i].CIntroduce.length > 20)
                    {
                        shortcontent = shortcontent + "...";
                    }
                    if (shortcontent == "")
                    {
                        shortcontent = "暂无介绍...";
                    }

                    string = string +   "<div class=\"col-md-3 bann-grid\">"+
			  	" <a target='_blank' href=\"showpage/showcookbook.aspx?cid=" + jsondata.SList[i].CId + "\"><img src='" + jsondata.SList[i].path + "'  style=\"width:255px;height:191.25px\"  class=\"img-responsive\"></a>" +
			  	 "<div class=\"details\">"+
			  	 "	<h4><a target='_blank' href=\"showpage/showcookbook.aspx?cid=" + jsondata.SList[i].CId + "\">" + jsondata.SList[i].CTitle + "</a></h4>" +
                    "<p>" + shortcontent + "</p>" +
			  	 	"<a class=\"bannn-btn\" target='_blank' href=\"showpage/showcookbook.aspx?cid=" + jsondata.SList[i].CId + "&op=0" + "\">Read More</a>" +
			  	 "</div>"+
			  "</div>";



                }
                $("#cookbookcontent").html(string);
                // alert(string);
                $("#cookbookpagebar").html(jsondata.PageBar);
                CookPageBar();
                //绑定添加菜谱至收藏夹
                AddToCollect()
            }, "text");
        }
        //添加到收藏夹
        function AddToCollect() {
            $("input[name='addtocollection']").bind('click', function () {
                var menuid = $(this).attr("menuid");
                $.post("singlepageoperation/addtocollections.ashx", { "menuid": menuid }, function (data) {
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
        //加载分页条
        function CookPageBar() {
            $(".cbpages").click(function () {
                var cbindex = $(this).attr("href").split("=")[1];
                LoadCookBook(cbindex);
                //防止跳转
                return false;
            });
        }
        //加载攻略
        function LoadStrategyInfo(strategypageindex)
        {
            $("#Strategylist tr:gt(0)").remove();
            $.post("ShowStrategy.ashx", { "mspageindex": strategypageindex }, function (data) {
                var jsondata = $.parseJSON(data);
                var length = jsondata.SList.length;
                for (var i = 0; i < length; i++)
                {
                    $("<tr class='active'><td>" + jsondata.SList[i].STitle + "</td><td>" + jsondata.SList[i].Uname + "</td><td>" + ChangeDateFormat(jsondata.SList[i].addtime) + "</td><td>" + "<a target=\"_blank\" href='<%=Page.ResolveUrl("~/showpage/showstrategy.aspx")%>?Sid=" + jsondata.SList[i].SId + "' class='detail'>详情</a>" + "</td></tr>").appendTo("#Strategylist");
                }
                $("#mspagebar").html(jsondata.PageBar);
                    PageBar();
              
            })
        }
        //显示页码条
        function PageBar() {
            $(".mspages").click(function () {
                var pageindex = $(this).attr("href").split("=")[1];
               
                //清除数据
                $("#Strategylist tr:gt(0)").remove();
                LoadStrategyInfo(pageindex);
                //不发生跳转
                return false;
            });
        }
        //将序列化成json格式后日期(毫秒数)转成日期格式
        function ChangeDateFormat(cellval) {
            var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
            var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
            var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
            return date.getFullYear() + "-" + month + "-" + currentDate;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="banner">
 	<div class="container">
		 <div class="banner-bottom">
            <div class="slider">
               <section class="slider">
                  <div class="flexslider">
                    <ul class="slides" id="top3">
              
                 </ul>
           </div>
      </section>
			  <script>window.jQuery || document.write('<script src="js/libs/jquery-1.7.min.js">\x3C/script>')</script>
			  <!--FlexSlider-->
			  <script defer="defer" src="js/jquery.flexslider.js"></script>
			  <script type="text/javascript">
			    $(function(){
			     
			    });
			    $(window).load(function(){
			      $('.flexslider').flexslider({
			        animation: "slide",
			        start: function(slider){
			          $('body').removeClass('loading');
			        }
			      });
			    });
			  </script>
			</div>
		 </div>
		 <span class="mover"> </span>
  </div>
</div>
         <div class="comments-top">
                          <center> <h3>PersonalWorks</h3></center> 
        </div>

    <!--banner-strip start here-->
<div class="bann-strip">
	<div class="container">
		<div class="bann-strip-main">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                      <div class="col-md-3 bann-grid">
			  	 <a href="single.html"><img src="<%#Eval("path") %>" style="width:255px;height:191.25px" class="img-responsive"/></a>
			  	 <div class="details">
			  	 	<h4><a href="single.html"><%#Eval("WTitle").ToString().Length < 1 ? "暂无名称" : Eval("WTitle") %></a></h4>
			  	 	<p><%#Eval("introduce").ToString().Length < 1 ? "暂无介绍.." :  Eval("introduce").ToString().Substring(0,Eval("introduce").ToString().Length > 5 ? 5 : Eval("introduce").ToString().Length) %></p>
			  	 	<a class="bannn-btn" target="_blank" href="mypage.aspx">Read More</a>
			  	 </div>
			  </div>
                </ItemTemplate>
                <FooterTemplate>
                    <div class="page">
                        <p> <%=WorkPageBar %></p>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
			
			<div class="clearfix"> </div>
		</div>
	</div>
</div>
<!--banner strip end here-->

     <!----newmycookbook----->    
                  <div class="page-section" >
                   <div class="row">
                     <div class="col-md-12">             
                         <div class="comments-top">
                          <center> <h3>CookBook</h3></center> 
                     </div>
                     </div>
                  </div>
                      <div class="bann-strip">
	<div class="container">
		<div class="bann-strip-main" id="cookbookcontent">
			
		</div>
	</div>
</div>
                        <div class="row projects-holder" ></div>
                             <div class="page" id="cookbookpagebar"></div>
                 </div>

                         <!----endnewmycookbook----->   
    
                         <!----Strategy----->   
      
<%--          <div class="comments-top">
                          <center> <h3>Strategy</h3></center> 
          </div>
     
            <center>
                <div class="container">
                <table id="Strategylist" class="table">
                    <tr class="success"><th>攻略名</th><th>作者</th><th>攻略添加时间</th><th>详情</th></tr>
                    
                </table>
                <div id="mspagebar" class ="page">

                </div>
                    </div>
            </center>--%>
                         <!----endStrategy----->   
                        <!-- cookmenu -->
<%--    <div class="container">
                    <div class="page-section" id="cookmenu">
                  <div class="row">
                        <div class="col-md-12">
                            <div class="comments-top">
                          
                                </div>
                         
                            <div id="menucontent" >
                                <div id ="showmenu">

                            </div>
                                <div id="menupagebar" class="page">
                            </div>
                          </div>
                              
                       </div>
                    </div>-
                         
                    </div>
        </div>--%>
    <div class="can-help">
	<div class="container">
		<div class="can-help-main" id ="showmenu" >
		</div>
        <div  id="menupagebar" class="page"> </div>
	</div>
</div>
                    <!-- endcookmenu -->

    <!-- start singlepage> -->
    <div class="container">
       <div class="page-section" id="myconcern" >
       <div id="relationship" class="simple-box">
      <div class="content">
          <div class="comments-top"><center><h3>SinglePage</h3></center></div>
                    <div class="list row" id="focuscontent">
              
                    </div>
                    <div class="page" id="foucuspagebar"></div>
                  </div> 

             </div>
       </div>
      </div>
        <!--end singlepage   -->

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/guide.Master" AutoEventWireup="true" CodeBehind="TESTGUID.aspx.cs" Inherits="FoodShare1_0.TESTGUID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/pageStyle.css" rel="stylesheet" />
    <script  type="text/javascript">
        $(function () {
            LoadStrategyInfo(1);
        });
        //加载攻略
        function LoadStrategyInfo(strategypageindex)
        {
            $("#Strategylist tr:gt(0)").remove();
            $.post("ShowStrategy.ashx", { "mspageindex": strategypageindex }, function (data) {
                var jsondata = $.parseJSON(data);
                var length = jsondata.SList.length;
                for (var i = 0; i < length; i++)
                {
                    $("<tr><td>" + jsondata.SList[i].STitle + "</td><td>" + jsondata.SList[i].Uname + "</td><td>" + ChangeDateFormat(jsondata.SList[i].addtime) + "</td><td>" + "<a><详情</a>" + "</td></tr>").appendTo("#Strategylist");
                }
                $("#mspagebar").html(jsondata.PageBar);
                    PageBar();
              
            })
        }
        //显示页码条
        function PageBar() {
            $(".mspages").click(function () {
                var pageindex = $(this).attr("href").split("=")[1];
                //alert(pageindex);
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
                    <ul class="slides">
                      <li>
	                      <div class="col-md-4 banner-left">
		    	             <h3>菜谱1<span class="bann-sli-text"> 作者 </span> <span class="bann-sli-text">介绍</span></h3>
	                      </div>
	                       <div class="col-md-8 banner-right">
	                          <img  class="img-responsive" width="800" height="400" src="images/1.jpg" alt=""/>
	                      	</div> 
	                       <div class="clearfix"> </div>
  	    		     </li>
 	    		     <li>
	                      <div class="col-md-4 banner-left">
		    	            <h3>菜谱2 <span class="bann-sli-text"> 作者 </span> <span class="bann-sli-text">介绍</span></h3>
	                      </div>
	                       <div class="col-md-8 banner-right">
	                          <img  class="img-responsive" width="800" height="400" src="images/2.jpg" alt=""/>
	                      	</div>
	                       <div class="clearfix"> </div>
  	    		     </li>
  	    		      <li>
	                      <div class="col-md-4 banner-left">
		    	            <h3>菜谱3<span class="bann-sli-text"> 作者</span> <span class="bann-sli-text">介绍</span></h3>
	                      </div>
	                       <div class="col-md-8 banner-right">
	                          <img  class="img-responsive" width="800" height="400" src="images/h3.jpg" alt=""/>
	                      	</div>
	                       <div class="clearfix"> </div>
  	    		     </li>
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
    <hr />
   <center> <h4 style="font-size:3px;color : gray">个人作品</h4></center>

    <!--banner-strip start here-->
<div class="bann-strip">
	<div class="container">
		<div class="bann-strip-main">
            //使用repeater重复生成  分页
            <br />
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                      <div class="col-md-3 bann-grid">
			  	 <a href="single.html"><img src="<%#Eval("path") %>" alt="" class="img-responsive"/></a>
			  	 <div class="details">
			  	 	<h4><a href="single.html"><%#Eval("WTitle") %></a></h4>
			  	 	<p><%#Eval("introduce") %></p>
			  	 	<%--<a class="bannn-btn" href="single.html">Read More</a>--%>
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
      <hr />

    <center><h4 style="font-size:3px;color : gray">菜谱</h4></center>
    <div class="bann-strip">
	<div class="container">
		<div class="bann-strip-main">
           
            <br />
            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                      <div class="col-md-3 bann-grid">
			  	 <a href="single.html"><img src="<%#Eval("path") %>" alt="" class="img-responsive"/></a>
			  	 <div class="details">
			  	 	<h4><a href="single.html"><%#Eval("CTitle") %></a></h4>
			  	 	<p><%#Eval("CIntroduce") %></p>
			  	 	<%--<a class="bannn-btn" href="single.html">Read More</a>--%>
			  	 </div>
			  </div>
                </ItemTemplate>
                <FooterTemplate>
                    <div class="page"><p><%=CookPageBar %></p></div>
              
                </FooterTemplate>
            </asp:Repeater>
			
			<div class="clearfix"> </div>
		</div>
	</div>
</div>
      <hr />
    <center><h4 style="font-size:3px;color : gray">攻略</h4></center>
      <div class="bann-strip">
	<div class="container">
		<div class="bann-strip-main">
            <center>
                <table id="Strategylist">
                    <tr><th>攻略名</th><th>作者</th><th>攻略添加时间</th><th>详情</th></tr>
                    
                </table>
                <div id="mspagebar" class ="page">

                </div>
            </center>
        </div>
	</div>
</div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/guide.Master" AutoEventWireup="true" CodeBehind="showmenu.aspx.cs" Inherits="FoodShareUI.showpage.showmenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="gallery">
	<div class="container">
		<div class="gallery-main">
			<div class="gallery-top" >
				<h2><%=FoodMenuName %></h2>
				<p><%=FoodIntroduce %></p>
			</div>
			<div class="gallery-bottom">
                <%=showitem %> 
             <div class="clearfix"> </div>
             </div>
		</div>
       
	</div>
</div>
<link rel="stylesheet" href="css/swipebox.css"/>
	<script src="js/jquery.swipebox.min.js"></script> 
	    <script type="text/javascript">
			jQuery(function($) {
				$(".swipebox").swipebox();
			});
</script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

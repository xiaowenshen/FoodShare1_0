﻿<%@ Page Title="" Language="C#" MasterPageFile="~/guide.Master" AutoEventWireup="true" CodeBehind="mypage.aspx.cs" Inherits="FoodShare1_0.mypage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function changeFrameHeight() {
            var ifm = document.getElementById("iframepage");
            ifm.height = document.documentElement.clientHeight;
        }
        window.onresize = function () {
            changeFrameHeight();
        }   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <iframe id="myiframe"  onload="changeFrameHeight()" src="mymainpage.aspx" style="padding: 0px; width: 100%; height: 1000px;">
        
    </iframe>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
  

</asp:Content>

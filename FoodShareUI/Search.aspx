<%@ Page Title="" Language="C#" MasterPageFile="~/guide.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="FoodShareUI.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/SearchStyle.css" rel="stylesheet" />
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

<%--       <div class="sw_sform" role="search" data-bm="11">
            <div class="hpcLogoWhite hp_sw_logo" data-bm="15">一起分享吧</div>
            <div class="b_searchboxForm" role="search">
                <input class="b_searchbox" id="b_search" /><input type="submit" class="b_searchboxSubmit" id="sb_form_go" title="搜索" tabIndex="0" name="go" />
            </div>
            <br />
            <br />
            <div>
                <input type="checkbox" name="search"  value="用户" checked="checked" />
                <span><font color="#ffffff">用户</font></span>
                &nbsp;&nbsp;&nbsp;
                <input type="checkbox" name="search" value="菜谱" />
                <span><font color="#ffffff">菜谱</font></span>
                &nbsp;&nbsp;&nbsp;
                <input type="checkbox" name="search" value="作品" />
                <span><font color="#ffffff">作品</font></span>
                &nbsp;&nbsp;&nbsp;
             </div>
        </div>--%>
     <iframe id="myiframe_search"  onload="changeFrameHeight()" src="SearchSubPage.html" style="padding: 0px; width: 100%; height: 1000px;">
        
    </iframe>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

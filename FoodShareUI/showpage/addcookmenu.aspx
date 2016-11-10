<%@ Page Title="" Language="C#" MasterPageFile="~/guide.Master" AutoEventWireup="true" CodeBehind="addcookmenu.aspx.cs" Inherits="FoodShareUI.showpage.addcookmenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
				<div class="single">
        <div class="comment-bottom">
        <h3>添加菜单</h3>
        <!------------addstrategy--------->
      
        <br />
       
                <input type="file" name ="img" id="uploadimg" />
             <h2>标题：</h2>
            <input type="text" name="title"  />

            <br /> 
            <div>
                <br />
                <h2>菜单介绍:</h2>
                <div class=" single-grid">
                    <input type="text" name="addcontent"  />
                </div>
            </div>

            <div id="content">
               </div>
    <asp:Button ID="add" class="btn btn-lg btn-warning" runat="server" Text="添加" OnClick="add_Click" />&nbsp&nbsp&nbsp&nbsp
            <asp:Button ID="returnmypage" runat="server" class="btn btn-lg btn-warning" Text="返回我的主页" OnClick="returnmypage_Click" />
            </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

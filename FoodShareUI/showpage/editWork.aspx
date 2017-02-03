<%@ Page Title="" Language="C#" MasterPageFile="~/guide.Master" AutoEventWireup="true" CodeBehind="editWork.aspx.cs" Inherits="FoodShareUI.showpage.editWork" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
        <div class="container">
				<div class="single">
        <div class="comment-bottom">
        <h3>作品展示</h3>
        <!------------showstrategy--------->
      
        <br />
       
                <img class="img-responsive"  style="width:600px;height:400px" src="../<%=work.path%>"/>
             <h2>作品标题：</h2>
            <input type="text" name="title" value="<%=work.WTitle %>" />

            <br /> 
            <div>
                <br />
                <h2>作品介绍:</h2>

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


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

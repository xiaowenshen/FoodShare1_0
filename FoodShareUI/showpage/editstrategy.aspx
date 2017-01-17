<%@ Page Language="C#" MasterPageFile="~/guide.Master" AutoEventWireup="true" CodeBehind="editstrategy.aspx.cs" Inherits="FoodShareUI.showpage.editstrategy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
     

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   
        <div class="container">
				<div class="single">
        <div class="comment-bottom">
        <h3>攻略展示</h3>
        <!------------showstrategy--------->
      
        <br />
       
                <img class="img-responsive"  style="width:600px;height:400px" src="../<%=ms.Path %>"/>
             <h2>标题：</h2>
            <input type="text" name="title" value="<%=ms.STitle %>" />

            <br /> 
            <div>
                <br />
                <h2>攻略内容:</h2>

                <div class=" single-grid">
                    <input type="text" name="content"  value=" <%=ms.SContent %>"/>
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
    <br />


</asp:Content>
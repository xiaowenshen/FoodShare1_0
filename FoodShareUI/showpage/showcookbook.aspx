<%@ Page Title="" Language="C#" MasterPageFile="~/guide.Master" AutoEventWireup="true" CodeBehind="showcookbook.aspx.cs" Inherits="FoodShareUI.showpage.showcookbook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     
        <div class="container">
				<div class="single">
        <div class="comment-bottom">
        <h3>菜谱展示</h3>
            
                <img class="img-responsive" style="width:650px;height:400px" src="../<%=cb.path %>"/>
        <!------------showstrategy--------->
      
        <br />
       
             <h2><%=cb.CTitle %>介绍：</h2>
             <div class=" single-grid">
                    <%=cb.CIntroduce %>
                </div>
            <br /> 
            <div>
                <br />
                <h2>菜谱内容:</h2>                
                    <%=CBcontent %>
            </div>

            <div id="content">
               </div>
           
    
         <asp:Button ID="returnmypage" runat="server" class="btn btn-lg btn-warning" Text="返回我的主页" OnClick="returnmypage_Click" />
            </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/guide.Master" AutoEventWireup="true" CodeBehind="showstrategy.aspx.cs" Inherits="FoodShareUI.showpage.showstrategy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   
        <div class="container">
				<div class="single">
        <div class="comment-bottom">
        <h3>攻略展示</h3>
            
                <img class="img-responsive" src="../<%=ms.Path %>"/>
        <!------------showstrategy--------->
      
        <br />
       
             <h2><%=ms.STitle %></h2>

            <br /> 
            <div>
                <br />
                <h2>攻略内容:</h2>

                <div class=" single-grid">
                    <%=ms.SContent %>

                </div>

            </div>

            <div id="content">
               </div>
           
    
        <input type="button" class="btn btn-lg btn-warning" id="returnpage" value="返回我的主页" />
            </div>
    </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />

  
</asp:Content>

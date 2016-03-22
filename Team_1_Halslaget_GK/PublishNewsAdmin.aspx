<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PublishNewsAdmin.aspx.cs" Inherits="Team_1_Halslaget_GK.PublishNewsAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link href="css/Publishnewsstyle.css" rel="stylesheet" />
<script src='//cdn.tinymce.com/4/tinymce.min.js'></script>
<script src="ja/Tinymce.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox page-title publish-news-fix">
        <h2>Publicera Nyhet</h2>      
    </div>  
    <div class="fullBox">
        <asp:TextBox ID="txtHTMLContent" runat="server" height="500px" TextMode="MultiLine"></asp:TextBox>           
        <br />
        <asp:Button ID="Button1" runat="server" Text="Publicera" CssClass="my-button" OnClick="Button1_Click" /> 
    </div>          
    </asp:Content>

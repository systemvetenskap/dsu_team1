<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewStartList.aspx.cs" Inherits="Team_1_Halslaget_GK.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/ViewStartList.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox">
        <div class="fullBox">
            <h3 id="comptitle" runat="server">Startlista</h3>
        </div>
        <div class="fullBox start-list">
            <asp:GridView ID="GridView1" runat="server" CssClass="Grid"></asp:GridView>
        </div>
    </div>
</asp:Content>

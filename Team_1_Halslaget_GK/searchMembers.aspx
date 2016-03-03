<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="searchMembers.aspx.cs" Inherits="Team_1_Halslaget_GK.searchMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Search</title>
    <link type="text/css" rel="stylesheet" href="css/memberSearch.css"/> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="radioButtons" class="container text-center">
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Name" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true"/>
        <asp:CheckBox ID="CheckBox2" runat="server" Text="ID" OnCheckedChanged="CheckBox2_CheckedChanged" AutoPostBack="true"/>
    </div>
    <div id="textBoxDiv" class="container text-center">
        <asp:TextBox ID="textBoxSearch" runat="server" CssClass="textbox"></asp:TextBox>
    </div>
        <div id="buttonDiv" class="container text-center">
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    <div id="databaseFill" class="container text-center" runat="server">

    </div>
</asp:Content>
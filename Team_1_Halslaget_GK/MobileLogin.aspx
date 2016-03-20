<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Mobile.Master" CodeBehind="MobileLogin.aspx.cs" Inherits="Team_1_Halslaget_GK.MobileLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="loginDiv">
        <div class="mobileBox text-center">
            <h3>VÄLKOMMEN TILL HÅLSLAGETS MOBILPORTAL.</h3>
        </div>
        <div class="mobileBox text-center small-margin">
            <label>Email</label>
            <asp:TextBox ID="userNameInput" runat="server" CssClass="form"></asp:TextBox>
        </div>
        <div class="mobileBox text-center small-margin">
            <label>Password</label>
            <asp:TextBox ID="passWordInput" runat="server" CssClass="form"></asp:TextBox>
        </div>
        <div class="mobileBox text-center small-margin">
            <asp:Button ID="loginButton" runat="server" Text="Log in" CssClass="my-button" OnClick="loginButton_Click" />
        </div>
    </div>
    <div id="failedLogin" class="mobileBox text-center">
        <asp:Label ID="LabelWrongPW" runat="server" Text="Label"></asp:Label>
    </div>
    <div id="goBack" class="mobileBox text-center small-margin">
        <p>Gå tillbaka till <a href="#">startsidan</a></p>
    </div>
</asp:Content>

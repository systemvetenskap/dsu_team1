<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="Team_1_Halslaget_GK.AdminPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Panel</title>
    <link href="css/AdminPanelCss.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox page-title">
        <h1>ADMINPANEL</h1>
    </div>
    <div class="fullBox admin-top-n-bottom-margin">
        <h3>Välkommen <asp:Label ID="lblAdminUserName" runat="server" Text="AdminUserName"></asp:Label></h3>
        <p class="admin-top-n-bottom-margin">Hej och välkommen, här kan du som anställd hos hålslaget GK utföra din arbetsuppgifter och då bland annat boka tider åt medlemmar,
            hantera medlermmas bokningar, skapa nya medlemskap och med mera.
        </p>
    </div>
    <div class="fullBox center-text">
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin01.jpg"/>
            <asp:Button ID="btnGoToBooking" CssClass="my-button admin-btn-txt" runat="server" Text="BOKA TID ÅT MEDLEM" OnClick="btnGoToBooking_Click" />
        </div>
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin02.jpg"/>
            <asp:Button ID="btnGoToHandleBookings" CssClass="my-button admin-btn-txt" runat="server" Text="HANTERA BOKNINGAR" OnClick="btnGoToHandleBookings_Click" />            
        </div>
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin03.jpg"/>
            <asp:Button ID="btnGoToMemberRegistry" CssClass="my-button admin-btn-txt" runat="server" Text="MEDLEMSREGISTER" OnClick="btnGoToMemberRegistry_Click" />            
        </div>
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin04.jpg"/>
            <asp:Button ID="btnGoToCreateNewMember" CssClass="my-button admin-btn-txt" runat="server" Text="SKAPA NY MEDLEM" OnClick="btnGoToCreateNewMember_Click" />            
        </div>
    </div>

    <div class="fullBox center-text">
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin01.jpg"/>
            <asp:Button ID="btnGoToSeasonSettings" runat="server" CssClass="my-button admin-btn-txt"  Text="HANTERA GOLFSÄSONG" OnClick="btnGoToSeasonSettings_Click" />
        </div>
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin02.jpg"/>
            <asp:Button ID="btnGoToCreateSeason" runat="server" CssClass="my-button admin-btn-txt"  Text="SKAPA TÄVLING" />        
        </div>
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin03.jpg"/>
            <asp:Button ID="btnGoToRegisterResult" runat="server" CssClass="my-button admin-btn-txt"  Text="REGISTRERA RESULTAT" OnClick="btnGoToRegisterResult_Click" />        
        </div>
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin04.jpg"/>
            <asp:Button ID="Button4" runat="server" CssClass="my-button admin-btn-txt"  Text="NÅGOT" />          
        </div>
    </div>


</asp:Content>

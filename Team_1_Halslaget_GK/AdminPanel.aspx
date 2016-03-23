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
        <h3>Välkommen <%--<asp:Label ID="lblAdminUserName" runat="server" Text="AdminUserName"></asp:Label>--%></h3>
    </div>
    <div class="fullBox center-text admin-bottom">
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin01.jpg"/>
            <div class="dropdownbox">
            <asp:Button ID="btnGoToBooking" CssClass="my-button admin-btn-txt" runat="server" Text="BOKNINGAR" />
            <div class="dropdown-content quarterBox">
                <asp:LinkButton ID="LinkButton2" runat="server" class="my-button admin-btn-txt" OnClick="btnGoToBooking_Click" >HANTERA BOKNINGAR</asp:LinkButton>
        </div>
            </div>
        </div>
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin02.jpg"/>
            <asp:Button ID="btnGoToSeasonSettings" runat="server" CssClass="my-button admin-btn-txt"  Text="HANTERA GOLFSÄSONG" OnClick="btnGoToSeasonSettings_Click" />
        </div>
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin03.jpg"/>
            <div class="dropdownbox">
            <asp:Button ID="btnGoToMemberRegistry" CssClass="my-button admin-btn-txt" runat="server" Text="MEDLEMMAR" />            
            <div class="dropdown-content quarterBox">
                <asp:LinkButton ID="LinkButton3" runat="server" class="my-button admin-btn-txt" OnClick="btnGoToMemberRegistry_Click" >MEDLEMSREGISTER</asp:LinkButton>
                <asp:LinkButton ID="LinkButton4" runat="server" class="my-button admin-btn-txt" OnClick="btnGoToCreateNewMember_Click" >NY MEDLEM</asp:LinkButton>
        </div>
        </div>
    </div>
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin04.jpg"/>
            <div class="dropdownbox">
            <asp:Button ID="btnGoToCreateSeason" runat="server" CssClass="my-button admin-btn-txt"  Text="TÄVLINGAR" />        
                <div class="dropdown-content quarterBox">
                    <asp:LinkButton ID="GotoCreateComp" runat="server" class="my-button admin-btn-txt" OnClick="GotoCreateComp_Click" >SKAPA TÄVLING</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton6" runat="server" class="my-button admin-btn-txt" OnClick="btnGoToRegisterResult_Click">REGISTRERA RESULTAT</asp:LinkButton>
                    <asp:LinkButton ID="GoToStartlist" runat="server" class="my-button admin-btn-txt"  OnClick="GoToStartlist_Click">STARTLISTA</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" runat="server" class="my-button admin-btn-txt"  OnClick="LinkButton1_Click">BOKA MEDLEM</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <div class="fullBox">
        <div class="quarterBox admin-qBox">
            <img class="admin-img" src="img/admin02.jpg"/>
            <asp:Button ID="btnGoToNews" runat="server" CssClass="my-button admin-btn-txt"  Text="SKAPA NYHET" OnClick="btnGoToNews_Click" />
        </div>
    </div>

</asp:Content>

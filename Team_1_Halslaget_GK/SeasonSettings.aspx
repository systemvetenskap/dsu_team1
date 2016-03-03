<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SeasonSettings.aspx.cs" Inherits="Team_1_Halslaget_GK.SeasonSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox">
        <h1>INSTÄLLNINGAR</h1>
    </div>
    <div class="fullBox">
        <div class="halfBox">
            <div class="fullBox">
                <h3>SKAPA NY GOLFSÄSONG</h3>
            </div>
            <asp:DropDownList ID="DropDownList1" CssClass="DropDown" runat="server">
                <asp:ListItem>Välj</asp:ListItem>
                <asp:ListItem>2016</asp:ListItem>
                <asp:ListItem>2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
            </asp:DropDownList>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
            <asp:CheckBox ID="CheckBox1to9" runat="server" />
            <asp:CheckBox ID="CheckBox10to18" runat="server" />
            <asp:CheckBox ID="CheckBoxRange" runat="server" />
            <asp:Button ID="ButtonSetSeason" runat="server" Text="Spara" OnClick="ButtonSetSeason_Click"/> <%--la till den här rackaren bara för att kunna prova min "reverese backend" kod typ som behövs för den typen av db jag skapade--%>

        </div>

    </div>
</asp:Content>

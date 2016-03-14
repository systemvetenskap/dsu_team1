<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StartList.aspx.cs" Inherits="Team_1_Halslaget_GK.StartList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="css/StartList.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox page-title"><h3>SKAPA SPELLISTA</h3></div>
    <div class="fullBox">
        <div class="halfBox">
            <p><strong>Välj Tävling</strong></p>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="DropDown" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <div class="comp-info">
                <p id="infotext" runat="server"></p>
                <p id="NOcompetitorstext" runat="server"></p>
            </div>
            <asp:Button ID="btnGeneratePlaylist" CssClass="my-button" runat="server" Text="Generera Spellista" OnClick="btnGeneratePlaylist_Click"/>
        </div>
        <div class="halfBox tablehalfbox">
            <asp:GridView ID="GridView1" runat="server" CssClass="Grid"></asp:GridView>
        </div>
    </div>
</asp:Content>

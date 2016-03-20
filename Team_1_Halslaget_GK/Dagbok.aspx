<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dagbok.aspx.cs" Inherits="Team_1_Halslaget_GK.Dagbok" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox">
        <div class="quarterBox">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="sevenFiveBox" runat="server" id="diaryNoteDiv">

        </div>
    </div>
</asp:Content>

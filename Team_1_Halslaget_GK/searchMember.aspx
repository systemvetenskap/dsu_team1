<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="searchMember.aspx.cs" Inherits="Team_1_Halslaget_GK.searchMember" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper" style="text-align: center; margin-top: 20px;">
        <asp:CheckBox ID="checkBoxName" runat="server" text="Namn" OnCheckedChanged="checkBoxName_CheckedChanged" />
        <asp:CheckBox ID="checkBoxID" runat="server" text="ID"/>
    </div>
    <div class="wrapper" style="text-align: center; margin-top: 20px;">
        <input id="searchTextbox" type="text" />
    </div>
    <div class="wrapper" style="text-align: center; margin-top: 20px">
        <asp:Button ID="buttonSearch" runat="server" Text="Button" OnClick="buttonSearch_Click" />
    </div>
    <div id="databaseFill">

    </div>
</asp:Content>

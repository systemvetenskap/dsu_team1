<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dagbok.aspx.cs" Inherits="Team_1_Halslaget_GK.Dagbok" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/DagbokCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox">
        <h1>MIN DAGBOK</h1>
    </div>
    <div class="fullBox">
        <div class="quarterBox">
            <asp:GridView ID="GridView1" AutoGenerateColumns="false" CssClass="Grid" GridLines="None" DataKeyNames="id, id_medlem" runat="server">
                <Columns>
                    <asp:BoundField DataField="date" HeaderText="Datum" SortExpression="date" />
                    <asp:BoundField DataField="title" HeaderText="Titel" SortExpression="title" />
                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="False" />
                    <asp:BoundField DataField="id_medlem" HeaderText="id_medlem" SortExpression="id_medlem" Visible="False" />
                    <asp:CommandField ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="sevenFiveBox" runat="server" id="diaryNoteDiv">
            <p>Test</p>
        </div>
    </div>
</asp:Content>

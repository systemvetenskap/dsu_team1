<%@ Page Title="" Language="C#" MasterPageFile="~/offPage.Master" AutoEventWireup="true" CodeBehind="result.aspx.cs" Inherits="Team_1_Halslaget_GK.result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/resultCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <div class="fullBox page-title"><h2>Spelade tävlingar</h2></div>
    <div class="halfBox">
        <asp:GridView ID="GvComps" runat="server" AutoGenerateColumns="false" DataKeyNames="id" CssClass="Grid" GridLines="None" OnSelectedIndexChanged="GvComps_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="namn" HeaderText="Namn" SortExpression="id" />
                <asp:BoundField DataField="datum" HeaderText="Datum" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="starttid" HeaderText="Start" DataFormatString="{0:HH:mm}" />
                <asp:BoundField ItemStyle-CssClass="capitalize" DataField="type" HeaderText="Tävlingstyp" />                          
                <asp:CommandField ShowSelectButton="true" SelectText="Välj" />
            </Columns> 
        </asp:GridView>
    </div>
    <div class="halfBox">
        <asp:GridView ID="GvResult" runat="server" AutoGenerateColumns="false" CssClass="Grid" GridLines="None">
            <Columns>
                <asp:BoundField DataField="fornamn" HeaderText="Förnamn" SortExpression="id" />
                <asp:BoundField DataField="efternamn" HeaderText="Efternamn" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="score" HeaderText="Score" />
                <asp:BoundField DataField="lag_id" HeaderText="Lagnummer" ConvertEmptyStringToNull="true" />
            </Columns> 
        </asp:GridView>
    </div>
</ContentTemplate>
</asp:UpdatePanel>   
</asp:Content>

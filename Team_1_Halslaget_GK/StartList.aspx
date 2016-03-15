<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StartList.aspx.cs" Inherits="Team_1_Halslaget_GK.StartList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="css/StartList.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="fullBox page-title"><h2>SKAPA SPELLISTA</h2></div>
    <div class="fullBox">
        <div class="halfBox tablehalfbox">                      
            <asp:GridView ID="gvComps" AutoGenerateColumns="false" DataKeyNames="id" CssClass="Grid" GridLines="None" runat="server" OnSelectedIndexChanged="gvComps_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="namn" HeaderText="Namn" SortExpression="id" />
                    <asp:BoundField DataField="datum" HeaderText="Datum" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="starttid" HeaderText="Start" DataFormatString="{0:HH:mm}" />
                    <asp:BoundField ItemStyle-CssClass="capitalize" DataField="type" HeaderText="Tävlingstyp" />                          
                    <asp:CommandField ShowSelectButton="true" SelectText="Välj" />
                </Columns>                
            </asp:GridView><asp:Label ID="lbltype" runat="server" Text=""></asp:Label>
            <div class="comp-info">               
                <asp:Label ID="lblinfo" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="halfBox tablehalfbox">
            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" CssClass="Grid">
                <Columns>
                    <asp:BoundField DataField="fornamn" HeaderText="Förnamn" SortExpression="id" />
                    <asp:BoundField DataField="efternamn" HeaderText="Efternamn" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="starttid" HeaderText="Starttid" DataFormatString="{0:HH:mm}" />
                    <asp:BoundField DataField="lag_id" HeaderText="Lagnummer" ConvertEmptyStringToNull="true" />
                </Columns>  
            </asp:GridView>
        </div>
    </div>
        <div class="halfBox">
            <asp:Button ID="btnGeneratePlaylist" CssClass="my-button" runat="server" Text="Generera Spellista1" OnClick="btnGeneratePlaylist_Click"/>
            <asp:Button ID="BtnGeneratePlaylistLag" CssClass="my-button" runat="server" Text="Generera Spellista2" OnClick="BtnGeneratePlaylistLag_Click" />   
        </div>
</asp:Content>

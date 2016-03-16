<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewStartList.aspx.cs" Inherits="Team_1_Halslaget_GK.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/ViewStartList.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox">
        <div class="fullBox">
            <h3 id="comptitle" runat="server">Startlista</h3>
        </div>
        <div class="fullBox start-list">
            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" CssClass="Grid">
                <Columns>
                    <asp:BoundField DataField="namn" HeaderText="Namn" SortExpression="id" />
                    <asp:BoundField DataField="datum" HeaderText="Datum" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="starttid" HeaderText="Start" DataFormatString="{0:HH:mm}" />
                    <asp:BoundField ItemStyle-CssClass="capitalize" DataField="type" HeaderText="Tävlingstyp" />                          
                </Columns> 
            </asp:GridView>
          </div>
        </div>
</asp:Content>

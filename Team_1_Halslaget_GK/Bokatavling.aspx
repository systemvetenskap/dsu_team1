<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Bokatavling.aspx.cs" Inherits="Team_1_Halslaget_GK.Bokatavling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/BokatavlingCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="fullBox page-title"><h1>Tävlingar</h1></div>
            <div class="halfBox">
                <asp:TextBox ID="tbsearchTavling" CssClass="my-txt-box" Placeholder="Sök" runat="server"></asp:TextBox><br />
                <asp:RadioButtonList ID="rdlTavlingType" CssClass="my-radiobutton-list" runat="server">
                    <asp:ListItem>Alla</asp:ListItem>
                    <asp:ListItem>Singeltävlingar</asp:ListItem>
                    <asp:ListItem>Lagtävlingar</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                hej                         
                <asp:GridView ID="gvTavlingar" DataKeyNames="id" CssClass="Grid" GridLines="None" runat="server" AutoGenerateColumns="false"  OnSelectedIndexChanged="gvTavlingar_SelectedIndexChanged">
                           <Columns>
                                    <asp:BoundField DataField="namn" HeaderText="Namn" SortExpression="id" />
                                    <asp:BoundField DataField="datum" HeaderText="Datum" DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="starttid" HeaderText="Start" DataFormatString="{0:HH:mm}" />
                                    <asp:BoundField DataField="sluttid" HeaderText="Slut" DataFormatString="{0:HH:mm}"  />                            
                                    <asp:CommandField ShowSelectButton="true" />
                            </Columns>
                    </asp:GridView>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="halfBox">
                <h3><asp:Label ID="lblTavlingNamn" runat="server" Text="TÄVLING!!!!"></asp:Label></h3><br />
                <h4><asp:Label ID="lblTavlingTyp" runat="server" Text="Singel"></asp:Label></h4><br />
                <p><asp:Label ID="lblTavlingDesc" runat="server" Text=" Bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla"></asp:Label></p><br />
                <asp:Button ID="btnConfirm" CssClass="my-button" runat="server" Text="Anmäl mig" /><br />
                <asp:Button ID="btnRemove" CssClass="my-button" runat="server" Text="Ta bort mig från tävlingen" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

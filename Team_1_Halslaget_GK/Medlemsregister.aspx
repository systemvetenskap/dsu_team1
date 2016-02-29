<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Medlemsregister.aspx.cs" Inherits="Team_1_Halslaget_GK.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="css/Medlemsregister.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="register">   
        <table class="centrera">
            <tr>
                <td>
                    <asp:RadioButtonList ID="RadioButtonListSortera" runat="server" OnSelectedIndexChanged="RadioButtonListSortera_OnSelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal">
                        <asp:ListItem Text ="ID"></asp:ListItem>
                        <asp:ListItem Text ="Förnamn"></asp:ListItem>
                        <asp:ListItem Text ="Efternamn"></asp:ListItem>
                        <asp:ListItem Text="Handikapp"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="ListBoxMedlemsregister" runat="server" CssClass="medlemsregister" AutoPostBack ="true" style="min-width:100%;"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonVisaMedlemInfo" runat="server" Text="Visa Medlem" OnClick="ButtonVisaMedlemInfo_Click"/>
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxID" runat="server" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxFornamn" runat="server" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEfternamn" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:TextBox ID="TextBoxAdress" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:TextBox ID="TextBoxPostnummer" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:TextBox ID="TextBoxOrt" runat="server" Visible="false"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:TextBox ID="TextBoxEmail" runat="server" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxHandikapp" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:button id="ButtonTillbaka" runat="server" text="Tillbaka" Visible="false" OnClientClick="JavaScript:window.history.back(1);return false;"></asp:button>
                </td>
                <td>
                    <asp:Button ID="ButtonRedigera" runat="server" Text="Redigera medlemsinfo" Visible="false" OnClick="ButtonRedigera_Click"/>
                </td>
                <td>
                    <asp:Button ID="ButtonRadera" runat="server" Text="Radera" Visible ="false" OnClick="ButtonRadera_Click"/>
                </td>
                <td>
                    <asp:Button ID="ButtonSpara" runat="server" Text="Spara" Visible="false" OnClick="ButtonSpara_Click"/>
                </td>
            </tr>
        </table>
  
    </div> 

</asp:Content>
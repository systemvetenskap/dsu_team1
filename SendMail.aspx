<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SendMail.aspx.cs" Inherits="Team_1_Halslaget_GK.SendMail"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            font-size: small;
            font-style: italic;
        }
        .auto-style2 {
            font-size: x-large;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox page-SendEmail">
        <h1 class="auto-style2">Skicka mail:</h1>
        <p class="auto-style1">Här kan personalen skicka mail till medlemmar i golfklubben.</p>
        <p class="auto-style1">(Skriv in textmeddelandet i textboxen och tryck &quot;Skicka mail&quot; så skickas textmeddelandet till alla medlemmar i golfklubben)</p>
        <br />
    </div>  
      
    <br />
      
       <asp:Label ID="Label1" runat="server" Text="Ärende:"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox2" runat="server" Height="23px" Width="218px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Mailtext:"></asp:Label>
    <br />
       <asp:TextBox ID="TextBox1" runat="server" Height="158px" Width="1194px"></asp:TextBox>
       <asp:Button ID="Button4" runat="server" Text="Skicka mail" CssClass="my-button" OnClick="Button4_Click" />
    </asp:Content>

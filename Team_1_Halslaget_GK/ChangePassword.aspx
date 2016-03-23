<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Team_1_Halslaget_GK.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Byta lösenord</title>
    <link href="css/changePasswordCss.css" rel="stylesheet" />
    <script src="ja/ChangePasswordJs.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox">
        <div class="fullBox page-title">
            <h1>BYT LÖSENORD</h1>
        </div>
        <div class="halfBox">
            <p class="pass-margin">Nuvarande lösenord: 
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" 
                controltovalidate="txtOldPassword" 
                runat="server" ForeColor="Red" 
                Font-Size="Smaller" 
                ErrorMessage="Fyll i ditt nuvarande lösenord." 
                ValidationGroup="passGroup">
            </asp:RequiredFieldValidator></p>
            <asp:TextBox CssClass="my-txt-box pass-margin" ID="txtOldPassword" TextMode="Password" runat="server"></asp:TextBox>
            <p class="pass-margin">Nytt lösenord: 
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator2" 
                controltovalidate="txtNewPasswordOne" 
                runat="server" ForeColor="Red" 
                Font-Size="Smaller" 
                ErrorMessage="Fyll i ett nytt lösenord" 
                ValidationGroup="passGroup">
            </asp:RequiredFieldValidator></p>
            <asp:TextBox CssClass="my-txt-box pass-margin" ID="txtNewPasswordOne" TextMode="Password" runat="server"></asp:TextBox>
            <p class="pass-margins">Bekräfta nytt lösenord: <span class="pass-error-msg">Lösenord stämmer inte överens</span>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator3" 
                controltovalidate="txtNewPasswordTwo" 
                runat="server" 
                ForeColor="Red" 
                Font-Size="Smaller" 
                ErrorMessage="Bekräfta lösenord" 
                ValidationGroup="passGroup">
            </asp:RequiredFieldValidator> </p>
            <asp:TextBox CssClass="my-txt-box pass-margin" ID="txtNewPasswordTwo" TextMode="Password" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CssClass="my-button pass-margin" Text="BYT LÖSENORD" ValidationGroup="passGroup" OnCLick="Button1_Click"/>
        </div>
    </div>

        <!-- RUTA FÖR ÄNDRAT LÖSENORD   ================================================== -->
    <div class="page-overlay-password-change">
      <div class="overlay-message">
          <p class="my-glyph-close"><span class="glyphicon glyphicon-remove pull-right " onclick="closeOverlayPasswordChange();"></span></p>
          <h3 class="my-h3" id="PwResultText" runat="server">Ditt lösenord har ändrats</h3>  
         <asp:Button ID="OK" runat="server" Text="OK" CssClass="my-button top-n-bottom-space" OnClientClick="closeOverlayPasswordChange();"/>     
      </div>
    </div>

</asp:Content>

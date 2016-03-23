<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Medlemsregister.aspx.cs" Inherits="Team_1_Halslaget_GK.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link type="text/css" rel="stylesheet" href="css/Medlemsregister.css"/>
    <script src="ja/memberRegScript.js"></script>
    <script>
        function openConfirmMessage() {
            var confirmed = document.getElementById('ContentPlaceHolder1_lblSavedConfirmed').innerText;

            if (confirmed == "T") {
                document.getElementById('ContentPlaceHolder1_lblConfirmed').innerText = "Uppgifterna sparades.";
                $('.page-overlay-saved').fadeIn('slow').delay(2000);;
                $('.page-overlay-saved').fadeOut('slow');
            }
            else
            {
                document.getElementById('ContentPlaceHolder1_lblConfirmed').innerText = "Uppgifterna sparades inte. Något gick fel.";
                $('.page-overlay-saved').fadeIn('slow').delay(2000);;
                $('.page-overlay-saved').fadeOut('slow');
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- Overlay/modal to delete member ================================================== -->
    <div class="page-overlay-delete-member">
      <div class="overlay-message-delete">
          <p class="my-glyph-close"><span class="glyphicon glyphicon-remove pull-right " onclick="closeOverlayDeleteMember();"></span></p>
            <h3 class="my-h3 center-text">RADERA MEDLEM</h3>  
            <p class="memberreg-1em-margin-horizontal"><strong>Du håller på att radera nedanstående medlem:</strong></p>
            <p><strong>Medlems ID: </strong><asp:Label ID="lblMemberID" runat="server" Text="Label"></asp:Label></p>
            <p><strong>Förnamn: </strong><asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label></p>
            <p><strong>Efternamn: </strong><asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label></p>
            <div class="fullBox">
                <p class="center-text memberreg-1em-margin-horizontal">Är du säker på att du vill radera medlem?</p>
            </div>
            <div class="fullBox">
                <div class="halfBox">
                    <asp:Button ID="ButtonRadera" runat="server" CssClass="my-button" Text="JA" Visible ="true" OnClick="ButtonRadera_Click"/>   
                </div>  
                <div class="halfBox">
                    <a class="my-button btn-mobile-space" onclick="closeOverlayDeleteMember();">NEJ</a> 
                </div> 
            </div>   
          <p class="p-my-info-modal">.</p>
      </div>
    </div>
        <div class="page-overlay-saved">
      <div class="overlay-message-saved">
          <p class="my-glyph-close"><span class="glyphicon glyphicon-remove pull-right " onclick="closeOverlaySaved();"></span></p>
            <h3 class="my-h3 center-text">MEDDELANDE FRÅN WEBBSIDAN</h3>  
            <div class="fullBox">
                <p class="center-text memberreg-1em-margin-horizontal"><asp:Label ID="lblConfirmed" runat="server" Text="Label"></asp:Label></p>
            </div>  
            <div class="fullBox">
                <a class="my-button btn-mobile-space" onclick="closeOverlaySaved();">OK</a> 
            </div> 
          <p class="p-my-info-modal">.</p>
      </div>
    </div>



 <!-- MAIN PAGE ================================================== -->
<div class="fullBox">
    <div class="fullBox page-title">
        <h2>MEDLEMSREGISTER</h2>
    </div>



<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
            <!-- Overlay/modal to to confirm member updated ================================================== -->


 <!--  MEDLEMSREGISTER ================================================== -->
    <div class="fullBox">
        <div class="halfBox">
            <div class="fullBox memberreg-page-title">
                <h3>MEDLEMMAR</h3>
            </div>
            <div class="fullBox">
                <p><strong>SORTERA</strong></p>
                <asp:RadioButtonList ID="RadioButtonListSortera" runat="server" CssClass="radiobuttons" OnSelectedIndexChanged="RadioButtonListSortera_OnSelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal">
                    <asp:ListItem Text ="ID"></asp:ListItem>
                    <asp:ListItem Text ="Förnamn"></asp:ListItem>
                    <asp:ListItem Text ="Efternamn"></asp:ListItem>
                    <asp:ListItem Text="Handikapp"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="fullBox medlemsregister">
                <asp:ListBox ID="ListBoxMedlemsregister" runat="server" CssClass="listbox-style" AutoPostBack ="true" OnSelectedIndexChanged="ListBoxMedlemsregister_SelectedIndexChanged"></asp:ListBox>
            </div>
            <div class="fullBox">
                <div class="fullBox memberreg-1em-margin-horizontal">
                    <p><strong>SÖK PÅ MEDLEM</strong></p>
                </div>
                <div class="halfBox">
                    <p>FÖRNAMN:</p>
                    <asp:TextBox ID="TextBoxFornamnSok" CssClass="my-txt-box member-txt-box" runat="server" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="halfBox ">                
                    <p>EFTERNAMN: </p>
                    <asp:TextBox ID="TextBoxEfternamnSok" CssClass="my-txt-box member-txt-box" runat="server"></asp:TextBox>
                </div>
                <div class="fullBox memberreg-1em-margin-horizontal">
                    <asp:Button ID="ButtonSearch" CssClass="my-button" runat="server" Text="Sök" OnClick="ButtonSearch_Click"/>
                </div>  
            </div>
        </div>
 <!-- MEDLEMSUPPGIFTER ================================================== -->
        <div class="halfBox">
            <div class="fullBox memberreg-page-title">
                <h3>MEDLEMSUPPGIFTER</h3>
            </div>
            <div class="fullBox member-1em-margin-lat">
                <p class="memberreg-1em-margin-horizontal">Medlems ID: <strong><asp:Label ID="lblMedlemsID" runat="server" Text="0"></asp:Label></strong></p> 
                <p class="memberreg-1em-margin-horizontal">Förnamn: </p>
                <asp:TextBox ID="TextBoxFornamn" CssClass="my-txt-box member-txt-box"  runat="server" Visible="true"></asp:TextBox>
                <p class="memberreg-1em-margin-horizontal">Efternamn: </p>
                <asp:TextBox ID="TextBoxEfternamn" CssClass="my-txt-box member-txt-box"  runat="server" Visible="true"></asp:TextBox>
                <p class="memberreg-1em-margin-horizontal">Email: </p>
                <asp:TextBox ID="TextBoxEmail" CssClass="my-txt-box member-txt-box"  runat="server" Visible="true"></asp:TextBox>
                <p class="memberreg-1em-margin-horizontal">Telefonnummer: </p>
                <asp:TextBox ID="TextBoxTelefonNummer" CssClass="my-txt-box member-txt-box"  runat="server"></asp:TextBox>
                <p class="memberreg-1em-margin-horizontal">Gata: </p>
                <asp:TextBox ID="TextBoxAdress" CssClass="my-txt-box member-txt-box"  runat="server" Visible="true"></asp:TextBox> 
                <p class="memberreg-1em-margin-horizontal">Postnummer: </p>
                <asp:TextBox ID="TextBoxPostnummer" CssClass="my-txt-box member-txt-box"  runat="server" Visible="true"></asp:TextBox>
                <p class="memberreg-1em-margin-horizontal">Ort: </p>
                <asp:TextBox ID="TextBoxOrt" CssClass="my-txt-box member-txt-box"  runat="server" Visible="true"></asp:TextBox>
                <p class="memberreg-1em-margin-horizontal">Handikapp: </p>
                <asp:TextBox ID="TextBoxHandikapp" CssClass="my-txt-box member-txt-box"  runat="server" Visible="true"></asp:TextBox>
                <p class="memberreg-1em-margin-horizontal">Medlemsavgift betald: </p>
                <asp:DropDownList ID="dropDownPayStatus" CssClass="DropDown" runat="server">
                    <asp:ListItem>Ja</asp:ListItem>
                    <asp:ListItem>Nej</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fullBox memberreg-1em-margin-horizontal">
                <div class="halfBox btn-mobile-space">
                    <asp:Button ID="ButtonSpara" runat="server" CssClass="my-button " Text="SPARA" Visible="true" OnClick="ButtonSpara_Click"/>
                </div>
                <div class="halfBox btn-mobile-space">
                    <a class="my-button " id="btnOpenDeleteMemberModal" onclick="openOverlayDeleteMember();">RADERA</a>
                </div>
                <asp:Label ID="lblSavedConfirmed" runat="server" style="display:none;" Text=""></asp:Label>
            </div>
        </div>
    </div>

    </ContentTemplate>
</asp:UpdatePanel>

</div>

</asp:Content>
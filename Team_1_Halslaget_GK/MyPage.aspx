<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyPage.aspx.cs" Inherits="Team_1_Halslaget_GK.MyPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MyPage</title>
    <link type="text/css" rel="stylesheet" href="css/MyPageCss.css"/> 
    <script src="ja/MyPageScripts.js"></script>
<script type="text/javascript">

</script>  
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="pagecontainer">

    <!-- OVerlay/Modal to edit user info ================================================== -->
    <div class="page-overlay-edit-info">
      <div class="overlay-message">
          <p class="my-glyph-close"><span class="glyphicon glyphicon-remove pull-right " onclick="closeOverlayEditInfo();"></span></p>
          <h3 class="my-h3">REDIGERA DINA UPPGIFTER</h3>  
          <div class="halfBox">
              <p class="p-my-info-modal"><strong>Förnamn:</strong></p>
              <asp:TextBox ID="txtFirstName" runat="server" CssClass="my-txt-box"></asp:TextBox>
             <p class="p-my-info-modal"><strong>Efternam:</strong></p>
             <asp:TextBox ID="txtLastName" runat="server" CssClass="my-txt-box"></asp:TextBox>
              <p class="p-my-info-modal"><strong>Telefonnummer:</strong> </p>
             <asp:TextBox ID="txtPhoneNum" runat="server" CssClass="my-txt-box"></asp:TextBox>
             <p class="p-my-info-modal"><strong>Email:</strong></p>
             <asp:TextBox ID="txtEmail" runat="server" CssClass="my-txt-box"></asp:TextBox>
           </div>   
          <div class="halfBox">
                <p class="p-my-info-modal"><strong>Gata:</strong> </p>
              <asp:TextBox ID="txtStreet" runat="server"  CssClass="my-txt-box"></asp:TextBox>
                <p class="p-my-info-modal"><strong>Postkod:</strong></p>
              <asp:TextBox ID="txtPostalCode" runat="server"  CssClass="my-txt-box"></asp:TextBox>
                <p class="p-my-info-modal"><strong>Stad:</strong> </p>
              <asp:TextBox ID="txtCity" runat="server"  CssClass="my-txt-box"></asp:TextBox>
          </div>
         <asp:Button ID="btnUpdateUserinfo" runat="server" Text="SPARA OCH STÄNG" CssClass="my-button top-n-bottom-space" OnClick="btnUpdateUserinfo_Click"/>     
      </div>
    </div>
   <!-- Overlay/modal to cancel booking ================================================== -->
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
    <div class="page-overlay-cancel-booking">
      <div class="overlay-message-booking">
          <p class="my-glyph-close"><span class="glyphicon glyphicon-remove pull-right " onclick="closeCancelBookingOverlay();"></span></p>
            <h3 class="my-h3">AVBOKA</h3>  
            <p class="p-my-info-modal"><strong>Du håller på att avboka följande tid:</strong></p>
            <p class="p-my-info-modal"><strong>Bokningsnummer: </strong><asp:Label ID="lblBookingID" runat="server" Text="Label"></asp:Label></p>
            <p class="p-my-info-modal"><strong>Datum: </strong><asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label></p>
            <p class="p-my-info-modal"><strong>Starttid: </strong><asp:Label ID="lblStartTime" runat="server" Text="Label"></asp:Label></p>
            <div class="fullBox">
                <p class="p-my-info-modal center-text">Är du säker på att du vill avboka?</p>
            </div>
            <div class="fullBox">
                <div class="halfBox">
                    <asp:Button ID="btnConfirmCancelBooking" runat="server" Text="JA" CssClass="my-button btn-mobile-space" OnClick="btnCancelBooking_Click"/>   
                </div>  
                <div class="halfBox">
                    <a class="my-button btn-mobile-space" onclick="closeCancelBookingOverlay();">NEJ</a> 
                </div> 
            </div>   
          <p class="p-my-info-modal">.</p>
      </div>
    </div>
    </ContentTemplate>
   </asp:UpdatePanel>
   <!-- MAIN PAGE================================================== -->
    <div class="fullBox page-title">
        <h1>MIN SIDA</h1>
    </div>
    <div class="fullBox top-n-bottom-space">
        <h2>Välkommen <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label></h2>
        <p>Välkommen till din personliga sida här hos Hålslaget GK! Här kan du hitta information om dina kommande bokningar, ditt nuvarande handikapp, dina tidigare bokning
            samt ändra din personliga information. Har du några frågor eller funderingar är du varmt välkommen till att kontakta hos på Hålsaget GK!
        </p>
    </div>
   <!-- USER BOOKED TIMES ================================================== -->
    <div class="fullBox top-n-bottom-space">
        <div class="halfBox my-page-half-box">
            <div class="fullBox my-page-title">
                <h3>MINA BOKADE TIDER</h3>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="fullBox">            
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="Grid" GridLines="None" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                            <Columns>
                                    <asp:BoundField DataField="bokningsnr" HeaderText="Boknings Nr" SortExpression="id" />
                                    <asp:BoundField DataField="datum" HeaderText="Datum" DataFormatString="{0:dd-MM-yyyy}" SortExpression="date" />
                                    <asp:BoundField DataField="starttid" HeaderText="Starttid" DataFormatString="{0:HH:mm}" SortExpression="starttime" />
                                    <asp:CommandField ShowSelectButton="true" />
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblTempBookingID" runat="server" Text="Empty" style="display:none;"></asp:Label>
                        <asp:Label ID="lblTempDate" runat="server" Text="Empty" style="display:none;"></asp:Label>
                        <asp:Label ID="lblTempStartTime" runat="server" Text="Empty" style="display:none;"></asp:Label>           
                    </div>
                    <div class="fullBox center-text">
                        <br />
                        <p class="p-my-info" id="CancelBookingInfo" runat="server">För att avboka en tid, klicka på markera och sedan på knappen "Avboka tid"</p>
                        <br />
                        <div class="halfBox">
                            <asp:Button ID="btnGoToBooking" runat="server" Text="BOKA TIDER" CssClass="my-button" OnClick="btnGoToBooking_Click"/>
                        </div>
                        <div class="halfBox">
                            <a id="btnCancelBooking" class="my-button btn-mobile-space" title="Välj tid för att kunna avboka." onclick="openCancelBookingOverlay();">AVBOKA TID</a>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
       <!-- USER STATISTICS ================================================== -->
        <div class="halfBox my-page-half-box">
            <div class="fullBox">
                <div class="fullBox my-page-title">
                    <h3>SPELSTATISTIK</h3>
                </div>
            </div>
            <div class="fullbox center-text">
                <p class="p-my-game"><strong>Ditt nuvarande handikapp är:</strong> <asp:Label ID="lblCurrentHandicap" runat="server" Text="Label"></asp:Label>.</p>
                <p class="p-my-game"><strong>Du har spelat</strong> <asp:Label ID="lblAmountOfRounds" runat="server" Text="Label"></asp:Label> <strong>rundor.</strong></p>
                <p class="p-my-game"><asp:Label ID="lblPaymentReminder" runat="server" Text="Label" Visible="false"></asp:Label></p>

            </div>

    </div>
   <!-- USER INFO ================================================== -->
    <div class="fullBox top-n-bottom-space">

           <!-- TÄVLINGS INFO ================================================== -->
            <div class="halfBox my-page-half-box">
                <div class="fullBox">
                    <div class="fullBox my-page-title">
                        <h3>MINA KOMMANDE TÄVLINGAR </h3>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="fullBox">            
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="Grid" GridLines="None" DataKeyNames="id">
                                <Columns>
                                        <asp:BoundField DataField="namn" HeaderText="Namn" SortExpression="name" />
                                        <asp:BoundField DataField="datum" HeaderText="Datum" DataFormatString="{0:dd-MM-yyyy}" SortExpression="date" />
                                        <asp:BoundField DataField="starttid" HeaderText="Starttid" DataFormatString="{0:HH:mm}" SortExpression="starttime" />
                                </Columns>
                            </asp:GridView>          
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        <div class="halfBox my-page-half-box">
            <div class="fullBox" >
                <div class="fullBox my-page-title">
                    <h3>DAGBOK & MEDDELANDEN</h3>
                </div>
                <div class="fullBox center-text" style="margin-top: 2em; margin-bottom: 1em;">
                    <asp:Button ID="btnGoToMessenger" CssClass="my-button" runat="server" Text=" GÅ TILL MEDDELANDEN" OnClick="btnGoToMessenger_Click" />
                </div>
                <div class="fullBox center-text">
                    <p style="margin-top: 2em; margin-bottom: 1em;"><strong>Du har skrivit </strong> <asp:Label ID="lblDiary" runat="server" Text=""></asp:Label> <strong>dagboksinlägg.</strong></p>
                </div>
                <div class="halfBox">
                    <asp:Button ID="btnGoToDiary" CssClass="my-button" runat="server" Text="TILL DAGBOKEN" OnClick="btnGoToDiary_Click" />
                </div>  
                <div class="halfBox">
                    <asp:Button ID="btnNewNote" CssClass="my-button" runat="server" Text="NYTT INLÄGG" OnClick="btnNewNote_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="fullBox top-n-bottom-space">
        <div class="fullBox my-page-title">
            <h3>MINA UPPGIFTER</h3>
        </div>
        <div class="fullBox">
            <div class="halfBox my-page-half-box">
                <p class="p-my-info"><strong>Förnamn:</strong> <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label></p>
                <p class="p-my-info"><strong>Efternam:</strong> <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label></p>
                <p class="p-my-info"><strong>Telefonnummer:</strong> <asp:Label ID="lblPhoneNum" runat="server" Text="Label"></asp:Label></p>
                <p class="p-my-info"><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></p>
            </div>
            <div class="halfBox my-page-half-box">
                <p class="p-my-info"><strong>Gata:</strong> <asp:Label ID="lblStreet" runat="server" Text="Label"></asp:Label></p>
                <p class="p-my-info"><strong>Postkod:</strong> <asp:Label ID="lblPostalCode" runat="server" Text="Label"></asp:Label></p>
                <p class="p-my-info"><strong>Stad:</strong> <asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label></p>
                <p class="p-my-info" style="display:none;"><strong>ID:</strong> <asp:Label ID="lblMemberID" runat="server" Text="Label"></asp:Label></p>
            </div>
        </div>
        <div class="fullBox top-n-bottom-space">
            <div class="halfBox my-page-half-box">
                    <a class="my-button" title="Klicka här för att redigera din uppgifter, en ny ruta öppnas." onclick="openOverlayEditInfo();">REDIGERA UPPGIFTER</a>
             </div>
        </div>
    </div>
   <!-- ACCOUNT SETTINGS ================================================== -->
    <div class="fullBox top-n-bottom-space">
        <div class="fullBox page-title">
            <h3>KONTOINSTÄLLNINGAR</h3>
        </div>
        <div class="fullBox ">
                <div class="fullBox">
                    <p class="p-my-info">Vill du ändra ditt lösenord? Klicka på knappen nedanför.</p>
                </div>
                <div class="halfBox top-n-bottom-space">
                    <asp:Button CssClass="my-button" ID="btnGoToAccountSettings" runat="server" Text="ÄNDRA LÖSENORD" OnClick="btnGoToAccountSettings_Click"/>
                </div>
        </div>
    </div>
<%--    <!-- LAST COMPETITION -->
        <div class="fullBox top-n-bottom-space">
        <div class="fullBox page-title">
            <h3>SENASTE TÄVLINGEN</h3>
        </div>
        <div class="fullBox ">
                <div class="fullBox">
                    <asp:Label ID="labelCompetitionName" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="labelCompetitionResult" runat="server" Text="Label"></asp:Label><br />
                </div>
        </div>
    </div>
</div>--%>
</asp:Content>

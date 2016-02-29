﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyPage.aspx.cs" Inherits="Team_1_Halslaget_GK.MyPage" %>

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
          <asp:Button ID="btnUpdateUserinfo" runat="server" Text="SPARA OCH STÄNG" CssClass="my-button top-n-bottom-space"/>                 
      </div>
    </div>

    <!-- Overlay/modal to cancel booking ================================================== -->
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
                    <asp:Button ID="Button2" runat="server" Text="JA" CssClass="my-button btn-mobile-space"/>   
                </div>  
                <div class="halfBox">
                    <a class="my-button btn-mobile-space" onclick="closeCancelBookingOverlay();">NEJ</a> 
                </div> 
            </div>   
          <p class="p-my-info-modal">.</p>
      </div>
    </div>


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
        <div class="halfBox">
            <div class="fullBox my-page-title">
                <h3>MINA BOKADE TIDER</h3>
            </div>


                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
            <div class="fullBox">            
                <!--<asp:ListView ID="ListViewFutureTeeTimes" runat="server" OnSelectedIndexChanged="ListViewFutureTeeTimes_SelectedIndexChanged">
                    <ItemTemplate>
                        <br />
                        <p class="p-my-page">
                            <strong>Datum: </strong><asp:Label ID="lblFutureTeeDate" runat="server" Text='<%# Eval("date", "{0:dd-MM-yyyy}") %>'></asp:Label>
                            <strong>Starttid: </strong><asp:Label ID="lblFutureTeeStartTime" runat="server" Text='<%# Eval("starttime", "{0:HH:mm}") %>'></asp:Label>
                            <strong>Boknings Nr: </strong><asp:Label ID="lblFutureTeeID" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                            <p class="p-my-page pull-right">
                                <asp:Label ID="Label1" runat="server" OnClientClick="openCancelBookingOverlay();" Text="Avboka"></asp:Label>
                            <br />
                            <asp:LinkButton ID="LinkButton1" OnClientClick="openCancelBookingOverlay();" runat="server">LinkButton</asp:LinkButton>
                            <br />
                        </p>
                    </ItemTemplate>
                </asp:ListView>-->

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="Grid" GridLines="None" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                            <asp:BoundField DataField="id" HeaderText="Boknings Nr" SortExpression="id" />
                            <asp:BoundField DataField="date" HeaderText="Datum" DataFormatString="{0:dd-MM-yyyy}" SortExpression="date" />
                            <asp:BoundField DataField="starttime" HeaderText="Starttid" DataFormatString="{0:HH:mm}" SortExpression="starttime" />
                            <asp:CommandField ShowSelectButton="true" />
                    </Columns>
                </asp:GridView>
                        <asp:Label ID="lblTempBookingID" runat="server" Text="Empty" style="display:none;"></asp:Label>
                        <asp:Label ID="lblTempDate" runat="server" Text="Empty" style="display:none;"></asp:Label>
                        <asp:Label ID="lblTempStartTime" runat="server" Text="Empty" style="display:none;"></asp:Label>           

            </div>

            <div class="fullBox center-text">
                <br />
                <p class="p-my-info">För att avboka en tid, klicka på markera och sedan på knappen "Avboka tid"</p>
                <br />
                <div class="halfBox">
                    <asp:Button ID="btnGoToBooking" runat="server" Text="BOKA TIDER" CssClass="my-button"/>
                </div>
                <div class="halfBox">
                    <a id="btnCancelBooking" class="my-button btn-mobile-space" title="Välj tid för att kunna avboka." onclick="openCancelBookingOverlay();">AVBOKA TID</a>
                </div>
            </div>
                            </ContentTemplate>
                </asp:UpdatePanel>
        </div>


        <!-- USER STATISTICS ================================================== -->
        <div class="halfBox">
            <div class="fullBox">
                <div class="fullBox my-page-title">
                    <h3>SPELSTATISTIK</h3>
                </div>
            </div>
            <div class="fullbox center-text">
                <p class="p-my-game"><strong>Ditt nuvarande handikapp är:</strong> <asp:Label ID="lblCurrentHandicap" runat="server" Text="Label"></asp:Label>.</p>
                <p class="p-my-game"><strong>Du har spelat</strong> <asp:Label ID="lblAmountOfRounds" runat="server" Text="Label"></asp:Label> <strong>rundor.</strong></p>
            </div>
        </div>
    </div>

    <!-- USER INFO ================================================== -->
    <div class="fullBox top-n-bottom-space">
        <div class="fullBox page-title">
            <h3>DINA UPPGIFTER</h3>
        </div>
        <div class="fullBox ">
            <div class="halfBox">
                <p class="p-my-info"><strong>Förnamn:</strong> <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label></p>
                <p class="p-my-info"><strong>Efternam:</strong> <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label></p>
                <p class="p-my-info"><strong>Telefonnummer:</strong> <asp:Label ID="lblPhoneNum" runat="server" Text="Label"></asp:Label></p>
                <p class="p-my-info"><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></p>

            </div>
            <div class="halfBox">
                <p class="p-my-info"><strong>Gata:</strong> <asp:Label ID="lblStreet" runat="server" Text="Label"></asp:Label></p>
                <p class="p-my-info"><strong>Postkod:</strong> <asp:Label ID="lblPostalCode" runat="server" Text="Label"></asp:Label></p>
                <p class="p-my-info"><strong>Stad:</strong> <asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label></p>
            </div>
            <div class="fullBox top-n-bottom-space">
                <div class="halfBox">
                    <a class="my-button" title="Klicka här för att redigera din uppgifter, en ny ruta öppnas." onclick="openOverlayEditInfo();">REDIGERA UPPGIFTER</a>
                </div>
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
                    <asp:Button CssClass="my-button" ID="btnGoToAccountSettings" runat="server" Text="ÄNDRA LÖSENORD" />
                </div>
        </div>
    </div>
</div>
</asp:Content>
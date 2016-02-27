<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyPage.aspx.cs" Inherits="Team_1_Halslaget_GK.MyPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MyPage</title>
    <link type="text/css" rel="stylesheet" href="css/MyPageCss.css"/> 
    <script src="ja/testscript.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="pagecontainer">

    <!-- OVerlay/Modal to edit user info ================================================== -->
    <div class="page-overlay-edit-info">
      <div class="overlay-message">
          <p class="my-glyph-close"><span class="glyphicon glyphicon-remove pull-right " onclick="closeOverlay();"></span></p>
          <h3 class="my-h3">REDIGERA DINA UPPGIFTER</h3>  
          <div class="halfBox">
              <p class="p-my-info-modal"><strong>Förnamn:</strong></p>
              <asp:TextBox ID="TextBox1" runat="server" CssClass="my-txt-box"></asp:TextBox>
             <p class="p-my-info-modal"><strong>Efternam:</strong></p>
             <asp:TextBox ID="TextBox2" runat="server" CssClass="my-txt-box"></asp:TextBox>
              <p class="p-my-info-modal"><strong>Telefonnummer:</strong> </p>
             <asp:TextBox ID="TextBox3" runat="server" CssClass="my-txt-box"></asp:TextBox>
             <p class="p-my-info-modal"><strong>Email:</strong></p>
             <asp:TextBox ID="TextBox4" runat="server" CssClass="my-txt-box"></asp:TextBox>
           </div>   
          <div class="halfBox">
                <p class="p-my-info-modal"><strong>Gata:</strong> </p>
              <asp:TextBox ID="TextBox5" runat="server"  CssClass="my-txt-box"></asp:TextBox>
                <p class="p-my-info-modal"><strong>Postkod:</strong></p>
              <asp:TextBox ID="TextBox6" runat="server"  CssClass="my-txt-box"></asp:TextBox>
                <p class="p-my-info-modal"><strong>Stad:</strong> </p>
              <asp:TextBox ID="TextBox7" runat="server"  CssClass="my-txt-box"></asp:TextBox>
          </div>
          <asp:Button ID="Button1" runat="server" Text="SPARA OCH STÄNG" CssClass="my-button top-n-bottom-space"/>                 
      </div>
    </div>

    <!-- Overlay/modal to cancel booking ================================================== -->
    <div class="page-overlay-cancel-booking">
      <div class="overlay-message-booking">
          <p class="my-glyph-close"><span class="glyphicon glyphicon-remove pull-right " onclick="closeCancelBookingOverlay();"></span></p>
            <h3 class="my-h3">AVBOKA</h3>  
            <p class="p-my-info-modal"><strong>Du håller nu på att göra en avbokning av:</strong></p>
          <asp:Button ID="Button2" runat="server" Text="SPARA OCH STÄNG" CssClass="my-button top-n-bottom-space"/>                 
      </div>
    </div>

    <div class="fullBox page-title">
        <h1>MIN SIDA</h1>
    </div>
    <div class="fullBox top-n-bottom-space">
        <h2>Välkommen <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label></h2>
        <p>Välkommen till din personliga sida här hos Hålslaget GK! Här kan du hitta information om dina kommande bokningar, ditt nuvarande handikapp, dina tidigare bokning
            samt ändra din personliga information. Har du några frågor eller funderingar är du varmt välkommen till att kontakta hos på Hålsaget GK!
        </p>
    </div>
    <div class="fullBox top-n-bottom-space">
        <div class="halfBox">
            <div class="fullBox my-page-title">
                <h3>Mina bokade tider</h3>
            </div>
            <div class="fullBox">            
                <asp:ListView ID="ListViewFutureTeeTimes" runat="server">
                    <ItemTemplate>
                        <br />
                        <p class="p-my-page">
                            <strong>Datum: </strong><asp:Label ID="lblFutureTeeDate" runat="server" Text='<%# Eval("date", "{0:dd-MM-yyyy}") %>'></asp:Label>
                            <strong>Starttid: </strong><asp:Label ID="lblFutureTeeStartTime" runat="server" Text='<%# Eval("starttime", "{0:HH:mm}") %>'></asp:Label>
                            <strong>Boknings Nr: </strong><asp:Label ID="lblFutureTeeID" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                            <!--<asp:Label ID="lblFutureEmptyMessage" runat="server" Text="Label"></asp:Label>-->
                            <p class="p-my-page pull-right"><a onclick="openCancelBookingOverlay();">Avboka</a></p>
                            <br />
                            <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
                            <br />
                        </p>
                    </ItemTemplate>
                </asp:ListView>
            </div>

            <div class="fullBox center-text">
                <br />
                <asp:Button ID="btnGoToBooking" runat="server" Text="BOKA TIDER" CssClass="my-button"/>
            </div>
        </div>
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
                    <a class="my-button" onclick="testClick();">REDIGERA UPPGIFTER</a>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>

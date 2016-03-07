﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Tidsbokning.aspx.cs" Inherits="Team_1_Halslaget_GK.Tidsbokning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/tidsbokning.css" rel="stylesheet" />
    <script src="ja/tidsbokning.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox page-title">
        <h1>Tidsbokning</h1>
    </div>
    <div class="fullBox">
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
    </div>
    <div>
      <div class="fullBox">
        <asp:Table ID="Table1" CssClass="timeTable" runat="server">
            <asp:TableRow ID="Row1" runat="server">
                <asp:TableCell runat="server"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton_Click">07:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton_Click">07:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton_Click">07:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton_Click">07:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton_Click">07:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton_Click">07:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton_Click">08:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton_Click">08:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton_Click">08:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton_Click">08:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButton_Click">08:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButton_Click">08:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton13" runat="server" OnClick="LinkButton_Click">09:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton14" runat="server" OnClick="LinkButton_Click">09:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton15" runat="server" OnClick="LinkButton_Click">09:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton16" runat="server" OnClick="LinkButton_Click">09:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton17" runat="server" OnClick="LinkButton_Click">09:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton18" runat="server" OnClick="LinkButton_Click">09:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton19" runat="server" OnClick="LinkButton_Click">10:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton20" runat="server" OnClick="LinkButton_Click">10:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton21" runat="server" OnClick="LinkButton_Click">10:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton22" runat="server" OnClick="LinkButton_Click">10:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton23" runat="server" OnClick="LinkButton_Click">10:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton24" runat="server" OnClick="LinkButton_Click">10:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton25" runat="server" OnClick="LinkButton_Click">11:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton26" runat="server" OnClick="LinkButton_Click">11:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton27" runat="server" OnClick="LinkButton_Click">11:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton28" runat="server" OnClick="LinkButton_Click">11:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton29" runat="server" OnClick="LinkButton_Click">11:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton30" runat="server" OnClick="LinkButton_Click">11:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton31" runat="server" OnClick="LinkButton_Click">12:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton32" runat="server" OnClick="LinkButton_Click">12:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton33" runat="server" OnClick="LinkButton_Click">12:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton34" runat="server" OnClick="LinkButton_Click">12:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton35" runat="server" OnClick="LinkButton_Click">12:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton36" runat="server" OnClick="LinkButton_Click">12:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton37" runat="server" OnClick="LinkButton_Click">13:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton38" runat="server" OnClick="LinkButton_Click">13:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton39" runat="server" OnClick="LinkButton_Click">13:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton40" runat="server" OnClick="LinkButton_Click">13:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton41" runat="server" OnClick="LinkButton_Click">13:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton42" runat="server" OnClick="LinkButton_Click">13:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton43" runat="server" OnClick="LinkButton_Click">14:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton44" runat="server" OnClick="LinkButton_Click">14:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton45" runat="server" OnClick="LinkButton_Click">14:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton46" runat="server" OnClick="LinkButton_Click">14:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton47" runat="server" OnClick="LinkButton_Click">14:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton48" runat="server" OnClick="LinkButton_Click">14:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton49" runat="server" OnClick="LinkButton_Click">15:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton50" runat="server" OnClick="LinkButton_Click">15:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton51" runat="server" OnClick="LinkButton_Click">15:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton52" runat="server" OnClick="LinkButton_Click">15:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton53" runat="server" OnClick="LinkButton_Click">15:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton54" runat="server" OnClick="LinkButton_Click">15:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton55" runat="server" OnClick="LinkButton_Click">16:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton56" runat="server" OnClick="LinkButton_Click">16:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton57" runat="server" OnClick="LinkButton_Click">16:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton58" runat="server" OnClick="LinkButton_Click">16:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton59" runat="server" OnClick="LinkButton_Click">16:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton60" runat="server" OnClick="LinkButton_Click">16:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton61" runat="server" OnClick="LinkButton_Click">17:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton62" runat="server" OnClick="LinkButton_Click">17:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton63" runat="server" OnClick="LinkButton_Click">17:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton64" runat="server" OnClick="LinkButton_Click">17:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton65" runat="server" OnClick="LinkButton_Click">17:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton66" runat="server" OnClick="LinkButton_Click">17:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>    
        </asp:Table>
    <div class="otherplayers">
        <asp:Label ID="lblPlayer1" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblPlayer2" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblPlayer3" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblPlayer4" runat="server" Text=""></asp:Label>
    </div>
          <div class="extraplayers">
              <asp:Label ID="LabelNOPlayers" runat="server" Text="Antal spelare"></asp:Label>
              <asp:DropDownList ID="DropDownListNOPlayers" runat="server" OnSelectedIndexChanged="DropDownListNOPlayers_SelectedIndexChanged" AutoPostBack="true"><asp:ListItem>1</asp:ListItem><asp:ListItem>2</asp:ListItem><asp:ListItem>3</asp:ListItem><asp:ListItem>4</asp:ListItem></asp:DropDownList><br />
              <asp:Label ID="LabelPlayer1" runat="server" Text="GolfID spelare 1" Visible="false"></asp:Label>
              <asp:TextBox ID="TextBoxPlayer1" runat="server"  Visible="false"></asp:TextBox><br />
              <asp:Label ID="LabelPlayer2" runat="server" Text="GolfID spelare 2" Visible="false"></asp:Label>
              <asp:TextBox ID="TextBoxPlayer2" runat="server"  Visible="false"></asp:TextBox><br />
              <asp:Label ID="LabelPlayer3" runat="server" Text="GolfID spelare 3" Visible="false"></asp:Label>              
              <asp:TextBox ID="TextBoxPlayer3" runat="server"  Visible="false"></asp:TextBox><br />
              <asp:Label ID="LabelPlayer4" runat="server" Text="GolfID spelare 4" Visible="false"></asp:Label>              
              <asp:TextBox ID="TextBoxPlayer4" runat="server"  Visible="false"></asp:TextBox>
          </div>
    </div>
        
        <div id="confirmButtonDiv">
            <asp:Button ID="confirmBtn" runat="server" CssClass="my-button" Text="Boka" OnClick="confirmBtn_Click"/>
        </div>
    </div>    
<%--    Ruta för konfirmation och felmeddelanden--%>
    <div class="page-overlay-info-box">
      <div class="overlay-message">
          <p class="my-glyph-close"><span class="glyphicon glyphicon-remove pull-right " onclick="closeOverlayInfoBox();"></span></p>
          <h3 class="my-h3" id="BookingInfoText" runat="server">Ditt lösenord har ändrats</h3>  
         <asp:Button ID="OK" runat="server" Text="OK" CssClass="my-button top-n-bottom-space" OnClientClick="closeOverlayInfoBox();"/>     
      </div>
    </div>
</asp:Content>

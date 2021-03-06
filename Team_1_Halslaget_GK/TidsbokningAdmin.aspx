﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="TidsbokningAdmin.aspx.cs" Inherits="Team_1_Halslaget_GK.tidsbokningAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/tidsbokning.css" rel="stylesheet" />
    <script src="ja/tidsbokning.js"></script>
    <script src="ja/opencloseoverlay.js"></script>
    <script src="ja/hideShowSearch.js"></script>
    <style type="text/css">
        .modal
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            left: 0;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }
        .center
        {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }
        .center img
        {
            height: 128px;
            width: 128px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                    Laddar...
                    <img alt="" src="img/loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="fullBox page-title">
        <h2>Tidsbokning</h2>
    </div>
    <div class="halfBox calenderBox">
                <asp:Calendar ID="Calendar1" runat="server" CssClass="aspCalender" OnSelectionChanged="Calendar1_SelectionChanged1" OnDayRender="Calendar1_DayRender">  
                <DayStyle CssClass="CalenderDay" />
                <DayHeaderStyle CssClass="CalenderHeaderDay" />
                <NextPrevStyle CssClass="CalenderNextPrev" />
                <OtherMonthDayStyle CssClass="CalnderOtherMonthDay" />
                <SelectedDayStyle CssClass="CalenderSelectedDay" />
                <SelectorStyle CssClass="CalenderSelector" />
                <TitleStyle CssClass="CalenderTitel" />
                <TodayDayStyle CssClass="CalenderToday" />
                <WeekendDayStyle CssClass="CalenderWeekendDay" />             
                </asp:Calendar>
    </div>    
      <div class="halfBox calenderBox">
          <asp:Table ID="Table1" runat="server" CssClass="timeTable">
            <asp:TableRow ID="Row1" runat="server">
                <asp:TableCell><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">07:00</asp:LinkButton></asp:TableCell>               
                <asp:TableCell><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click">07:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton1_Click">07:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton1_Click">07:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton1_Click">07:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton1_Click">07:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton1_Click">08:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton1_Click">08:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton1_Click">08:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton1_Click">08:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButton1_Click">08:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButton1_Click">08:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton13" runat="server" OnClick="LinkButton1_Click">09:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton14" runat="server" OnClick="LinkButton1_Click">09:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton15" runat="server" OnClick="LinkButton1_Click">09:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton16" runat="server" OnClick="LinkButton1_Click">09:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton17" runat="server" OnClick="LinkButton1_Click">09:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton18" runat="server" OnClick="LinkButton1_Click">09:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton19" runat="server" OnClick="LinkButton1_Click">10:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton20" runat="server" OnClick="LinkButton1_Click">10:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton21" runat="server" OnClick="LinkButton1_Click">10:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton22" runat="server" OnClick="LinkButton1_Click">10:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton23" runat="server" OnClick="LinkButton1_Click">10:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton24" runat="server" OnClick="LinkButton1_Click">10:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton25" runat="server" OnClick="LinkButton1_Click">11:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton26" runat="server" OnClick="LinkButton1_Click">11:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton27" runat="server" OnClick="LinkButton1_Click">11:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton28" runat="server" OnClick="LinkButton1_Click">11:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton29" runat="server" OnClick="LinkButton1_Click">11:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton30" runat="server" OnClick="LinkButton1_Click">11:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton31" runat="server" OnClick="LinkButton1_Click">12:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton32" runat="server" OnClick="LinkButton1_Click">12:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton33" runat="server" OnClick="LinkButton1_Click">12:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton34" runat="server" OnClick="LinkButton1_Click">12:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton35" runat="server" OnClick="LinkButton1_Click">12:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton36" runat="server" OnClick="LinkButton1_Click">12:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton37" runat="server" OnClick="LinkButton1_Click">13:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton38" runat="server" OnClick="LinkButton1_Click">13:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton39" runat="server" OnClick="LinkButton1_Click">13:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton40" runat="server" OnClick="LinkButton1_Click">13:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton41" runat="server" OnClick="LinkButton1_Click">13:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton42" runat="server" OnClick="LinkButton1_Click">13:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton43" runat="server" OnClick="LinkButton1_Click">14:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton44" runat="server" OnClick="LinkButton1_Click">14:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton45" runat="server" OnClick="LinkButton1_Click">14:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton46" runat="server" OnClick="LinkButton1_Click">14:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton47" runat="server" OnClick="LinkButton1_Click">14:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton48" runat="server" OnClick="LinkButton1_Click">14:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton49" runat="server" OnClick="LinkButton1_Click">15:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton50" runat="server" OnClick="LinkButton1_Click">15:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton51" runat="server" OnClick="LinkButton1_Click">15:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton52" runat="server" OnClick="LinkButton1_Click">15:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton53" runat="server" OnClick="LinkButton1_Click">15:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton54" runat="server" OnClick="LinkButton1_Click">15:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton55" runat="server" OnClick="LinkButton1_Click">16:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton56" runat="server" OnClick="LinkButton1_Click">16:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton57" runat="server" OnClick="LinkButton1_Click">16:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton58" runat="server" OnClick="LinkButton1_Click">16:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton59" runat="server" OnClick="LinkButton1_Click">16:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton60" runat="server" OnClick="LinkButton1_Click">16:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:LinkButton ID="LinkButton61" runat="server" OnClick="LinkButton1_Click">17:00</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton62" runat="server" OnClick="LinkButton1_Click">17:10</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton63" runat="server" OnClick="LinkButton1_Click">17:20</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton64" runat="server" OnClick="LinkButton1_Click">17:30</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton65" runat="server" OnClick="LinkButton1_Click">17:40</asp:LinkButton></asp:TableCell>
                <asp:TableCell><asp:LinkButton ID="LinkButton66" runat="server" OnClick="LinkButton1_Click">17:50</asp:LinkButton></asp:TableCell>
            </asp:TableRow>    
        </asp:Table>
    </div>
    <div class="otherplayersbackground">
        <div class="otherplayers">          
            <asp:Button ID="Button1" runat="server" Text="X" CssClass="closebtn" OnClick="Button1_Click" />
            <asp:Label ID="lblotherplayers" CssClass="lblotherplayers" runat="server" Text=""></asp:Label><br /><br />
            <div id="hcpcheck" runat="server">
            <div class="fullBox players">
                    <asp:Label ID="lblPlayer1" CssClass="players" runat="server" Text=""></asp:Label>
                    <asp:Button ID="Removeplayer1Btn" CssClass="delete" runat="server" Text="x" OnClick="Removeplayer1Btn_Click" />
            </div>
            <div class="fullBox players">

                    <asp:Label ID="lblPlayer2" runat="server" Text=""></asp:Label>
                    <asp:Button ID="Removeplayer2Btn" CssClass="delete" runat="server" Text="x" OnClick="Removeplayer2Btn_Click" />
            </div>
            <div class="fullBox players">

                    <asp:Label ID="lblPlayer3" runat="server" Text=""></asp:Label>
                    <asp:Button ID="Removeplayer3Btn" CssClass="delete" runat="server" Text="x" OnClick="Removeplayer3Btn_Click" />
            </div>
            <div class="fullBox players">
                    <asp:Label ID="lblPlayer4" runat="server" Text=""></asp:Label>
                    <asp:Button ID="Removeplayer4Btn" CssClass="delete" runat="server" Text="x" OnClick="Removeplayer4Btn_Click" />
            </div>                                
            </div>
            <div class="fullBox HiddenSearchBox">
                    <div class="fullBox page-title"><h3>Sök på medlem</h3></div>    
                        <div class="halfBox">
                            <asp:Panel ID="Panel1" runat="server" DefaultButton="BtnSearchMember">                
                            <asp:TextBox ID="tbFullName" CssClass="my-txt-box" runat="server" placeholder="För och/eller efternamn"></asp:TextBox>                              
                            <asp:Button ID="BtnSearchMember" CssClass="my-button searchBtn" runat="server" Text="Sök" OnClick="BtnSearchMember_Click"/>                              
                        </asp:Panel> 
                    </div>
                <div class="halfBox">
                    <asp:Panel ID="Panel3" runat="server" DefaultButton="btnPickMember">                
                        <asp:ListBox ID="lbMembers" CssClass="my-list-box" runat="server" ></asp:ListBox>                               
                        <asp:Button ID="btnPickMember" CssClass="my-button" runat="server" Text="Lägg till" OnClick="btnPickMember_Click"/>                           
                    </asp:Panel>
                </div>
            </div>
                <asp:Button ID="ShowHiddenSearchDiv" CssClass="my-button" runat="server" Text="Sök på medlem" OnClick="ShowHiddenSearchDiv_Click" />
                <div id="otherplayers" runat="server" class="fullBox">
                    <div class="fullBox page-title"><h4><asp:Label ID="Label1" runat="server" Text="Fyll i golf-ID på de som du vill boka på den här tiden!"></asp:Label></h4></div>          
                    <asp:TextBox ID="tbPlayer1" runat="server" CssClass="my-txt-box" placeholder="Golf-id"></asp:TextBox>              
                    <asp:TextBox ID="tbPlayer2" runat="server" CssClass="my-txt-box" placeholder="Golf-id"></asp:TextBox>
                    <asp:TextBox ID="tbPlayer3" runat="server" CssClass="my-txt-box" placeholder="Golf-id"></asp:TextBox>
                    <asp:TextBox ID="tbPlayer4" runat="server" CssClass="my-txt-box" placeholder="Golf-id"></asp:TextBox>
                </div>
                <asp:Button ID="confirmBtn" runat="server" CssClass="my-button" Text="Boka" OnClick="confirmBtn_Click1" />
        </div>    
    </div>
</ContentTemplate>
</asp:UpdatePanel> 


<%--    Ruta för konfirmation och felmeddelanden--%>


    <div class="page-overlay-info-box">
      <div class="overlay-message">
          <p class="my-glyph-close"><span class="glyphicon glyphicon-remove pull-right " onclick="closeOverlayInfoBox();"></span></p>
          <h3 class="my-h3" id="BookingInfoText" runat="server">Ditt lösenord har ändrats</h3>  
         <asp:Button ID="OK" runat="server" Text="OK" CssClass="my-button top-n-bottom-space" OnClientClick="closeOverlayInfoBox();"/>     
      </div>
    </div>

<!-------------------- Hidden ------------------>

    <asp:Label ID="hidden1others" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="hidden2search" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>

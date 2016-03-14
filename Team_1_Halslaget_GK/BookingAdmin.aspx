<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Team_1_Halslaget_GK.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link type="text/css" rel="stylesheet" href="css/MyPageCss.css"/>
        <script src="ja/MyPageScripts.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="fullBox">
        <div class="halfBox">
            <h3 class="my-h3">Sök medlem</h3>
            <asp:TextBox ID="TextBoxFirstName" runat="server" placeholder="Förnamn" CssClass="my-txt-box"></asp:TextBox>
            <asp:TextBox ID="TextBoxLastName" runat="server" placeholder="Efternamn" CssClass="my-txt-box"></asp:TextBox>
            <asp:TextBox ID="TextBoxGolfID" runat="server" placeholder="Golf ID" CssClass="my-txt-box"></asp:TextBox>
            <asp:Button ID="ButtonSearch" runat="server" Text="Sök" onclick="ButtonSearch_Click" class="my-button btn-mobile-space"/>

            <asp:GridView ID="GridView2" runat="server" CssClass="Grid" AutoGenerateColumns="false" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID"/>
                    <asp:BoundField DataField="fornamn" HeaderText="Förnamn"/>
                    <asp:BoundField DataField="efternamn" HeaderText="Efternamn"/>
                    <asp:BoundField DataField="golfid" HeaderText="Golf ID"/>
                    <asp:CommandField ShowSelectButton="true" />
                </Columns>
            </asp:GridView>

        </div>

        <div class="halfBox halfBox-right">
            <div class="fullBox">
                <h3 class="my-h3">Bokade Tider</h3>
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
                    <asp:Button ID="btnConfirmCancelBooking" runat="server" Text="JA" CssClass="my-button btn-mobile-space" OnClick="btnCancelBooking_Click"/>   
                </div>  
                <div class="halfBox">
                    <a class="my-button btn-mobile-space" onclick="closeCancelBookingOverlay();">NEJ</a> 
                </div> 
            </div>   
          <p class="p-my-info-modal">.</p>
      </div>
    </div>

</asp:Content>

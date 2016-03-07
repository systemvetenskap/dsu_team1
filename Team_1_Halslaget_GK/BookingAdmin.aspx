<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Team_1_Halslaget_GK.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link type="text/css" rel="stylesheet" href="css/BookingAdmin.css"/> 
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

            <asp:GridView ID="GridView2" runat="server" CssClass="Grid" GridLines="None"></asp:GridView>

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

</asp:Content>

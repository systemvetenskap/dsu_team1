<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Tidsbokning.aspx.cs" Inherits="Team_1_Halslaget_GK.Tidsbokning" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ja/tidsbokning.js"></script>
    <link href="css/tidsbokning.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <h2 class="text-center">Tidsbokning</h2>
        <hr class="hrMargin" />
    </div>
    <div class="wrapper text-center">
        <div class="centerCalender">
            <asp:Calendar ID="Calendar1" runat="server" Style="width: 100%;"></asp:Calendar>
        </div>
    </div>
    <div class="wrapper text-center hrMargin">
        <div class="centerCalender" id="buttonDiv">
            <asp:Button ID="buttonCalender" runat="server" Text="Välj datum" class="calenderButton" OnClientClick="return false;" />
        </div>
    </div>
    <div id="beforeHours">
        <p class="text-center">Ange klockslag</p>
    </div>
    <div class="wrapper" id="hours">
        <div>
            <asp:DropDownList ID="hourDropdown" runat="server">
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div><p class="text-bold">:</p></div>
        <div>
            <asp:DropDownList ID="minutesDropdown" runat="server">
                <asp:ListItem>00</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>40</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="hrMargin"></div>
    <div class="wrapper text-center" id="confirmButton">
        <p class="text-bold">Slutför bokning</p>
        <div class="hrMargin"></div>
        <div id="confirmButtonDiv">
            <asp:Button ID="confirmBtn" runat="server" Text="Boka" />
        </div>
    </div>
</asp:Content>

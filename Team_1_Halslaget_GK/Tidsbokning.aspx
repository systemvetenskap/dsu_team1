<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Tidsbokning.aspx.cs" Inherits="Team_1_Halslaget_GK.Tidsbokning" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    
    </div>
    </form>
</body>
</html>

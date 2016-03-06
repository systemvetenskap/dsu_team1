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
    <div>
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
    </div>

    <div>
        <asp:Label ID="lblPlayer1" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblPlayer2" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblPlayer3" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblPlayer4" runat="server" Text=""></asp:Label>
    </div>

    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
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
            <asp:Button ID="confirmBtn" runat="server" Text="Boka" OnClick="confirmBtn_Click"/>
        </div>
    </div>
</asp:Content>

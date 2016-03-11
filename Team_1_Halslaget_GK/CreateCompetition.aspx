<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CreateCompetition.aspx.cs" Inherits="Team_1_Halslaget_GK.CreateCompetition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Lägg till ny tävling</title>
    <link href="css/CreateCompetition.css" rel="stylesheet" />
    <script src="ja/CreateCompetition.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <h1 class="text-center">Skapa tävling</h1>
        <hr />
    </div>
    <div class="wrapper text-center small-margin">
        <p>
            Här skapar du en tävling, du kan välja hur många datum du vill.
        </p>
    </div>
    <div class="wrapper-small text-center small-margin">
        <asp:TextBox ID="nameBox" runat="server" placeholder="Tävlingsnamn"></asp:TextBox>
    </div>
    <div class="wrapper-small text-center small-margin">
        <textarea id="descriptionBox" cols="20" rows="2" runat="server" placeholder="Beskrivning" style="width: 100%;height: 25px;padding: 3px;"></textarea>
    </div>
    <div class="wrapper-small text-center small-margin">
        <asp:DropDownList ID ="dropDownYear" runat="server">
            <asp:ListItem Value="2016">2016</asp:ListItem>
            <asp:ListItem Value="2017">2017</asp:ListItem>
            <asp:ListItem Value="2018">2018</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="dropDownMonth" runat="server">
            <asp:ListItem Value="01">01</asp:ListItem>
            <asp:ListItem Value="02">02</asp:ListItem>
            <asp:ListItem Value="03">03</asp:ListItem>
            <asp:ListItem Value="04">04</asp:ListItem>
            <asp:ListItem Value="05">05</asp:ListItem>
            <asp:ListItem Value="06">06</asp:ListItem>
            <asp:ListItem Value="07">07</asp:ListItem>
            <asp:ListItem Value="08">08</asp:ListItem>
            <asp:ListItem Value="09">09</asp:ListItem>
            <asp:ListItem Value="10">10</asp:ListItem>
            <asp:ListItem Value="11">11</asp:ListItem>
            <asp:ListItem Value="12">12</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="dropDownDay" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
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
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="wrapper-small text-center small-margin" id="dateDiv">

        <div class="wrapper text-centrer small-margin">
            <p style="font-weight: bold;">Lag</p><asp:CheckBox ID="checkBoxLag" runat="server" onclick="fnCheckOne(this)"/>
            <p style="font-weight: bold;">Singel</p><asp:CheckBox ID="checkBoxSingel" runat="server" onclick="fnCheckOne(this)"/>
        </div>
        <script>
        function fnCheckOne(me)
            {
                me.checked=true;
                var chkary=document.getElementsByTagName('input');
            for(i=0;i<chkary.length;i++)
                {
            if(chkary[i].type=='checkbox')
                {
                   if(chkary[i].id!=me.id)
                   chkary[i].checked=false;
                }
            }
        }
    </script> 
        <div class="wrapper text-center small-margin">
            <asp:Button ID="newDate" runat="server" Text="Lägg till datum och tävlingstyp" CssClass="btn" OnClick="newDate_Click" UseSubmitBehavior="false" />
        </div>
        <div id="dateFiller" runat="server" class="small-margin">
        </div>
        <div id="buttonDiv" runat="server" class="small-margin">
            <asp:Button ID="bookDate" runat="server" Text="Skapa tävling" OnClick="bookDate_Click" CssClass="btn" />
        </div>
</asp:Content>

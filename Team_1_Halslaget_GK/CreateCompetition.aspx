<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CreateCompetition.aspx.cs" Inherits="Team_1_Halslaget_GK.CreateCompetition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Lägg till ny tävling</title>
    <link href="css/CreateCompetition.css" rel="stylesheet" />
    <script src="ja/CreateCompetition.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="halfBox">
                <asp:Calendar ID="Calendar1" CssClass="Calender" runat="server">
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
            <div class="halfBox">
                <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator10"
                            ControlToValidate="tbCompName"
                            ForeColor ="Red"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Ge tävlingen ett namn!"
                            display="Dynamic"
                            ValidationGroup="NewComp">                       
                 </asp:RequiredFieldValidator>
                <asp:TextBox ID="tbCompName" CssClass="my-txt-box my-txt-box2" runat="server" placeholder="Namn"></asp:TextBox>
                <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator3"
                            ControlToValidate="tbCompDesc"
                            ForeColor ="Red"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Ge tävlingen en beskrivning!"
                            display="Dynamic"
                            ValidationGroup="NewComp">                       
                 </asp:RequiredFieldValidator>
                <asp:TextBox ID="tbCompDesc" CssClass="my-txt-box" runat="server" TextMode="MultiLine" Rows="10" placeholder="Beskrivning"></asp:TextBox>
                <div class="fullBox">
                    <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator9"
                            ControlToValidate="ddlCompType"
                            ForeColor ="Red"
                            initialValue="Välj Tävlingstyp"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Glöm inte välja tävlingstyp!"
                            display="Dynamic"
                            ValidationGroup="NewComp">                       
                         </asp:RequiredFieldValidator>
                <asp:DropDownList ID="ddlCompType" CssClass="DropDown" runat="server" >
                    <asp:ListItem>Välj Tävlingstyp</asp:ListItem>
                    <asp:ListItem>Singel</asp:ListItem>
                    <asp:ListItem>Lag</asp:ListItem>
                </asp:DropDownList>
                </div>        
                <div class="halfBox">
                    <asp:Label ID="Label1" runat="server" Text="Starttid"></asp:Label>
                    <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1"
                            ControlToValidate="ddlstarttime"
                            ForeColor ="Red"
                            initialValue="Välj starttid"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Glöm inte välja starttid!"
                            display="Dynamic"
                            ValidationGroup="NewComp">                       
                         </asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddlstarttime" DataTextFormatString="{0:HH:mm}"  CssClass="DropDown DropDown2" runat="server">                       
                    </asp:DropDownList>
                </div>
                <div class="halfBox">
                    <asp:Label ID="Label2" runat="server" Text="Sluttid"></asp:Label>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2"
                            ControlToValidate="ddlendtime"
                            ForeColor ="Red"
                            initialValue="Välj sluttid"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Glöm inte välja sluttid!"
                            display="Dynamic"
                            ValidationGroup="NewComp">                       
                         </asp:RequiredFieldValidator>
                    <asp:DropDownList DataTextFormatString="{0:HH:mm}"  ID="ddlendtime" CssClass="DropDown DropDown2" runat="server"></asp:DropDownList>
                </div>               
                <div class="fullBox">
                    <asp:Button ID="btnConfirm" CssClass="my-button" runat="server" Text="Skapa Tävling" OnClick="btnConfirm_Click" ValidationGroup="NewComp"/>
                </div>                 
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

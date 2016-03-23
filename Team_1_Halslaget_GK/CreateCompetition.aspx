<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CreateCompetition.aspx.cs" Inherits="Team_1_Halslaget_GK.CreateCompetition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Lägg till ny tävling</title>
    <link href="css/CreateCompetition.css" rel="stylesheet" />
    <script src="ja/CreateCompetition.js"></script>
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
                    <asp:Label ID="Label3" runat="server" Text="Tee Herr"></asp:Label>
                        <asp:RequiredFieldValidator  
                            ID="RequiredFieldValidator5"
                            ControlToValidate="ddlTeeM"
                            ForeColor ="Red"
                            initialValue="Välj tee för herrar"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Glöm inte välja Tee för herrar"
                            display="Dynamic"
                            ValidationGroup="NewComp">                       
                         </asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddlTeeM" runat="server" CssClass="DropDown DropDown2"></asp:DropDownList>
                </div>
                <div class="halfBox">
                    <asp:Label ID="Label4" runat="server" Text="Tee Dam"></asp:Label>
                      <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator4"
                            ControlToValidate="ddlTeeF"
                            ForeColor ="Red"
                            initialValue="Välj tee för damer"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Glöm inte välja Tee för damer"
                            display="Dynamic"
                            ValidationGroup="NewComp">                       
                         </asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddlTeeF" runat="server" CssClass="DropDown DropDown2"></asp:DropDownList>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SeasonSettings.aspx.cs" Inherits="Team_1_Halslaget_GK.SeasonSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="css/SeasonSettingStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="fullBox">
        <h1>INSTÄLLNINGAR</h1>
    </div>
    <div class="fullBox">
            <div class="fullBox page-title">
                <h3>SKAPA NY GOLFSÄSONG</h3>
            </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="halfBox">
                    <div class="fullBox page-title">
                        <div class="fullBox">
                            <br />
                            <p><strong>Välj säsong: </strong></p>
                            <asp:RequiredFieldValidator ID="dropValidator" 
                                InitialValue="Välj säsong" 
                                ControlToValidate="dropDownYearSelect"
                                runat="server" 
                                ErrorMessage="Du måste välja vilken säsong du vill skapa."
                                ForeColor="Red" 
                                Font-Size="Smaller" >
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="fullBox  em-margin-horizontal">
                        <asp:DropDownList ID="dropDownYearSelect" 
                            CssClass="DropDown" 
                            runat="server" 
                            AutoPostBack="true" 
                            OnSelectedIndexChanged="dropDownYearSelect_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="fullBox">

                        <div class="fullBox">
                            <p class="center-text">
                                <asp:CompareValidator ID="compareDate" 
                                    ControlToValidate="txtEndDate" 
                                    ControlToCompare="txtStartDate" 
                                    Operator="GreaterThan" 
                                    runat="server" 
                                    ErrorMessage="Slutdatumet kan inte vara efter startdatumet." 
                                    Font-Size="Smaller" 
                                    ForeColor="Red">
                                </asp:CompareValidator>
                            </p>

                            <div class="halfBox">
                                <div class="fullBox page-title">
                                    <p class="center-text"><strong>Välj startdatum: </strong></p>
                                </div>
                                <div class="fullBox center-text">
                                    <p><asp:RequiredFieldValidator ID="startDateValidator" 
                                        ControlToValidate="txtStartDate" runat="server" 
                                        ErrorMessage="Du måste välja ett startdatum." 
                                        Font-Size="Smaller" 
                                        ForeColor="Red">
                                    </asp:RequiredFieldValidator></p>
                                </div>
                                <div class="fullBox">
                                    <asp:Calendar ID="calenderStartDate" runat="server" 
                                        OnDayRender="calenderStartDate_DayRender"
                                            CssClass="calender-style" 
                                        OnPreRender="calenderStartDate_PreRender" 
                                        OnVisibleMonthChanged="calenderStartDate_VisibleMonthChanged" 
                                        OnSelectionChanged="calenderStartDate_SelectionChanged">
                                    </asp:Calendar>
                                </div>
                                <asp:TextBox ID="txtStartDate" Style="display: none;" runat="server"></asp:TextBox>
                            </div>

                            <div class="halfBox">
                                <div class="fullBox">
                                    <div class="fullBox page-title">
                                        <p class="center-text"><strong>Välj slutdatum: </strong></p>
                                    </div>
                                    <div class="fullBox center-text">
                                        <p><asp:RequiredFieldValidator ID="endDateValidator" 
                                            ControlToValidate="txtEndDate" 
                                            runat="server" 
                                            ErrorMessage="Du måste välja ett slutdatum." 
                                            Font-Size="Smaller" 
                                            ForeColor="Red">
                                        </asp:RequiredFieldValidator></p>    
                                    </div>
                                </div>
                                <div class="fullBox">                       
                                    <asp:Calendar ID="calenderEndDate" 
                                        runat="server"
                                        CssClass="calender-style" 
                                        OnDayRender="calenderEndDate_DayRender" 
                                        OnPreRender="calenderEndDate_PreRender" 
                                        OnSelectionChanged="calenderEndDate_SelectionChanged">
                                    </asp:Calendar>
                                </div> 
                                <asp:TextBox ID="txtEndDate" Style="display: none;" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="fullBox em-margin-horizontal">           
                            <asp:Button ID="ButtonSetSeason" CssClass="my-button" runat="server" Text="Spara" OnClick="ButtonSetSeason_Click"/> <%--la till den här rackaren bara för att kunna prova min "reverese backend" kod typ som behövs för den typen av db jag skapade--%>
                        </div> 
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>

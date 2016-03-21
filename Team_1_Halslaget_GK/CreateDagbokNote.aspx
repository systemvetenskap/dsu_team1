<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="CreateDagbokNote.aspx.cs" Inherits="Team_1_Halslaget_GK.CreateDagbokNote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ja/CreateDiaryNoteJS.js"></script>
    <link href="css/DiaryCSS.css" rel="stylesheet" />
    <script src='//cdn.tinymce.com/4/tinymce.min.js'></script>
    <script src="ja/Tinymce.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="fullBox page-title">
        <h1>DAGBOKSINLÄGG</h1>
    </div>
    <div class="fullBox">
        <div class="fullBox">
            <p>Här kan du skriva ett inlägg om dagens golfrunda. Du kan även välja att fylla i ett scorekort för din runda.</p>
            <br />
            <br />
        </div>
        <div class="halfBox">
            <div class="fullBox">
                <div class="fullBox">
                    <div class="halfBox">
                        <h3 style="margin-bottom: 0.2em;">Ange en titel:</h3>
                    </div>
                    <div class="halfBox">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                                <a class="calender-klick right" runat="server" id="openCalendar" onserverclick="openCalendar_ServerClick">
                                    <h3 style="margin-bottom: 0.2em;">
                                    <asp:Label ID="lbldate" ToolTip="Klicka för att välja ett annat datum." runat="server" Text=""></asp:Label>
                                    <span class="glyphicon glyphicon-calendar" style="font-size: 0.75em;" id="toggle-calender" aria-hidden="true"></span>
                                    </h3>
                                </a>
                                <div class="calender-div right">
                                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="fullBox">
                    <asp:TextBox ID="txtTitle" CssClass="my-txt-box" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="fullBox">
                    <asp:TextBox ID="txtHTMLContent" runat="server" Height="390px" TextMode="MultiLine"></asp:TextBox>  
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <script src="ja/ScoreCard.js"></script>
                <div class="halfBox center-text">
                    <div class="fullBox">
                        <p><asp:CheckBox 
                            ID="checkBoxScoreCard" 
                            runat="server" 
                            Text="Kryssa i för att fylla i scorekortet." 
                            AutoPostBack="true" 
                            style="cursor: pointer;"
                            OnCheckedChanged="checkBoxScoreCard_CheckedChanged" />
                        </p>
                        <br />
                    </div>
                    <div class="fullBox">
                        <asp:DropDownList 
                            ID="dropDownTee" 
                            CssClass="DropDown" 
                            AutoPostBack="true" 
                            runat="server" 
                            OnSelectedIndexChanged="dropDownTee_SelectedIndexChanged1"></asp:DropDownList>
                    </div>
                        <div class="halfBox">
                            <p>1. <asp:TextBox ID="TextBox1" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>2. <asp:TextBox ID="TextBox2" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>3. <asp:TextBox ID="TextBox3" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>4. <asp:TextBox ID="TextBox4" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>5. <asp:TextBox ID="TextBox5" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>6. <asp:TextBox ID="TextBox6" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>7. <asp:TextBox ID="TextBox7" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>8. <asp:TextBox ID="TextBox8" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>9. <asp:TextBox ID="TextBox9" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <div class="fullBox center-text">
                                <p class="em-margin-horizontal"><strong>UT: </strong><asp:Label ID="lblIn" runat="server" Text=""></asp:Label></p>
                            </div>
                        </div>
                        <div class="halfBox">
                            <p>10. <asp:TextBox ID="TextBox10" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>11. <asp:TextBox ID="TextBox11" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>12. <asp:TextBox ID="TextBox12" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>13. <asp:TextBox ID="TextBox13" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>14. <asp:TextBox ID="TextBox14" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>15. <asp:TextBox ID="TextBox15" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>16. <asp:TextBox ID="TextBox16" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>17. <asp:TextBox ID="TextBox17" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <p>18. <asp:TextBox ID="TextBox18" CssClass="my-diary-txt-box" runat="server"></asp:TextBox></p>
                            <div class="fullBox center-text">
                                <p class="em-margin-horizontal"><strong>IN: </strong><asp:Label ID="lblOut" runat="server" Text=""></asp:Label></p>
                            </div>
                        </div>
                        <div class="fullBox em-margin-horizontal">
                        <asp:Label ID="lblCourseRating" style="display: none;" runat="server" Text="CR"></asp:Label>
                        <asp:Label ID="lblSlopeValue" style="display: none;" runat="server" Text="SV"></asp:Label>
                        <asp:Label ID="lblPar" style="display: none;" runat="server" Text="Par"></asp:Label>
                        <asp:Label ID="lblhcp" style="display: none;" runat="server" Text=""></asp:Label>
                            <div class="halfBox center-text">
                                <p><strong>TOTALT: </strong><asp:Label ID="lblTotalt" runat="server" Text=""></asp:Label></p>
                            </div>
                            <div class="halfBox center-text">
                                <p><strong>SCORE: </strong><asp:Label ID="lblScore" runat="server" Text=""></asp:Label></p>
                            </div>
                        </div>
                 </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />

    </div>
    <div class="fullBox center-text">
        <p class="center-text"><asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
        <asp:RequiredFieldValidator 
            ID="validateTitle" 
            runat="server" 
            ErrorMessage="Fyll i en titel på ditt dagboksinlägg" 
            ControlToValidate="txtTitle"             
            ValidationGroup="title" 
            ForeColor="Red">
        </asp:RequiredFieldValidator>
        </p>
    </div>
    <div class="fullBox center-text">
        <asp:Button ID="btnSaveDiary" ValidationGroup="title" CssClass="my-button button-80" runat="server" Text="SKAPA INLÄGG" OnClick="btnSaveDiary_Click" />
    </div>

</asp:Content>

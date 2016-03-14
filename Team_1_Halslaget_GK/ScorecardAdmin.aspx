<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ScorecardAdmin.aspx.cs" Inherits="Team_1_Halslaget_GK.ScorecardAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SCOREKORT</title>
    <link href="css/ScoreCardStyle.css" rel="stylesheet" />
    <script src="ja/jquery.maskedinput.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <script src="ja/ScoreCard.js"></script>
        <script>
            $(document).ready(function () {
                jQuery(function ($) {
                    $("#ContentPlaceHolder1_txtGoldID").mask("99999_9?999", { placeholder: "x" });
                });
            });
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function () {
                jQuery(function ($) {
                    $("#ContentPlaceHolder1_txtGoldID").mask("99999_9?999", { placeholder: "x" });
                });
            });

        </script>
    <div class="fullBox page-title">
        <h1>SCORECARD </h1>
    </div>
    <div class="fullBox">
        <div class="halfBox  em-margin-horizontal">
            <div class="fullBox page-title">
                <h3>VÄLJ TÄVLING</h3>
            </div>
            <div class="fullBox">
                <p><strong>Välj tävling: </strong></p>
                <asp:DropDownList ID="dropDownCompetition" CssClass="DropDown" AutoPostBack="true" runat="server" OnSelectedIndexChanged="dropDownCompetition_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="fullBox">
                <p><strong>Välj tee: </strong>
                <asp:RequiredFieldValidator ID="validatorTee" 
                    runat="server" 
                    ErrorMessage="Du måste välja"
                    IntialValue="Välj"
                    ValidationGroup="golfIdGroup"
                    ControlToValidate="dropDownTee">
                </asp:RequiredFieldValidator></p>
                <asp:DropDownList ID="dropDownTee" CssClass="DropDown" AutoPostBack="true" runat="server" OnSelectedIndexChanged="dropDownTee_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="fullBox  line-up">
                <div class="fullBox page-title">
                    <h3>TÄVLINGS INFO</h3>
                </div>
                <p class="em-margin-horizontal"><strong>Datum: </strong><asp:Label ID="lblDate" runat="server" Text=""></asp:Label></p>
                <p class="em-margin-horizontal"><strong>Starttid: </strong><asp:Label ID="lblStartTime" runat="server" Text=""></asp:Label></p>
                <p class="em-margin-horizontal"><strong>Sluttid: </strong><asp:Label ID="lblEndTime" runat="server" Text=""></asp:Label></p>
                <asp:Label ID="lblCompetitionID" style="display: none;" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblCourseRating" style="display: none;" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblSlopeValue" style="display: none;" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblPar" style="display: none;" runat="server" Text=""></asp:Label>
            </div>
        </div>

        <div class="halfBox em-margin-horizontal">
            <div class="fullBox">
               <div class="fullBox page-title">
                    <h3>HÄMTA SPELARE</h3>
                </div>
                <p><strong>Ange golf id: </strong> <asp:Label ID="lblErrorNoMember" Style="color: red;" runat="server" Text=""></asp:Label></p>
                <asp:TextBox ID="txtGoldID" CssClass="my-txt-box" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator 
                    ID="validatorGolfID"
                    ControlToValidate="txtGoldID" 
                    Forecolor="Red"                    
                    runat="server" 
                    ErrorMessage="Golf id kan inte lämnas tomt" ValidationGroup="golfIdGroup"                    >
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
                    ID="regexValidator" 
                    ControlToValidate = "txtGoldID"
                    runat="server" 
                    ErrorMessage="Skriv in minst 6 siffror!"
                    ForeColor="Red"
                    ValidationExpression = "^[\s\S]{6,}$" ValidationGroup="golfIdGroup"                    >
                </asp:RegularExpressionValidator>

                <div class="fullBox center-text">
                    <asp:Button ID="btnGetMemberInfo" CssClass="my-button button-80 em-margin-horizontal" ValidationGroup="golfIdGroup" runat="server" Text="HÄMTA SPELARE" OnClick="btnGetMemberInfo_Click" />
                </div>
            </div>


            <div class="fullBox em-margin-horizontal">
                <div class="fullBox page-title">
                    <h3 class="em-margin-horizontal">SPELARINFO</h3>
                </div>
                <p class="em-margin-horizontal"><strong>Medlems ID: </strong><asp:Label ID="lblMemberId" runat="server" Text=""></asp:Label></p>
                <p class="em-margin-horizontal"><strong>Förnamn: </strong><asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label></p>
                <p class="em-margin-horizontal"><strong>Efternamn: </strong><asp:Label ID="lblLastName" runat="server" Text=""></asp:Label></p>
                <p class="em-margin-horizontal"><strong>Handikapp: </strong><asp:Label ID="lblhcp" runat="server" Text=""></asp:Label></p>
                <asp:TextBox ID="txtBoxMemberID" style="display: none;" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="fullbox">
        <div class="page-title">
            <h3>SCOREKORT</h3>
        </div>
        <div class="halfBox">
            <p>1. <asp:TextBox ID="TextBox1" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>2. <asp:TextBox ID="TextBox2" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>3. <asp:TextBox ID="TextBox3" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>4. <asp:TextBox ID="TextBox4" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>5. <asp:TextBox ID="TextBox5" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>6. <asp:TextBox ID="TextBox6" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>7. <asp:TextBox ID="TextBox7" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>8. <asp:TextBox ID="TextBox8" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>9. <asp:TextBox ID="TextBox9" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <div class="fullBox center-text">
                <h3 class="em-margin-horizontal"><strong>IN: </strong><asp:Label ID="lblIn" runat="server" Text=""></asp:Label></h3>
            </div>
        </div>
       <div class="halfBox">
            <p>10. <asp:TextBox ID="TextBox10" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>11. <asp:TextBox ID="TextBox11" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>12. <asp:TextBox ID="TextBox12" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>13. <asp:TextBox ID="TextBox13" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>14. <asp:TextBox ID="TextBox14" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>15. <asp:TextBox ID="TextBox15" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>16. <asp:TextBox ID="TextBox16" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>17. <asp:TextBox ID="TextBox17" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <p>18. <asp:TextBox ID="TextBox18" CssClass="my-txt-box" runat="server"></asp:TextBox></p>
            <div class="fullBox center-text">
                <h3 class="em-margin-horizontal"><strong>UT: </strong><asp:Label ID="lblOut" runat="server" Text=""></asp:Label></h3>
            </div>
       </div>
        <div class="fullBox em-margin-horizontal">
            <div class="halfBox center-text">
                <h3><strong>TOTALT: </strong><asp:Label ID="lblTotalt" runat="server" Text=""></asp:Label></h3>
            </div>
            <div class="halfBox center-text">
                <h3><strong>SCORE: </strong><asp:Label ID="lblScore" runat="server" Text=""></asp:Label></h3>
            </div>
        </div>
    </div>
    <div class="fullBox em-margin-horizontal center-text">
        <div class="fullBox">
            <asp:RequiredFieldValidator 
                ID="validatorMemberID" 
                runat="server" 
                ErrorMessage="Obs ingen spelare vald." 
                ForeColor="Red" 
                ValidationGroup="memberID" 
                ControlToValidate="txtBoxMemberID">
            </asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator 
                ID="validatorCompetition" 
                runat="server" 
                ErrorMessage="Obs, du måste välja en tävling"
                IntialValue="Välj"
                ValidationGroup="memberID"
                ControlToValidate="dropDownCompetition">
            </asp:RequiredFieldValidator>

        </div>
        <div class="fullBox em-margin-horizontal">
            <asp:Button ID="Button1" runat="server" ValidationGroup="memberID" CssClass="my-button button-80" Text="SPARA SCOREKORT" onclick="Button1_Click"/>
        </div>
    </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

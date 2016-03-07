<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateNewMember.aspx.cs" Inherits="Team_1_Halslaget_GK.CreateNewMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Lägg till ny medlem</title>
    <link href="css/CreateNewMemberCss.css" rel="stylesheet" />
    <script>
        function openConfirmMessage() {
            var confirmed = document.getElementById('ContentPlaceHolder1_lblSavedConfirm').innerText;
            if (confirmed == "T") {
                document.getElementById('ContentPlaceHolder1_lblConfirmed').innerText = "Uppgifterna sparades.";
                $('.page-overlay-saved').fadeIn('slow').delay(1600);;
                $('.page-overlay-saved').fadeOut('slow');
            }
            else
            {
                document.getElementById('ContentPlaceHolder1_lblConfirmed').innerText = "Uppgifterna sparades inte. Något gick fel.";
                $('.page-overlay-saved').fadeIn('slow').delay(1600);;
                $('.page-overlay-saved').fadeOut('slow');
            }
        }
    </script>

    <script>
        function closeOverlaySaved() {
            $('.page-overlay-saved').fadeOut('slow');
        }
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- Overlay/modal for confirmation ================================================== -->
    <div class="page-overlay-saved">
      <div class="overlay-message-saved">
          <p class="my-glyph-close"><span class="glyphicon glyphicon-remove pull-right " onclick="closeOverlaySaved();"></span></p>
            <h3 class="my-h3 center-text">MEDDELANDE FRÅN WEBBSIDAN</h3>  
            <div class="fullBox">
                <p class="center-text one-em-margin-horizontal"><asp:Label ID="lblConfirmed" runat="server" Text="Label"></asp:Label></p>
            </div>  
            <div class="fullBox">
                <a class="my-button btn-mobile-space" onclick="closeOverlaySaved();">OK</a> 
            </div> 
          <p class="p-my-info-modal">.</p>
      </div>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <!-- MAIN PAGE ================================================== -->
    <div class="fullBox page-title">
        <h1>NY MEDLEM</h1>
    </div>
    <div class="fullBox">
        <div class="halfBox em-margin-horizontal">
            <p class="em-margin-horizontal">Förnamn: 
                <asp:RequiredFieldValidator 
                    ID="validatorFirstName" 
                    ControlToValidate="txtFistName" 
                    ForeColor="Red" runat="server" 
                    Font-Size="Smaller" 
                    ErrorMessage="Fyll i ett namn">
                </asp:RequiredFieldValidator>
            </p>
            <asp:TextBox ID="txtFistName" CssClass="my-txt-box" runat="server"></asp:TextBox>
            <p class="em-margin-horizontal">Efternamn: 
                <asp:RequiredFieldValidator 
                    ID="validatorLastName" 
                    ControlToValidate="txtLastName"  
                    ForeColor="Red" runat="server" 
                    Font-Size="Smaller"  
                    ErrorMessage="Fyll i ett efternamn">
                </asp:RequiredFieldValidator>
            </p>
            <asp:TextBox ID="txtLastName" CssClass="my-txt-box" runat="server"></asp:TextBox>
            <p class="em-margin-horizontal">Kön: 
                <asp:RequiredFieldValidator 
                    ID="validatorKon" 
                    ControlToValidate="dropDownListKon" 
                    InitialValue="Välj" 
                    ForeColor="Red" 
                    Font-Size="Smaller"  
                    runat="server" 
                    ErrorMessage="Välj kön">
                </asp:RequiredFieldValidator>
            </p>
            <asp:DropDownList ID="dropDownListKon" CssClass="DropDown" runat="server">
                <asp:ListItem>Välj</asp:ListItem>
                <asp:ListItem>Kvinna</asp:ListItem>
                <asp:ListItem>Man</asp:ListItem>
            </asp:DropDownList>
            <!--<p class="em-margin-horizontal">Födelsedatum: 
                <asp:RequiredFieldValidator 
                    ID="validatorBirthDate" 
                    runat="server" 
                    ErrorMessage="Kan ej vara tom!"
                    ControlToValidate="txtBirthDate"
                    Font-Size="Smaller"  
                    ForeColor="Red" >                    
                </asp:RequiredFieldValidator>
                <asp:RangeValidator 
                    ID="rangeValidBIrth" 
                    ControlToValidate="txtBirthDate" 
                    Type="Double"
                    Font-Size="Smaller"  
                    ForeColor="Red"
                    MinimumValue="19000000"
                    MaximumValue="22000000" 
                    runat="server" 
                    ErrorMessage="Endast siffror"></asp:RangeValidator>
            </p>
            <asp:TextBox ID="txtBirthDate" CssClass="my-txt-box" runat="server"></asp:TextBox>-->
            <p class="em-margin-horizontal">Telefonnummer: 
                <asp:RequiredFieldValidator 
                    ID="validatorPhone" 
                    ControlToValidate="txtPhone" 
                    ForeColor="Red" 
                    runat="server" 
                    Font-Size="Smaller"  
                    ErrorMessage="Fyll i ett telefonnummer">
                </asp:RequiredFieldValidator>
            </p>
            <asp:TextBox ID="txtPhone" CssClass="my-txt-box" runat="server"></asp:TextBox>
            <p class="em-margin-horizontal">Epost: 
                <asp:RequiredFieldValidator 
                    ID="validatorEmail" 
                    ControlToValidate="txtEmail" 
                    ForeColor="Red" runat="server" 
                    Font-Size="Smaller"  
                    ErrorMessage="Ange en epost.">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
                    ID="regExValidatorEmail" 
                    ForeColor="Red" 
                    Font-Size="Smaller" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="txtEmail" 
                    runat="server" 
                    ErrorMessage="Felaktigt epost format">
                </asp:RegularExpressionValidator>
            </p>
            <asp:TextBox ID="txtEmail" CssClass="my-txt-box" runat="server"></asp:TextBox>
        </div>

        <div class="halfBox em-margin-horizontal">
            <p class="em-margin-horizontal">Adress: 
                <asp:RequiredFieldValidator 
                    ID="validatorAddess" 
                    ControlToValidate="txtAddress" 
                    ForeColor="Red" 
                    runat="server" 
                    Font-Size="Smaller"  
                    ErrorMessage="Fyll i en adress">
                </asp:RequiredFieldValidator>
            </p>
            <asp:TextBox ID="txtAddress" CssClass="my-txt-box" runat="server"></asp:TextBox>
            <p class="em-margin-horizontal">Postnummer: 
                <asp:RequiredFieldValidator 
                    ID="validatorPostalCode" 
                    ControlToValidate="txtPostalCode" 
                    ForeColor="Red" 
                    runat="server" 
                    Font-Size="Smaller"  
                    ErrorMessage="Fyll i ett postnummer">
                </asp:RequiredFieldValidator>
            </p>
            <asp:TextBox ID="txtPostalCode" CssClass="my-txt-box" runat="server"></asp:TextBox>
            <p class="em-margin-horizontal">Ort: 
                <asp:RequiredFieldValidator 
                    ID="validatorCity" 
                    ControlToValidate="txtCity" 
                    ForeColor="Red" 
                    runat="server" 
                    Font-Size="Smaller"  
                    ErrorMessage="Fyll i en ort">
                </asp:RequiredFieldValidator>
            </p>
            <asp:TextBox ID="txtCity" CssClass="my-txt-box" runat="server"></asp:TextBox>
            <p class="em-margin-horizontal">Handikapp: 
                <asp:RequiredFieldValidator 
                    ID="validatprHcp" 
                    ControlToValidate="txtHcp" 
                    ForeColor="Red" 
                    runat="server" 
                    Font-Size="Smaller"  
                    ErrorMessage="Fyll i ett handikapp">
                </asp:RequiredFieldValidator>
                <asp:RangeValidator 
                    ID="rangeValidatorHcp" 
                    ControlToValidate="txtHcp" 
                    Type="Double"
                    MaximumValue="99,99" 
                    Font-Size="Smaller"  
                    ForeColor="Red"
                    MinimumValue="0" 
                    runat="server" 
                    ErrorMessage="Endast siffror och kommatecken.">
                </asp:RangeValidator>
            </p>
                
            <asp:TextBox ID="txtHcp" CssClass="my-txt-box" runat="server"></asp:TextBox>
            <p class="em-margin-horizontal">Medlemstyp: 
                <asp:RequiredFieldValidator 
                    ID="validatorMembertype" 
                    ControlToValidate="dropDownMemberType" 
                    InitialValue="Välj" 
                    Font-Size="Smaller"  
                    ForeColor="Red"
                    runat="server" 
                    ErrorMessage="Välj medlemstyp">
                </asp:RequiredFieldValidator>
            </p>
            <asp:DropDownList ID="dropDownMemberType" CssClass="DropDown" runat="server"></asp:DropDownList>
            <p class="em-margin-horizontal">Medlemsavgift betald: 
                <asp:RequiredFieldValidator 
                    ID="validatorPayStatus" 
                    ControlToValidate="dropDownPayStatus" 
                    InitialValue="Välj" 
                    Font-Size="Smaller"  
                    ForeColor="Red" 
                    runat="server" 
                    ErrorMessage="Du måste välja ja eller nej.">
                </asp:RequiredFieldValidator>
            </p>
            <asp:DropDownList ID="dropDownPayStatus" CssClass="DropDown" runat="server">
                <asp:ListItem>Välj</asp:ListItem>
                <asp:ListItem>Ja</asp:ListItem>
                <asp:ListItem>Nej</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblSavedConfirm"  style="display:none;" runat="server" Text=""></asp:Label>
            <div class="fullBox em-margin-horizontal">
                <asp:Button ID="btnAddMember" runat="server" CssClass="my-button" Text="LÄGG TILL" OnClick="btnAddMember_Click" />
            </div>

        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

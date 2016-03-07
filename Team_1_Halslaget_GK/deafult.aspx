    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deafult.aspx.cs" Inherits="Team_1_Halslaget_GK.deafult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HÅLSLAGET GK1</title>
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/deafultstyle.css" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="css/style.css"/>
    <link href="css/Glyphicons.css" rel="stylesheet" />
    <link href="css/font.css" rel="stylesheet" />
    <script src="ja/opencloseoverlay.js"></script>
    <script src="ja/Scrollto.js"></script>
    <link href="http://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>   
</head>
<body>

 <form id="form1" runat="server">
  <div class="logincontainer">
   <div class="loginbox">
       <input id="Button1" type="button" value="X" class="closebtn"  onclick="closeOverlay();"/>
       <br />
       <h2>Välkommen</h2> 
       <br />
       <div class="textboxcontainer">
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator11"
                ControlToValidate="TextBoxEmailLogin"
                ForeColor ="Red"
                runat="server"
                Font-Size="Medium"
                ErrorMessage="Du måste ange en Emailadress!"
                display="Dynamic"
                ValidationGroup="LoginGroup">                       
           </asp:RequiredFieldValidator>
           <asp:TextBox ID="TextBoxEmailLogin" runat="server" placeholder="Email" CssClass="my-txt-box"></asp:TextBox>
           <br />
           <br />
           <asp:RequiredFieldValidator
                ID="RequiredFieldValidator12"
                ControlToValidate="TextBoxPwLogin"
                ForeColor ="Red"
                runat="server"
                Font-Size="Medium"
                ErrorMessage="Du måste ange ett lösenord!"
                display="Dynamic"
                ValidationGroup="LoginGroup">                       
           </asp:RequiredFieldValidator>    
           <asp:TextBox ID="TextBoxPwLogin" runat="server" TextMode="Password" placeholder="Lösenord" CssClass="my-txt-box" ></asp:TextBox>
           <br />
           <asp:Label ID="LabelWrongPW" runat="server" Text="Label" Visible="false"></asp:Label>
           <br />
           <asp:Button ID="signInBtn" runat="server" Text="Logga in" CssClass="my-button" ValidationGroup="LoginGroup" OnClick="signInBtn_Click" />
       </div>   

   </div>
  </div>
  <!-- Navbar ================================================== -->
    <section class="container" id="navbar-section">
      <div class="content">
        <div class="contentRow">
            
            <ul class="main-navbar">
              <li onclick="scrolltoTop();"><a href='#'>HEM</a></li>
              <li onclick="scrolltoNews();"><a href="#">NYHETER</a></li>                                                                  
              <li onclick="scrolltoBookings();"><a href="#">DAGENS BOKNINGAR</a></li>
              <li onclick="scrolltoRegister();"><a href="#">BLI MEDLEM</a></li>  
            </ul>
            <ul class="main-navbar right">
              <li onclick="Openoverlay();"><a href="#">LOGGA IN</a></li>                               
            </ul>
            
            <a href="#open-menu" class="open-menu-link">☰ MENY</a>
            <div class="responsive-navbar-holder" id="open-menu">
              <ul class="responsive-navbar">
                <li><a  href="#">☰ STÄNG MENY</a></li>
                <li><a class="active" href='#'>HEM</a></li>
                <li><a href="#">NYHETER</a></li>                                                                  
                <li><a href="#">SIDA 2</a></li> 
                <li><a href="#">SIDA 3</a></li>     
                <li><a href="#">LOGGA UT</a></li>                                 
              </ul>
            </div>
        </div>
      </div>
    </section>

    <!-- Header ================================================== -->
    <section class="container" id="head-seaction">
      <div class="content" id="header-content">
       <div class="logoContainer">
          <img class="header-logo" src="img/golf.jpg" alt="Headimage" title="Fint landskap"/>
        </div> 
      </div>
    </section>   
     <section class="container">
            <div class="content">
                <div class="contentRow">
                    <div class="fullBox news">
                        <div class="page-title"><h1>Nyheter</h1></div>
                        <div class="fullBox" runat="server" id="newsdiv">
                        </div>
                    </div> 
                        <div class="fullBox bookings">
                            <div class="page-title"><h1>Bokningar och Väder</h1></div>
                                <div class="weatherBox">
                                    <div id="c_e67186ae70807f54f0e967f0f38dac9f" class="widget">klart.se</div>
                                    <script type="text/javascript" src="http://www.klart.se/widget/widget_loader/e67186ae70807f54f0e967f0f38dac9f"></script>
                                    <asp:Table ID="Table2" runat="server" CssClass="banstatus">
                                        <asp:TableRow CssClass="border_bottom">
                                            <asp:TableCell>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="alignright">
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="border_bottom">
                                            <asp:TableCell>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="alignright">
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="border_bottom">
                                            <asp:TableCell>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="alignright">
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="alignright">
                                            </asp:TableCell>
                                        </asp:TableRow>
                                </asp:Table>
                            </div>
                        </div>                                     
                    </div>  
                </div>         
        </section>
     <section class="container">
         <div class="content">
             <div class="contentRow">
                 <div class="fullBox page-title">
                     <h1>Bli Medlem</h1>
                 </div>
                 <div class="fullBox registerbox">  
                     <div class="thirdBox">
                         <asp:RequiredFieldValidator
                            ID="ValidatorFirstName"
                            ControlToValidate="tbName"
                            ForeColor ="Red"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Fyll i ditt namn!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">                       
                         </asp:RequiredFieldValidator>
                         <asp:TextBox ID="tbName" runat="server" CssClass="my-txt-box" placeholder="Namn"></asp:TextBox>
                         <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1"
                            ControlToValidate="tbLastname"
                            ForeColor ="Red"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Fyll i ditt efternamn!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">                       
                         </asp:RequiredFieldValidator>
                         <asp:TextBox ID="tbLastname" runat="server" CssClass="my-txt-box" placeholder="Efternamn"></asp:TextBox>
                         <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2"
                            ControlToValidate="tbPonenumber"
                            ForeColor ="Red"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Fyll i ditt telefonnummer!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">
                         </asp:RequiredFieldValidator>                                           
                         <asp:RangeValidator
                            ID="rangeValidPonenumber" 
                            ControlToValidate="tbPonenumber" 
                            Type="Double"
                            Font-Size="Medium"  
                            ForeColor="Red"
                            MinimumValue="0"
                            MaximumValue="9999999999999999" 
                            runat="server" 
                            ErrorMessage="Ett telefonnummer får bara innehålla siffror!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup"></asp:RangeValidator>               
                         <asp:TextBox ID="tbPonenumber" runat="server" CssClass="my-txt-box" placeholder="Telefonnummer"></asp:TextBox>                        
                     </div> 
                     <div class="thirdBox">
                         <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator3"
                            ControlToValidate="tbAdress"
                            ForeColor ="Red"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Fyll i din adress!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">                       
                         </asp:RequiredFieldValidator>
                         <asp:TextBox ID="tbAdress" runat="server" CssClass="my-txt-box" placeholder="Adress"></asp:TextBox>
                         <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator4"
                            ControlToValidate="tbZipcode"
                            ForeColor ="Red"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Fyll i ditt postnummer!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">                       
                         </asp:RequiredFieldValidator>
                         <asp:TextBox ID="tbZipcode" runat="server" CssClass="my-txt-box" placeholder="Postnummer"></asp:TextBox>
                         <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator5"
                            ControlToValidate="tbCity"
                            ForeColor ="Red"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Fyll i din stad!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">                       
                         </asp:RequiredFieldValidator>
                         <asp:TextBox ID="tbCity" runat="server" CssClass="my-txt-box" placeholder="Postort"></asp:TextBox>
                     </div>
                     <div class="thirdBox">
                         <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator6"
                            ControlToValidate="tbEmail"
                            ForeColor ="Red"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Fyll i din email!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">                       
                         </asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator 
                            ID="regExValidatorEmail" 
                            ForeColor="Red" 
                            Font-Size="Medium" 
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ControlToValidate="tbEmail" 
                            runat="server" 
                            ErrorMessage="Felaktigt epost format"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup"> 
                </asp:RegularExpressionValidator>
                         <asp:TextBox ID="tbEmail" runat="server" CssClass="my-txt-box" placeholder="Email"></asp:TextBox>
                         <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator7"
                            ControlToValidate="tbPassword"
                            ForeColor ="Red"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Fyll i ett lösenord!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">                       
                         </asp:RequiredFieldValidator>
                         <asp:TextBox ID="tbPassword" runat="server" CssClass="my-txt-box" placeholder="Lösenord"></asp:TextBox>
                         <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator8"
                            ControlToValidate="tbConfirmPassword"
                            ForeColor ="Red"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Får inte lämnas tomt!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">                       
                         </asp:RequiredFieldValidator>
                         <asp:CompareValidator 
                            id="comparePasswords" 
                            runat="server"
                            foreColor="Red"
                            font-Sie="Medium"
                            ControlToCompare="tbPassword"
                            ControlToValidate="tbConfirmPassword"
                            ErrorMessage="Lösenorden stämmer inte överens!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">
                         </asp:CompareValidator>
                         <asp:TextBox ID="tbConfirmPassword" runat="server" CssClass="my-txt-box" placeholder="Bekräfta Lösenord"></asp:TextBox>
                     </div>
                         <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator10"
                            ControlToValidate="tbhcp"
                            ForeColor ="Red"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Fyll i ditt handikapp!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">                       
                         </asp:RequiredFieldValidator>
                         <asp:TextBox ID="tbhcp" runat="server" CssClass="my-txt-box" placeholder="Handikapp"></asp:TextBox>                 
                         <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator9"
                            ControlToValidate="DdlKon"
                            ForeColor ="Red"
                            initialValue="Välj kön"
                            runat="server"
                            Font-Size="Medium"
                            ErrorMessage="Välj kön!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">                       
                         </asp:RequiredFieldValidator>
                         <asp:DropDownList ID="DdlKon" CssClass="DropDown" runat="server">
                             <asp:ListItem>V&#228;lj k&#246;n</asp:ListItem>
                             <asp:ListItem>Man</asp:ListItem>
                             <asp:ListItem>Kvinna</asp:ListItem>
                         </asp:DropDownList>                        
                         <asp:RequiredFieldValidator 
                            ID="validatorKon" 
                            ControlToValidate="dropDownMembertype" 
                            InitialValue="Välj medlemstyp" 
                            ForeColor="Red" 
                            Font-Size="Medium"  
                            runat="server" 
                            ErrorMessage="Du måste välja medlemstyp!"
                            display="Dynamic"
                            ValidationGroup="RegisterGroup">
                        </asp:RequiredFieldValidator>                                                                                                                                                                                                                                  
                     <asp:DropDownList ID="dropDownMembertype" runat="server" CssClass="DropDown"></asp:DropDownList>                                                                          
                     <asp:Button ID="Button2" runat="server" Text="Ansök om medlemskap" Cssclass="my-button" placeholder="Hej" OnClick="Button2_Click" ValidationGroup="RegisterGroup"/><br /><br />                                     
                   </div>
                </div>
            </div>
     </section>
       <!-- Footer ================================================== -->
    <section class="container" id="section-footer">
      <div class="content">
        <div class="contentRow">      

          <div class="fullBox" id="footer">        
            <p class="foot-text">HÅLSLAGET GK</p>

            <div class="halfBox">
              <a class="phone-links" href="callto:#">
              <span class="glyphicon glyphicon-phone" aria-hidden="true"></span><br>
              +46 (0)555 98 98 99</a>
            </div>

            <div class="halfBox">
              <a class="mail-links"href="#" target="_top">              
              <span class="glyphicon glyphicon-envelope" aria-hidden="true"></span><br> HÅLSALGETGK@EMAIL.COM</a>
            </div>
          </div>
      </div>
      </div>
    </section>


    </form>
</body>
</html>

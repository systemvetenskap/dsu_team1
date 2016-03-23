    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Team_1_Halslaget_GK.deafult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8"/>
      <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
      <meta name="description" content="En skoluppgift"/>
      <meta name="viewport" content="width=device-width,user-scalable=no,initial-scale=1, maximum-scale=1, minimum-scale=1.0" />

      <!--<link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon"/>
      <link rel="icon" href="img/favicon.ico" type="image/x-icon"/>-->

      <meta name="author" content="Team 1, Borgenstam, Cederström, Drysén, Gustavsson, Hyllengren, Rosenlind"/>
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
<div id="fb-root"> </div>
<script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_GB/sdk.js#xfbml=1&version=v2.5";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
              <li onclick="scrolltoBookings();"><a href="#">TÄVLINGAR</a></li>
              <li onclick="scrolltoNews();"><a href="#">NYHETER</a></li>                                                                          
              <li onclick="scrolltoRegister();"><a href="#">BLI MEDLEM</a></li>  
            </ul>
            <ul class="main-navbar right">
              <li onclick="Openoverlay();"><a href="#">LOGGA IN</a></li>                               
            </ul>
            
            <a href="#open-menu" class="open-menu-link">☰ MENY</a>
            <div class="responsive-navbar-holder" id="open-menu">
              <ul class="responsive-navbar">
                <li><a  href="#">☰ STÄNG MENY</a></li>
                <li onclick="Openoverlay();"><a href="#">LOGGA IN</a></li>                                  
              </ul>
            </div>
        </div>
      </div>
    </section>

    <!--------------------------------------- Header ================================================== -->

    <section class="container" id="head-seaction">
      <div class="content" id="header-content">
       <div class="logoContainer">
          <img class="header-logo" src="img/golf.jpg" alt="Headimage" title="Fint landskap"/>
        </div> 
      </div>
    </section> 
     
     <!--------------------------------------- NEWS ================================================== -->
      
     <section class="container">
        <div class="content">
            <div class="contentRow">
                        <div class="fullBox bookings">
                            <div class="page-title"><h1>Tävlingar</h1></div>
                                <div class="halfBox">
                                    <div class="tavlingsBox">
                                    <asp:GridView ID="gvComp" runat="server" DataKeyNames="id" CssClass="Grid" GridLines="None" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="namn" HeaderText="Namn" SortExpression="id" />
                                            <asp:BoundField DataField="datum" HeaderText="Datum" DataFormatString="{0:dd-MM-yyyy}" />
                                            <asp:BoundField DataField="starttid" HeaderText="Start" DataFormatString="{0:HH:mm}" /> 
                                            <asp:BoundField DataField="type" HeaderText="Tävlingstyp" />                                                                    
                                        </Columns>
                                    </asp:GridView>
                                        </div>
                                    <asp:Label ID="lblcomp" runat="server" Text=""></asp:Label>
                                </div>
                            <div class="halfBox">
                            <div class="weatherBox">
                                <div id="c_d099872e047108ee78adbb22d9a16f7a" class="completo"><h2 style="color: #000000; margin: 0 0 3px; padding: 2px; font: bold 13px/1.2 Verdana; text-align: center;">Väder Östersund</h2></div>
                                <script type="text/javascript" src="http://www.klart.se/widget/widget_loader/d099872e047108ee78adbb22d9a16f7a"></script>
                                <div class="resultatlink">
                                    <p><a href="result.aspx" class="link" >Här </a>kan du se resultat på tidigare tävlingar!</p>  
                                </div>                                                          
                            </div>                                                             
                            </div>
                       </div> 

    <!--------------------------------------- TÄVLINGAR/VÄDER ================================================== -->

                        <div class="fullBox news">
                    <div class="page-title"><h1>Nyheter</h1></div>                  
                    <div class="fullBox" runat="server" id="newsdiv"></div>                       
                </div>                                    
                    </div>  
                </div>         
        </section>

     <!--------------------------------------- BLI MEDLEM ================================================== -->

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
             <asp:Panel ID="Panel1" runat="server" DefaultButton="Button2">
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
                         <asp:TextBox ID="tbPassword" runat="server" CssClass="my-txt-box" TextMode="Password" placeholder="Lösenord"></asp:TextBox>
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
                         <asp:TextBox ID="tbConfirmPassword" runat="server" CssClass="my-txt-box" TextMode="Password" placeholder="Bekräfta Lösenord"></asp:TextBox>
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
                     <asp:DropDownList ID="dropDownMembertype" runat="server" CssClass="DropDown">
                         <asp:ListItem>V&#228;lj medlemstyp</asp:ListItem>
                         <asp:ListItem>Junior 0 - 12 &#229;r</asp:ListItem>
                         <asp:ListItem>Junior 13 - 21 &#229;r</asp:ListItem>
                         <asp:ListItem>Studerande</asp:ListItem>
                         <asp:ListItem>Senior</asp:ListItem>
                     </asp:DropDownList>                                                                          
                     <asp:Button ID="Button2" runat="server" Text="Ansök om medlemskap" Cssclass="my-button" placeholder="Hej" OnClick="Button2_Click" ValidationGroup="RegisterGroup"/><br /><br />                                     
                   </div>
                 </asp:Panel>
                </div>
            </div>
     </section>
   </ContentTemplate>
  </asp:UpdatePanel>

       <!------------------------------------------- Footer ================================================== -->

    <section class="container" id="section-footer">
      <div class="content">
        <div class="contentRow">      

          <div class="fullBox" id="footer">        
            <p class="foot-text">HÅLSLAGET GK</p>

                <div class="thirdBox">
                    <h3 class="foot-h3"><strong>KONTAKT</strong></h3>
                    <br />
                    <p class="p-footer">HÅLSLAGET GK</p>
                    <p class="p-footer">GATAN 12</p>
                    <p class="p-footer">12345</p>
                    <p class="p-footer">ÖSTERSUND</p>
                    <br />
                    <p><a class="phone-links" href="callto:#"><span class="glyphicon glyphicon-phone" aria-hidden="true"></span>+46 (0)555 98 98 99</a></p>
                    <p><a class="mail-links"href="#" target="_top"><span class="glyphicon glyphicon-envelope" aria-hidden="true"></span>HÅLSALGETGK@EMAIL.COM</a></p>
                </div>

                <div class="thirdBox">
                    <h3 class="foot-h3"><strong>GILLA OSS PÅ FACEBOOK</strong></h3>
                    <div class="facebookBoxFoot">
                        <div class="fb-follow" data-href="https://www.facebook.com/zuck" data-width="" data-height="300" data-layout="standard" data-show-faces="true"></div>
                    </div>
                </div>

                <div class="thirdBox">
                    <h3 class="foot-h3"><strong>HITTA HIT</strong></h3>
                    <div class="gMap">
                        <iframe id="gMapIframe" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d57614.47445274595!2d14.5815931701714!3d63.17533576111594!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x466fb846d4f93091%3A0x4adec23d33cfdcde!2s%C3%96stersund!5e0!3m2!1ssv!2sse!4v1458643293334" width="" height="300" frameborder="0" style="border:0" allowfullscreen></iframe>            
                    </div>
                </div>

            </div>
          </div>
      </div>
    </section>
    
     <section class="container" style="background-color: #191919;">
      <div class="content">
        <div class="contentRow">      
            <p style="color: #4c4c4c; text-align: center; margin: 1em;"><strong>TEAM 1 © 2016</strong></p>
          </div>
      </div>
    </section>

    </form>
</body>
</html>

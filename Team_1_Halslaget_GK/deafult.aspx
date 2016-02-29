<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deafult.aspx.cs" Inherits="Team_1_Halslaget_GK.deafult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/deafultstyle.css" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="css/style.css"/>
    <link type="text/css" rel="stylesheet" href="font.css"/> 
    <link type="text/css" rel="stylesheet" href="Glyphicons.css"/> 
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
       <asp:TextBox ID="TextBox1" runat="server" placeholder="Email" CssClass="my-txt-box"></asp:TextBox>
       <br />
       <br />      
       <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="Lösenord" CssClass="my-txt-box" ></asp:TextBox>
       <br />
       <br />
       <asp:Button ID="signInBtn" runat="server" Text="Logga in" CssClass="my-button" />
       </div>   

   </div>
  </div>
  <!-- Navbar ================================================== -->
    <section class="container" id="navbar-section">
      <div class="content">
        <div class="contentRow">
            
            <ul class="main-navbar">
              <li><a href='#'>HEM</a></li>
              <li onclick="scrolltoNews();"><a href="#">NYHETER</a></li>                                                                  
              <li onclick="scrolltoNTop();"><a href="#">LEDIGA TIDER</a></li> 
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
                    <div class="halfBox">                  
                    <div class="News">
                        <h1>Påhittad Nyhet!</h1>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam lectus lectus, ultricies eget lacus et, ullamcorper viverra est. Nullam hendrerit ex eget risus commodo viverra. Aliquam malesuada felis mauris, vitae posuere mauris faucibus at. Donec congue, neque eu sodales efficitur, leo nisi dictum leo, id facilisis nisl metus nec lectus. Nulla pulvinar sed enim vel porta. Phasellus aliquet lacus ut nibh interdum eleifend. Mauris eros massa, cursus ac lectus in, vestibulum molestie elit. Etiam faucibus nulla vitae turpis consectetur rhoncus.

Sed ac dapibus ex, id commodo nibh. Phasellus vitae volutpat elit, et semper augue. Phasellus elit sem, posuere et ligula nec, mattis suscipit tortor. Curabitur at lacus lacus. Quisque feugiat finibus condimentum. Nam eu eleifend ante, at fermentum velit. Proin non porttitor odio. Curabitur pulvinar pellentesque nibh id bibendum. Nulla consectetur laoreet est fringilla bibendum. Proin sed vehicula risus. Phasellus eleifend risus ut ex gravida, a porta magna rutrum. Maecenas non enim ultricies, facilisis eros sed, consectetur purus. Cras laoreet quis lorem ut hendrerit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur eu feugiat felis, in consequat ipsum.

Nunc sollicitudin lacinia accumsan. Curabitur semper diam eu nibh molestie facilisis. Sed porttitor pellentesque turpis fermentum commodo. Donec aliquam arcu quis mi lacinia, euismod congue orci cursus. Cras quis sollicitudin lectus. Integer sed facilisis velit. Cras non sapien lectus. Quisque pretium lacus ac pellentesque varius.

Nullam id blandit lorem. Nam congue ante lacinia, vestibulum diam sit amet, facilisis est. Etiam nec rutrum mi. Duis interdum eros ut congue tempus. Ut vitae risus a enim pellentesque dignissim faucibus sagittis nibh. Praesent sem ipsum, placerat id magna vel, faucibus pharetra lorem. Donec consectetur risus vel sodales condimentum. Donec augue nisl, convallis id nunc ut, semper ullamcorper ligula. Nulla suscipit dolor sed tellus convallis condimentum. Nam sit amet tortor vel leo egestas semper. Donec quis sem eleifend, venenatis sem eu, porta ligula. Vivamus et pretium tellus. Nullam congue felis fermentum quam volutpat, ut cursus est pellentesque. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.

Maecenas eu enim metus. Suspendisse eleifend enim at diam tempus auctor. Maecenas eleifend lacus ac lobortis vulputate. Nulla bibendum feugiat eleifend. Sed in magna tortor. Aenean congue auctor leo, vitae volutpat velit eleifend nec. Cras ac arcu at orci ullamcorper sagittis. Suspendisse varius sem non sapien commodo bibendum. Etiam ac erat vitae mi dapibus egestas a non urna. Duis pretium ac metus a finibus. Donec id egestas orci, a pretium tellus. Vestibulum eleifend erat sapien. Integer lorem metus, luctus ut dolor sed, accumsan dignissim mauris.</p>
                    </div>
                    </div>
                    <div class="halfBox">  
                    <h1>En annan påhittad nyhet</h1>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam lectus lectus, ultricies eget lacus et, ullamcorper viverra est. Nullam hendrerit ex eget risus commodo viverra. Aliquam malesuada felis mauris, vitae posuere mauris faucibus at. Donec congue, neque eu sodales efficitur, leo nisi dictum leo, id facilisis nisl metus nec lectus. Nulla pulvinar sed enim vel porta. Phasellus aliquet lacus ut nibh interdum eleifend. Mauris eros massa, cursus ac lectus in, vestibulum molestie elit. Etiam faucibus nulla vitae turpis consectetur rhoncus.

Sed ac dapibus ex, id commodo nibh. Phasellus vitae volutpat elit, et semper augue. Phasellus elit sem, posuere et ligula nec, mattis suscipit tortor. Curabitur at lacus lacus. Quisque feugiat finibus condimentum. Nam eu eleifend ante, at fermentum velit. Proin non porttitor odio. Curabitur pulvinar pellentesque nibh id bibendum. Nulla consectetur laoreet est fringilla bibendum. Proin sed vehicula risus. Phasellus eleifend risus ut ex gravida, a porta magna rutrum. Maecenas non enim ultricies, facilisis eros sed, consectetur purus. Cras laoreet quis lorem ut hendrerit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur eu feugiat felis, in consequat ipsum.

Nunc sollicitudin lacinia accumsan. Curabitur semper diam eu nibh molestie facilisis. Sed porttitor pellentesque turpis fermentum commodo. Donec aliquam arcu quis mi lacinia, euismod congue orci cursus. Cras quis sollicitudin lectus. Integer sed facilisis velit. Cras non sapien lectus. Quisque pretium lacus ac pellentesque varius.

Nullam id blandit lorem. Nam congue ante lacinia, vestibulum diam sit amet, facilisis est. Etiam nec rutrum mi. Duis interdum eros ut congue tempus. Ut vitae risus a enim pellentesque dignissim faucibus sagittis nibh. Praesent sem ipsum, placerat id magna vel, faucibus pharetra lorem. Donec consectetur risus vel sodales condimentum. Donec augue nisl, convallis id nunc ut, semper ullamcorper ligula. Nulla suscipit dolor sed tellus convallis condimentum. Nam sit amet tortor vel leo egestas semper. Donec quis sem eleifend, venenatis sem eu, porta ligula. Vivamus et pretium tellus. Nullam congue felis fermentum quam volutpat, ut cursus est pellentesque. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.

Maecenas eu enim metus. Suspendisse eleifend enim at diam tempus auctor. Maecenas eleifend lacus ac lobortis vulputate. Nulla bibendum feugiat eleifend. Sed in magna tortor. Aenean congue auctor leo, vitae volutpat velit eleifend nec. Cras ac arcu at orci ullamcorper sagittis. Suspendisse varius sem non sapien commodo bibendum. Etiam ac erat vitae mi dapibus egestas a non urna. Duis pretium ac metus a finibus. Donec id egestas orci, a pretium tellus. Vestibulum eleifend erat sapien. Integer lorem metus, luctus ut dolor sed, accumsan dignissim mauris.</p>
                </div>
                   <div/>
            </div/>
        </section>
     <section class="container">
         <div class="content">
             <div class="contentRow">
                 <div class="registerbox">
                     <h2>Bli medlem</h2>
                     <asp:TextBox ID="tbName" runat="server" CssClass="my-txt-box" placeholder="Namn"></asp:TextBox>
                     <asp:TextBox ID="tbAdress" runat="server" CssClass="my-txt-box" placeholder="Adress"></asp:TextBox>
                     <asp:TextBox ID="tbEmail" runat="server" CssClass="my-txt-box" placeholder="Email"></asp:TextBox><br />
                     <asp:TextBox ID="tbLastname" runat="server" CssClass="my-txt-box" placeholder="Efternamn"></asp:TextBox>
                     <asp:TextBox ID="tbCity" runat="server" CssClass="my-txt-box" placeholder="Postort"></asp:TextBox>
                     <asp:TextBox ID="tbPassword" runat="server" CssClass="my-txt-box" placeholder="Lösenord"></asp:TextBox><br />   
                     <asp:TextBox ID="tbPonenumber" runat="server" CssClass="my-txt-box" placeholder="Telefonnummer"></asp:TextBox>                                           
                     <asp:TextBox ID="tbZipcode" runat="server" CssClass="my-txt-box" placeholder="Postnummer"></asp:TextBox>
                     <asp:TextBox ID="tbConfirmPassword" runat="server" CssClass="my-txt-box" placeholder="Bekräfta Lösenord"></asp:TextBox><br /><br />
                                                            
                     <asp:Button ID="Button2" runat="server" Text="Bli medlem" Cssclass="my-button"/>
                     
                 </div>
             </div>
         </div>
     </section>
       <!-- Footer ================================================== -->
    <section class="container" id="section-footer">
      <div class="content">
        <div class="contentRow">      

          <div class="fullBox" id="footer">        
            <p class="foot-text">HÅLSAGET GK</p>

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

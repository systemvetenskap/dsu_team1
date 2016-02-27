<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deafult.aspx.cs" Inherits="Team_1_Halslaget_GK.deafult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/deafultstyle.css" rel="stylesheet" />
</head>
<body>

 <form id="form1" runat="server">
  <div class="logincontainer">
   <div class="loginbox">
       <br />
       <h2>Välkommen</h2> 
       <br />
       <div class="textboxcontainer">
       <asp:TextBox ID="TextBox1" runat="server" placeholder="Email" CssClass="textbox"></asp:TextBox>
       <br />
       <br />      
       <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="Lösenord" CssClass="textbox" ></asp:TextBox>
       </div>   

   </div>
  </div>
  <!-- Navbar ================================================== -->
    <section class="container" id="navbar-section">
      <div class="content">
        <div class="contentRow">
            
            <ul class="main-navbar">
              <li><a class="active" href='#'>HEM</a></li>
              <li><a href="#">NYHETER</a></li>                                                                  
              <li><a href="#">LEDIGA TIDER</a></li> 
              <li><a href="#">BLI MEDLEM</a></li>  
            </ul>
            <ul class="main-navbar right">
              <li><a href="#">LOGGA IN</a></li>                               
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
          <img class="header-logo" src="img/golf2.jpg" alt="Headimage" title="Fint landskap"/>
        </div> 
      </div>
    </section>

        <section class="container">
            <div class="content">
                <div class="contentRow">
                    <div class="fullBox">
                        <div class="halfBox">
                        </div>
                        <div class="halfBox"> 
                        </div>
                    </div>
                </div>
            </div>
        </section>



    </form>
</body>
</html>

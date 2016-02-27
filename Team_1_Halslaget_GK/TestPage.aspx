<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="Team_1_Halslaget_GK.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--Test page, just a testpage for show purpose on how a masterpage works. Feel free to poke around and try things. -->
    <!--Stuff here in the head can be certain javascripts that is only applicable on this page and not other pages -->
    <title>This is the head on the testpage, this is where you put custom things that you need in the head</title>
    <link type="text/css" rel="stylesheet" href="css/TestPageCss.css"/> <!-- This is for example a link to a custom css file only to be found and used on this page -->

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="fullBox" id="page-title">
            <h1>Test Page</h1>
        </div>
        <div class="fullBox"> 
            <br />       
            <p>
            On the master page there is currecntly a main navbar, a header and a footer and if you look on line 25, 27, 73, 75 you'll find a tag that looks something like this:  
            asp: Content Place Holder ID="Content Place Holder1" runat   =  "server" 
            <br />
            and a closing tag that looks like this : /asp: ContentPlaceHolder >
            <br />
            <br />
            If you look at line 2,8, 10 and ~100 here on the testpage you'll find the following tags: < asp:content >< /asp:content >.
            <br />
            This is where you make your custom things for a certain page. Between line 2 and 8 is where you put custom things that is neede to be in the head for a certain page, perhaps a 
            certain script or some other things.
            <br />           
            <br />
            And here in the body you put some divs and other stuff that is necessary to style the page that you are working with.
            A master page sets the "bone structure" of the website, in this case here right now its a main navbar, a header and a footer. 
            And the space between is customizable 
            <br />
            <br />
            So how do you make a webform with a master page?
             <br />       
            Easy!         <br />
            1. Right click on the project name, in this case: Team_1_Halslaget_GK        <br />
            2. Then hover over add for submenu        <br />
            3. Number 4 from the bottom "Webform with master page"        <br />
            4. Name your webform        <br />
            5. In the right box click to choose "MasterPage.master"        <br />
            6. Click ok.        <br />
            7. Then style your webform!        <br />
            8. ???        <br />
            9. Profit?!         <br />
            </p>
            <br />
        </div>

</asp:Content>

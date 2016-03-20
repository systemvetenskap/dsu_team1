﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="Team_1_Halslaget_GK.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="css/Messages.css"/>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>   
    <script src="ja/Scrollto.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="fullBox">
        <h3 class="home-h3">Meddelanden</h3>
    </div>
    <div class="fullBox fullbox-message">
        <div class="quarterBox messages-list">
            <asp:TextBox ID="TextBoxSearch" runat="server" placeholder="Sök" CssClass="my-txt-box txt-box-search" OnTextChanged="TextBoxSearch_TextChanged"></asp:TextBox>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <Triggers><asp:AsyncPostBackTrigger ControlID="TextBoxSearch" runat="server" EventName="TextChanged"/></Triggers>
                <ContentTemplate>
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                    
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="grad">                   
                           <asp:LinkButton ID="LinkBtnShowFullMessage" runat="server" OnClick="LinkBtnShowFullMessage_Click" CssClass="linkbtn-empty" >
                                <div class="short-message-info-box">
                                    <p id="frommember" runat="server" class="name"><%#Eval ("fornamn") %><%#Eval ("efternamn") %></p>
                                    <p id="date" class="smallp" runat="server"><%#Eval ("nytid") %></p>
                                </div>
                                <div class="short-message-box">
                                    <p><%#Eval ("meddelande") %></p>
                                    <asp:HiddenField ID="HiddenFieldMemberID" runat="server" Value=<%#Eval ("id") %>/>
                                </div>
                            </asp:LinkButton>                  
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>

                    </FooterTemplate>                                                                               
                </asp:Repeater>
               </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div class="sevenFiveBox">                    
                    <div class="message-info-box">
                        <p id="frommember2" class="nobreak" runat="server"></p>
                        <p id="date2" runat="server" class="nobreak"></p>
                        <asp:Label ID="LabelIDto" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div class="conversation-box" runat="server">
                        <div id="message-box">
                            <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
                                <ItemTemplate>
                                    <div id="messagerow" class="message-row" runat="server">
                                        <div class="message-in-row" id="messageinrow" runat="server">
                                            <div class="message-border" id="messageborder" runat="server">
                                                <p id="message" runat="server"><%#Eval ("meddelande") %></p>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="HiddenFieldFromID" runat="server" Value=<%#Eval ("from_medlem") %>/>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <div class="fullBox fullBox-message-send">
                            <div class="sevenFiveBox sevenFiveBox-message">
                                <asp:TextBox ID="TextBoxReply" runat="server" CssClass="my-txt-box txt-box-reply" Visible="false" TextMode="MultiLine" OnTextChanged="TextBoxReply_TextChanged"></asp:TextBox>
                            </div>
                            <div class="quarterBox quarterBox-message">
                                <asp:Button ID="ButtonReply" runat="server" Text="Skicka" Visible="false" CssClass="my-button bt-reply" onclick="ButtonReply_Click"/>
                            </div>
                        </div>
                    </div>
                </div>           
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
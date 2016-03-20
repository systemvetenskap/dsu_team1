<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Mobile.Master" CodeBehind="MobileIndex.aspx.cs" EnableEventValidation="true" Inherits="Team_1_Halslaget_GK.MobileLeaderboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="test" runat="server" OnDataBinding="buttonNext_Click">
        <ContentTemplate>
            <div id="welcome">
                <div class="mobileBox text-center font-bold">
                    <asp:Label ID="LabelTavlingsID" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div id="holeNr" class="text-center">
                <div class="inline">
                    <p>Hål nr: </p>
                    <asp:Label ID="LabelHole" runat="server" Text="" CssClass="font-bold"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="" CssClass="font-bold"></asp:Label>
                </div>
                <div class="inline">
                    <asp:Label ID="LabelFeedback" runat="server" Text="" CssClass="font-bold"></asp:Label>
                </div>
                <div class="inline">
                    <p>Totala slag: </p>
                    <asp:Label ID="LabelAntalSlag" runat="server" Text="" CssClass="font-bold"></asp:Label>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="buttonNext" EventName="Click"/>
        </Triggers>
    </asp:UpdatePanel>
    <div id="flexMobile" class="mobileBox">
        <p class="text-center font-bold">Ange slag:</p>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form" autocomplete="off" Operator="DataTypeCheck" Type="Integer"></asp:TextBox><br />
        <asp:Button ID="buttonNext" runat="server" Text="Next" CssClass="my-button" OnClick="buttonNext_Click" />
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ScorecardAdmin.aspx.cs" Inherits="Team_1_Halslaget_GK.ScorecardAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox">
        <h1>SCORECARD</h1>
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
   </div>

    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click"/>

</asp:Content>

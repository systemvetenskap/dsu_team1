<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ScorecardAdmin.aspx.cs" Inherits="Team_1_Halslaget_GK.ScorecardAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="halfBox">
        <asp:Label ID="Label1" runat="server" Text="Hålslaget GK, Scorkort"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Hål 1 - 9"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox3" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox4" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox5" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox6" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox7" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox8" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox9" CssClass="my-txt-box" runat="server"></asp:TextBox>
    </div>
   <div class="halfBox">
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Hål 10 - 18"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox10" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox11" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox12" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox13" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox14" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox15" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox16" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox17" CssClass="my-txt-box" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox18" CssClass="my-txt-box" runat="server"></asp:TextBox>

   </div>

            <br />
        <br />
        <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="Beräkna Slope för Hålslaget GK :"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Fyll i Hcp: "></asp:Label>
        <asp:TextBox ID="TextBox_Hcp" runat="server"></asp:TextBox>
        <asp:Button ID="Beräkna_Slope" runat="server" Text="Button" OnClick="Beräkna_Slope_Click" />
        <br />
        <br />
        <br />
</asp:Content>

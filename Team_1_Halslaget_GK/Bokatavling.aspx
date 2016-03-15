<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Bokatavling.aspx.cs" Inherits="Team_1_Halslaget_GK.Bokatavling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/BokatavlingCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
  <!-- Main Page ================================================== -->       
            <div class="fullBox page-title"><h1>Tävlingar</h1></div>           
            <div class="halfBox">

                <!------------------ Visa Tävlingar ---------------->
                 
                <div class="halfBox search-box">
                    <div class="halfBox">
                        <asp:TextBox ID="tbsearchTavling" CssClass="my-txt-box " Placeholder="Sök" runat="server"></asp:TextBox>
                    </div>                    
                </div>   
                <div class="halfBox search-button">
                    <asp:Button ID="BtnSearch" CssClass="my-button" runat="server" Text="Sök" OnClick="BtnSearch_Click1" />
                </div>              
                <br />
                <asp:RadioButtonList ID="rdlTavlingType" CssClass="my-radiobutton-list" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlTavlingType_SelectedIndexChanged">
                    <asp:ListItem>Alla</asp:ListItem>
                    <asp:ListItem>Singeltävlingar</asp:ListItem>
                    <asp:ListItem>Lagtävlingar</asp:ListItem>
                </asp:RadioButtonList>
                <br />                                 
                <asp:GridView ID="gvTavlingar" DataKeyNames="id" CssClass="Grid" GridLines="None" runat="server" AutoGenerateColumns="false"  OnSelectedIndexChanged="gvTavlingar_SelectedIndexChanged">
                           <Columns>
                                    <asp:BoundField DataField="namn" HeaderText="Namn" SortExpression="id" />
                                    <asp:BoundField DataField="datum" HeaderText="Datum" DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="starttid" HeaderText="Start" DataFormatString="{0:HH:mm}" />                          
                                    <asp:CommandField ShowSelectButton="true" />
                            </Columns>
                    </asp:GridView>
            </div>
            <!------------------ Visa Tävlingasinfo och anmäl medlem ----------------> 
            <div class="halfBox">
                <h3><asp:Label ID="lblTavlingNamn" runat="server" Text="Namn"></asp:Label></h3><br />
                <h4><asp:Label ID="lblTavlingTyp" runat="server" Text="Typ"></asp:Label></h4><br />
                <p><asp:Label ID="lblTavlingDesc" runat="server" Text="Desc"></asp:Label></p><br /><br />
                <asp:TextBox ID="tbgolfid1" CssClass="my-txt-box" placeholder="Golf-ID" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2"
                    ControlToValidate="tbgolfid2"
                    ForeColor ="Red"
                    runat="server"
                    Font-Size="Medium"
                    ErrorMessage="Ange Golf-ID"
                    display="Dynamic"
                    ValidationGroup="typelaggroup">                       
                </asp:RequiredFieldValidator>
                <div id="teamtb" runat="server">
                <asp:TextBox ID="tbgolfid2" CssClass="my-txt-box"  placeholder="Golf-ID" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3"
                    ControlToValidate="tbgolfid3"
                    ForeColor ="Red"
                    runat="server"
                    Font-Size="Medium"
                    ErrorMessage="Ange Golf-ID"
                    display="Dynamic"
                    ValidationGroup="typelaggroup">                       
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="tbgolfid3" CssClass="my-txt-box"  placeholder="Golf-ID" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4"
                    ControlToValidate="tbgolfid4"
                    ForeColor ="Red"
                    runat="server"
                    Font-Size="Medium"
                    ErrorMessage="Ange Golf-ID"
                    display="Dynamic"
                    ValidationGroup="typelaggroup">                       
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="tbgolfid4" CssClass="my-txt-box"  placeholder="Golf-ID" runat="server"></asp:TextBox><br /><br /></div>
                <asp:Button ID="btnConfirm" CssClass="my-button" runat="server" Text="Anmäl mig" OnClick="btnConfirm_Click" /><br />
                <asp:Button ID="btnConfirm2" ValidationGroup="typelaggroup" CssClass="my-button" runat="server" Text="Anmäl lag" OnClick="btnConfirm2_Click"/>
                <asp:Button ID="btnRemove" CssClass="my-button" runat="server" Text="Ta bort mig från tävlingen" OnClick="btnRemove_Click" />  
                <asp:Button ID="BtnRemove2" CssClass="my-button" runat="server" Text="Ta bort laget från den här tävlingen!" OnClick="BtnRemove2_Click" />          
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

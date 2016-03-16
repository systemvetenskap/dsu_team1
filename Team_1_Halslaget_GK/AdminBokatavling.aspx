<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminBokatavling.aspx.cs" Inherits="Team_1_Halslaget_GK.AdminBokatavling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/AdminBokatavlingCss.css" rel="stylesheet" />
    <script src="ja/TextboxChangeColor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="fullBox page-title"><h1>Tävlingar</h1></div>    
           
    <!------------------ Visa Tävlingar ----------------> 

    <div class="halfBox">
    <div class="halfBox">
    <asp:TextBox ID="tbSearchComp" CssClass="my-txt-box" runat="server" placeholder="Sök"></asp:TextBox>       
    </div>   
    <div class="halfBox">
    <asp:Button ID="BtnSearch" runat="server" Text="Sök" CssClass="my-button" />   
    </div>      
        <div class="fullBox GridBox">
         <asp:GridView ID="gvTavlingar" DataKeyNames="id" CssClass="Grid" GridLines="None" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvTavlingar_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="namn" HeaderText="Namn" SortExpression="id" />
                <asp:BoundField DataField="datum" HeaderText="Datum" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="starttid" HeaderText="Start" DataFormatString="{0:HH:mm}" />                          
                <asp:CommandField ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
        </div>
    </div>

    <!------------------ Visa Tävlingasinfo och anmäl medlem ----------------> 

    <div class="halfBox">
                <h3><asp:Label ID="lblTavlingNamn" runat="server" Text="Namn"></asp:Label></h3><br />
                <h4><asp:Label ID="lblTavlingTyp" runat="server" Text="Typ"></asp:Label></h4><br />
                <p><asp:Label ID="lblTavlingDesc" runat="server" Text="Desc"></asp:Label></p><br /><br />
                <div id="teamtb" runat="server">
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5"
                    ControlToValidate="tbgolfid1"
                    ForeColor ="Red"
                    runat="server"
                    Font-Size="Medium"
                    ErrorMessage="Ange Golf-ID"
                    display="Dynamic"
                    ValidationGroup="typesingelgroup">                       
                </asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1"
                    ControlToValidate="tbgolfid1"
                    ForeColor ="Red"
                    runat="server"
                    Font-Size="Medium"
                    ErrorMessage="Ange Golf-ID"
                    display="Dynamic"
                    ValidationGroup="typelaggroup">                       
                </asp:RequiredFieldValidator>
                <asp:Label ID="lbltbgolfid1" runat="server" Text=""></asp:Label>          
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
                </asp:RequiredFieldValidator><asp:Label ID="lbltbgolfid2" runat="server" Text=""></asp:Label>              
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
                </asp:RequiredFieldValidator><asp:Label ID="lbltbgolfid3" runat="server" Text=""></asp:Label>  
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
                </asp:RequiredFieldValidator><asp:Label ID="lbltbgolfid4" runat="server" Text=""></asp:Label>  
                <asp:TextBox ID="tbgolfid4" CssClass="my-txt-box"  placeholder="Golf-ID" runat="server"></asp:TextBox><br /><br />
                </div>
                <asp:Button ID="btnConfirm"  ValidationGroup="typesingelgroup" CssClass="my-button" runat="server" Text="Anmäl medlem" OnClick="btnConfirm_Click" /><br />
                <asp:Button ID="btnConfirm2" ValidationGroup="typelaggroup" CssClass="my-button" runat="server" Text="Anmäl lag" OnClick="btnConfirm2_Click"/>
                <asp:Button ID="btnRemove" CssClass="my-button" runat="server" Text="Ta bort medlem från tävlingen"/>  
                <asp:Button ID="BtnRemove2" CssClass="my-button" runat="server" Text="Ta bort laget från den här tävlingen!" /> 
    </div>                   
</asp:Content>

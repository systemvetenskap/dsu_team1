<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminBokatavling.aspx.cs" Inherits="Team_1_Halslaget_GK.AdminBokatavling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/AdminBokatavlingCss.css" rel="stylesheet" />
    <script src="ja/TextboxChangeColor.js"></script>
    <script src="ja/hideShowSearch.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <br />
    <br />
    <br />
    

    <!------------------ Sök på medlemmar ---------------->

<div class="fullBox HiddenSearchBox">
    <div class="fullBox page-title"><h3>Sök på medlem</h3></div>    
    <div class="halfBox searchMargin">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="BtnSearchMember">
        <div class="halfBox SearchBox SearchBox2">
            <asp:TextBox ID="tbFullName" CssClass="my-txt-box" runat="server" placeholder="För och/eller efternamn"></asp:TextBox>
        </div>
        <div class="halfBox SearchBtn">
            <asp:Button ID="BtnSearchMember" CssClass="my-button" runat="server" Text="Sök" OnClick="BtnSearchMember_Click" />
        </div>               
    </asp:Panel> 
    </div>
    <div class="halfBox">
    <asp:Panel ID="Panel3" runat="server" DefaultButton="btnPickMember">
        <div class="halfBox SearchBox">
            <asp:ListBox ID="lbMembers" CssClass="my-list-box" runat="server" ></asp:ListBox>
        </div>
        <div class="halfBox SearchBtn SearchBtn2">
            <asp:Button ID="btnPickMember" CssClass="my-button" runat="server" Text="Lägg till" OnClicK="btnPickMember_Click"/>
        </div>            
    </asp:Panel>
    </div>

</div>
<div class="fullBox">
    <asp:Button ID="btnShowSearch" CssClass="my-button searchbtn" runat="server" Text="Sök medlem" OnClick="btnShowSearch_Click" />      
</div>
                  
    <!------------------ Visa Tävlingar ----------------> 

<div class="fullBox page-title"><h1>Tävlingar</h1></div>  
<asp:Panel ID="Panel2" runat="server" DefaultButton="BtnSearch">
    <div class="halfBox">
    <div class="halfBox SearchBox">
    <asp:TextBox ID="tbSearchComp" CssClass="my-txt-box" runat="server" placeholder="Sök"></asp:TextBox>       
    </div>   
    <div class="halfBox SearchBtn" >
    <asp:Button ID="BtnSearch" runat="server" Text="Sök" CssClass="my-button" OnClick="BtnSearch_Click"/>   
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
</asp:Panel>

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

        <!------------------ hiddens ----------------> 

        <asp:Label ID="hidden1" runat="server" Text="" Visible="false"></asp:Label>

    </div> 
</ContentTemplate>
</asp:UpdatePanel>               
</asp:Content>

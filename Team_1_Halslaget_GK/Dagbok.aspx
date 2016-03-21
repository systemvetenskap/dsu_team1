<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dagbok.aspx.cs" Inherits="Team_1_Halslaget_GK.Dagbok" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/DagbokCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="fullBox page-title">
                <h1>MIN DAGBOK</h1>
            </div>
            <div class="fullBox">
                <div class="quarterBox">
                    <div class="fullBox one-em-margin center-text">
                        <asp:Button ID="btnNewNote" CssClass="my-button" runat="server" Text="NYTT INLÄGG" OnClick="btnNewNote_Click" />
                    </div>
                    <p><asp:Label ID="lblNoNotesFound" runat="server" Text=""></asp:Label></p>
                    <asp:GridView ID="GridView1" AutoGenerateColumns="false" CssClass="Diary-Grid" GridLines="None" DataKeyNames="id" runat="server" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="date" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Datum" SortExpression="date" />
                            <asp:BoundField DataField="title" HeaderText="Titel" SortExpression="title" />
                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="False" />
                            <asp:CommandField ShowSelectButton="true" SelectText="Välj" />
                        </Columns>
                    </asp:GridView>

                    <div class="fullBox one-em-margin">
                        <div class="fullBox one-em-margin">
                            <p><strong>Sortera inlägg</strong></p>
                            <p>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label></p>
                        </div>
                        <div class="fullBox one-em-margin">
                            <asp:DropDownList ID="dropDownYear" CssClass="DropDown" runat="server" OnSelectedIndexChanged="dropDownYear_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="fullBox one-em-margin">
                            <asp:DropDownList ID="dropDownMonth" CssClass="DropDown" runat="server" OnSelectedIndexChanged="dropDownMonth_SelectedIndexChanged">
                                <asp:ListItem Value="00">Välj månad</asp:ListItem>
                                <asp:ListItem Value="01">Januari</asp:ListItem>
                                <asp:ListItem Value="02">Februari</asp:ListItem>
                                <asp:ListItem Value="03">Mars</asp:ListItem>
                                <asp:ListItem Value="04">April</asp:ListItem>
                                <asp:ListItem Value="05">Maj</asp:ListItem>
                                <asp:ListItem Value="06">Juni</asp:ListItem>
                                <asp:ListItem Value="07">Juli</asp:ListItem>
                                <asp:ListItem Value="08">Augusti</asp:ListItem>
                                <asp:ListItem Value="09">September</asp:ListItem>
                                <asp:ListItem Value="10">Oktober</asp:ListItem>
                                <asp:ListItem Value="11">November</asp:ListItem>
                                <asp:ListItem Value="12">December</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fullBox one-em-margin center-text">
                            <asp:Button ID="btnSort" runat="server" CssClass="my-button" Text="SORTERA" OnClick="btnSort_Click" />
                        </div>
                    </div>
                </div>
                <div class="sevenFiveBox" >
                    <div class="fullBox diary-padding">
                        <h3><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h3>
                        <br />
                    </div>
                    <div class="fullBox diary-padding" runat="server" id="diaryNoteDiv">

                    </div>
                    <div class="fullBox">
            <%--        <asp:ListView ID="ListView1" runat="server">
                            <ItemTemplate>
                                <p>
                                <asp:Label ID="lblListView" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                                </p>
                            </ItemTemplate>
                        </asp:ListView>--%>
                        <div class="fullBox page-title" style="margin-top: 2em;">
                            <h3>SCORECARD</h3>
                        </div>
                        <div class="halfBox center-text">
                            <p><strong>1. </strong>
                                <asp:Label ID="Label_1" runat="server" Text=""></asp:Label></p>
                            <p><strong>2. </strong>
                                <asp:Label ID="Label_2" runat="server" Text=""></asp:Label></p>
                            <p><strong>3. </strong>
                                <asp:Label ID="Label_3" runat="server" Text=""></asp:Label></p>
                            <p><strong>4. </strong>
                                <asp:Label ID="Label_4" runat="server" Text=""></asp:Label></p>
                            <p><strong>5. </strong>
                                <asp:Label ID="Label_5" runat="server" Text=""></asp:Label></p>
                            <p><strong>6. </strong>
                                <asp:Label ID="Label_6" runat="server" Text=""></asp:Label></p>
                            <p><strong>7. </strong>
                                <asp:Label ID="Label_7" runat="server" Text=""></asp:Label></p>
                            <p><strong>8. </strong>
                                <asp:Label ID="Label_8" runat="server" Text=""></asp:Label></p>
                            <p><strong>9. </strong>
                                <asp:Label ID="Label_9" runat="server" Text=""></asp:Label></p>
                            <p><strong>TOTALT: </strong>
                                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="halfBox center-text">
                            <p><strong>10. </strong>
                                <asp:Label ID="Label_10" runat="server" Text=""></asp:Label></p>
                            <p><strong>11. </strong>
                                <asp:Label ID="Label_11" runat="server" Text=""></asp:Label></p>
                            <p><strong>12. </strong>
                                <asp:Label ID="Label_12" runat="server" Text=""></asp:Label></p>
                            <p><strong>13. </strong>
                                <asp:Label ID="Label_13" runat="server" Text=""></asp:Label></p>
                            <p><strong>14. </strong>
                                <asp:Label ID="Label_14" runat="server" Text=""></asp:Label></p>
                            <p><strong>15. </strong>
                                <asp:Label ID="Label_15" runat="server" Text=""></asp:Label></p>
                            <p><strong>16. </strong>
                                <asp:Label ID="Label_16" runat="server" Text=""></asp:Label></p>
                            <p><strong>17. </strong>
                                <asp:Label ID="Label_17" runat="server" Text=""></asp:Label></p>
                            <p><strong>18. </strong>
                                <asp:Label ID="Label_18" runat="server" Text=""></asp:Label></p>
                            <p><strong>SCORE: </strong>
                                <asp:Label ID="lblScore" runat="server" Text=""></asp:Label></p>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

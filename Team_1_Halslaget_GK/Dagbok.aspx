<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dagbok.aspx.cs" Inherits="Team_1_Halslaget_GK.Dagbok" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/DagbokCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fullBox page-title">
        <h1>MIN DAGBOK</h1>
    </div>
    <div class="fullBox">
        <div class="quarterBox">
            <asp:GridView ID="GridView1" AutoGenerateColumns="false" CssClass="Diary-Grid" GridLines="None" DataKeyNames="id" runat="server" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="date" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Datum" SortExpression="date" />
                    <asp:BoundField DataField="title" HeaderText="Titel" SortExpression="title" />
                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="False" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Välj" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="sevenFiveBox" >
            <div class="fullBox">
                <h3><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h3>
                <br />
            </div>
            <div class="fullBox" runat="server" id="diaryNoteDiv">

            </div>
            <div class="fullBox">
    <%--        <asp:ListView ID="ListView1" runat="server">
                    <ItemTemplate>
                        <p>
                        <asp:Label ID="lblListView" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                        </p>
                    </ItemTemplate>
                </asp:ListView>--%>
                <div class="fullBox page-title">
                    <h3>SCORECARD</h3>
                </div>
                <div class="halfBox">
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
                <div class="halfBox">
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

</asp:Content>

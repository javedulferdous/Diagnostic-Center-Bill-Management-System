<%@ Page Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="PaymentUi.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.WebForm1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentContentPlaceHolder" runat="server">
    <div class="mainBody">
        <div class="heder_title">
            Pay Bill
        </div>
        <div class=" content_table ">
            <div class="content-info">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="billNoLabel" runat="server" Text="Bill No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="billNoTextBox" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="searchButton" CssClass="button" runat="server" Text="Search" OnClick="searchButton_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="margin: 15px auto; padding: 0 0 25px 130px;">
            <asp:GridView ID="typeNameGridView" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="False" OnRowDataBound="typeNameGridView_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <HeaderStyle CssClass="GridHeaderCol1"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TestName" HeaderText="Test Name" />
                    <asp:BoundField DataField="Fee" HeaderText="Fee" />
                </Columns>
            </asp:GridView>
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Bill Date"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="billDateLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Total Fee"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="totalFeeLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Paid Amount"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="paidAmountLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Due Amount"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="dueAmountLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Amount"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="amountTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td>                        <asp:Button ID="payButton" CssClass="button" runat="server" Text="Pay" OnClick="payButton_Click" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

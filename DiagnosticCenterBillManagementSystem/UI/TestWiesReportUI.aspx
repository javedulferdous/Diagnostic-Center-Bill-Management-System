<%@ Page Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="TestWiesReportUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestWiesReportUI" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentContentPlaceHolder" runat="server">
    <div class="mainBody">
        <div class="heder_title">
            Test wise Report
        </div>
        <div class=" content_table ">
            <div class="content-info">
                <table >
                    <tr>
                        <td>
                            <asp:Label ID="fromDateLabel" runat="server" Text="From Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="fromDateTextBox" runat="server" TextMode="Date"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="To Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="toDateTextBox" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="showButton" CssClass="button" runat="server" Text="show" OnClick="showButton_Click" />
                        </td>
                        <td>
                            <asp:Button ID="pDFButton" CssClass="button" runat="server" Text="PDF" OnClick="pDFButton_Click" />
                        </td>
                    </tr>
                </table>
                <div style="margin: 15px auto; padding: 0 0 25px 0;">
                    <asp:GridView ID="testWiesReportGridView" CssClass="grid" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" EmptyDataText="No data available." BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDataBound="allTestRequestGridView" ShowFooter="True">
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Test Name" DataField="TestName" />
                            <asp:BoundField HeaderText="Total Test" DataField="TotalCount" />
                            <asp:BoundField HeaderText="Total Amount" DataField="TotalFee" />
                        </Columns>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>

                    <%--  <asp:Label ID="totalLabel" runat="server" Text="Total"></asp:Label>
                <asp:TextBox ID="totalTextBox" runat="server"></asp:TextBox>--%>
                </div>
            </div>
        </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="TypeWiesReportUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TypeWiesReportUI" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentContentPlaceHolder" runat="server">
    <div class="mainBody">
        <div class="heder_title">
            Type wise Report
        </div>
        <div class=" content_table ">
            <div class="content-info">
                <table style="width: 100%; padding: 10px">
                    <tr>
                        <td class="auto-style2" dir="rtl">
                            <asp:Label ID="fromDateLabel" runat="server" Text="From Date"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox ID="fromDateTextBox" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2" dir="rtl">
                            <asp:Label ID="Label1" runat="server" Text="To Date"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox ID="toDateTextBox" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="showButton" CssClass="button" runat="server" Text="show" OnClick="showButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style1" dir="rtl"></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style1">
                            <asp:Label ID="messageLabel" runat="server"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <asp:GridView ID="typeWiesReportGridView"  EmptyDataText="No data available." BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="grid" HorizontalAlign="Center" ShowFooter="True" OnRowDataBound="typeWiesReportGridView_RowDataBound" runat="server" AutoGenerateColumns="False">
             <Columns>
                 <asp:TemplateField HeaderText="serialNo">
                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                            </asp:TemplateField>
                <asp:BoundField HeaderText="Test Type Name" DataField="Name" />
                 <asp:BoundField HeaderText="Total No Of Test" DataField="Count" />
                 <asp:BoundField HeaderText="Total Amount" DataField="Total" />       
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
                <asp:Button ID="pDFButton" CssClass="button" runat="server" Text="PDF" OnClick="pDFButton_Click" />
                <%--<asp:Label ID="totalLabel" runat="server" Text="Total"></asp:Label>
                <asp:TextBox ID="totalTextBox" runat="server"></asp:TextBox>--%>
            </div>
        </div>
    </div>
</asp:Content>

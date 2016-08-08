<%@ Page Language="C#" Title="Test Type" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="TestTypeSetupUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestTypeSetupUI" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentContentPlaceHolder" runat="server">

    <div class="mainBody">
        <div class="heder_title">
            Test type Setup
        </div>
        <div class=" content_table ">
            <div class="content-info">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="typeNameLabel" runat="server" Text="Type Name"></asp:Label></td>
                        <td>
                            <asp:TextBox  ID="typeNameTextBox" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="validator" runat="server" ControlToValidate="typeNameTextBox" ErrorMessage="Test Type Requated!" ForeColor="red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="errorMessageLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td> <asp:Button ID="typeNameButton" CssClass="button" ValidationGroup="validator" runat="server" Text="Save" OnClick="typeNameButton_Click" /></td>
                    </tr>
                </table>
               
            </div>
        </div>
        <div style="margin: 15px auto; padding: 0 0 25px 130px;">
            <asp:GridView ID="typeNameGridView" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" PageSize="5" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="typeNameGridView_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type Name">
                        <ItemTemplate><%#Eval("TestTypeName") %></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

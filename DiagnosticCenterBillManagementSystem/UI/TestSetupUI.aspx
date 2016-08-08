<%@ Page Language="C#" MasterPageFile="~/master.Master" Title="Test Setup" AutoEventWireup="true" CodeBehind="TestSetupUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestSetupUI" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentContentPlaceHolder" runat="server">
    <div class="mainBody">
        <div class="heder_title">
            Test Setup
        </div>
        <div class=" content_table ">
            <div class="content-info">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="testNameLabel" runat="server" Text="Test Name"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="testNameTextBox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="validation" ControlToValidate="testNameTextBox" runat="server" ErrorMessage="Test Name Requared!" ForeColor="red"></asp:RequiredFieldValidator><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="feeLabel" runat="server" Text="Fee"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="feeTextBox" runat="server"></asp:TextBox><asp:Label ID="bDTLabel" runat="server" Text="  BDT" Font-Size="Smaller"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="feeTextBox" runat="server" ValidationGroup="validation" ForeColor="red" ErrorMessage=" Test Fee Required!"></asp:RequiredFieldValidator><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Test Type"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="testTypeDropDownList" runat="server"></asp:DropDownList><br />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="errorMessageLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="testSetupButton" CssClass="button" runat="server" Text="Save" ValidationGroup="validation" OnClick="testSetupButton_Click" /></td>
                    </tr>
                </table>
            </div>
            <div style="margin: 15px auto; padding: 0 0 25px 130px;">
                <asp:GridView ID="testSetupGridView" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" PageSize="10" AllowPaging="true" AutoGenerateColumns="False" OnPageIndexChanging="testSetupGridView_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Test Name">
                            <ItemTemplate><%#Eval("TestName") %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fee">
                            <ItemTemplate><%#Eval("Fee") %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <ItemTemplate><%#Eval("Name") %></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

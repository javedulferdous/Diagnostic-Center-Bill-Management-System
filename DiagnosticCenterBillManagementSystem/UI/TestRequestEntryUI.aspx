<%@ Page Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="TestRequestEntryUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestRequestUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentContentPlaceHolder" runat="server">
    <div class="mainBody">
        <div class="heder_title">
            Test Request Entry
        </div>
        <div class=" content_table ">
            <div class="content-info">
                <table style="width: 100%; padding: 10px">
                    <tr>
                        <td>
                            <asp:Label ID="patientNameLabel" runat="server" Text="Name of the Patient"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="patientNameTextBox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="patientReq" runat="server" ControlToValidate="patientNameTextBox" ForeColor="red" ErrorMessage="Patient name requared."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="dateOfBirthLabel" runat="server" Text="Date of Birth"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="dateOfBirthTextBox" TextMode="Date" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dateOfBirthTextBox" ValidationGroup="patientReq" ForeColor="red" ErrorMessage="Patient Date of birth."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="mobileNoLabel" runat="server" Text="Mobile No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="mobileNoTextBox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="mobileNoTextBox" runat="server" ValidationGroup="patientReq" ForeColor="red" ErrorMessage="Mobile number."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="selectTestLabel" runat="server" Text="Select Test"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="selectTestDropDownList" AutoPostBack="True" runat="server" OnSelectedIndexChanged="selectTestDropDownList_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="fEELabel" runat="server" Text="FEE"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="fEETextBox" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="testIdHiddenField" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="messageLabel" runat="server" ForeColor="#00CC66"></asp:Label></td>
                        <td>
                            <asp:Button ID="aDDButton" CssClass="button" runat="server" Text="ADD" OnClick="aDDButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </div>
            <div class="GridContent" style="margin: 15px auto; padding: 0 0 25px 130px;">
                <asp:GridView ID="allTestRequestGridView" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server"
                    AutoGenerateColumns="False"
                    Width="570px" ShowFooter="True"
                    EmptyDataText="No records has been added." OnRowDataBound="allTestRequestGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                            <HeaderStyle CssClass="GridHeaderCol1"></HeaderStyle>
                        </asp:TemplateField>
                         <asp:BoundField HeaderText="Test" DataField="Test" />
                        <asp:BoundField HeaderText="Fee" DataField="Fee" />
                        <asp:TemplateField>
                            
                            <ItemTemplate>
                                <%--<asp:HiddenField ID="testidHiddenField"  Text='<%# Eval("Id") %>' runat="server" />--%>
                                <asp:Label ID="testTypeIdLabel" runat="server" Visible="False" Text='<%# Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="GridHeaderCol2" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Test">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Test") %>'></asp:Label>
                                 
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="Label404" runat="server" Font-Size="Medium" Font-Bold="True" Text="Total Amount" />
                            </FooterTemplate>
                            <HeaderStyle CssClass="GridHeaderCol2" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fee">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Fee") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%--Font-Size="Medium" Font-Bold="True" Style="text-align: right"--%>
                                <asp:Label ID="totalamountLabel" runat="server" Text='<%# Eval("total") %>' />
                            </FooterTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>
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
                <asp:Button ID="saveButton" runat="server" CssClass="button" ValidationGroup="patientReq" Text="Save" OnClick="saveButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>


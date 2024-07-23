<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Repeater.aspx.cs" Inherits="DataAccessWeb.Repeater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <h1>Using Repeater Control</h1>
    <hr />
    <asp:Repeater ID="rpEmployees" runat="server">
        <HeaderTemplate>
            <table border="1" style="width: 100%">
                <tr>
                    <th>Employee ID</th>
                    <th>Employee Name</th>
                    <th>Employee Address</th>
                    <th>Employee Salary</th>
                    <th>Department ID</th>
                    <th>Options</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("EmpId")%></td>
                <td><%#Eval("EmpName")%></td>
                <td><%#Eval("EmpAddress")%></td>
                <td><%#Eval("EmpSalary")%></td>
                <td><%#Eval("DeptId")%></td>
                <td>
                    <asp:Button runat="server" Text="Edit" OnClick="Edit_Click" CommandArgument='<%#Eval("EmpId") %>' />
                    <asp:Button runat="server" Text="Delete" OnClick="Delete_Click" CommandArgument='<%#Eval("EmpId") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

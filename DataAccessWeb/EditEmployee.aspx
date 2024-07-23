<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="DataAccessWeb.EditEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <h2>Employee Details to Edit</h2>
        <hr />
        <p>
            Employee ID:
            <asp:TextBox runat="server" Enabled="false" ID="txtId" />
        </p>
        <p>
            Employee Name:
            <asp:TextBox runat="server" ID="txtName" />
        </p>
        <p>
            Employee Address:
            <asp:TextBox runat="server" ID="txtAddress" />
        </p>
        <p>
            Employee Salary:
            <asp:TextBox runat="server" ID="txtSalary" />
        </p>
        <p>
            DeptId:
            <asp:TextBox runat="server" ID="txtDept" />
        </p>
        <p>
            <asp:Button Text="Submit Changes" runat="server" />
        </p>
    </div>
</asp:Content>

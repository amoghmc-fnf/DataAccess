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
            <asp:TextBox runat="server" ID="txtSalary" TextMode="Number"/>
        </p>
        <p>
            DeptId:
            <asp:TextBox runat="server" ID="txtDept" TextMode="Number"/>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDept" ErrorMessage="Must be between 1-5 inclusive" ForeColor="IndianRed" MaximumValue="5" MinimumValue="1" Type="Integer"></asp:RangeValidator>
        </p>
        <p>
            <asp:Button Text="Submit Changes" runat="server" OnClick="Unnamed1_Click" />
            <asp:Button Text="Go Back" runat="server" OnClick="Unnamed2_Click" />
        </p>
        <p>
            <asp:Label ID="lblError" runat="server" ForeColor="IndianRed" />
        </p>
    </div>
</asp:Content>

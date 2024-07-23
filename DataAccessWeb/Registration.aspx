<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="DataAccessWeb.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <h2>User Registration Form</h2>
        <hr />
        <div>
            <p>
                Enter the user name: 
                <asp:TextBox runat="server" ID="txtName"/>
            </p>

            <p>
                Enter the password: 
            <asp:TextBox runat="server" ID="txtPwd" />
            </p>
            <p>
                <asp:Button Text="Register" runat="server" OnClick="Unnamed1_Click" />
            </p>
            <p>
                <asp:Label ID="lblError" runat="server" BorderColor="#CC0000" BorderStyle="Groove" Font-Size="15pt" ForeColor="IndianRed" Height="73px" Width="499px"></asp:Label>
            </p>
        </div>
    </div>
</asp:Content>

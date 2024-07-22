<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="StateManagement.aspx.cs" Inherits="DataAccessWeb.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div class="col-md-8">
        <h2>Verify the Details</h2>
        <p>
            <asp:Label runat="server" ID="lblDetails" />
        </p>
        <asp:Button CssClass="btn btn-info" Text="Register" runat="server" ID="btnRegister" />
    </div>
</asp:Content>

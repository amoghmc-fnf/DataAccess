<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="DataAccessWeb.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <p>List of Items</p>
            <asp:ListBox runat="server" ID="lstProducts" Height="315px" Width="217px">
            </asp:ListBox>
        </div>
    </div>
</asp:Content>

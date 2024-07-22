<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SessionState.aspx.cs" Inherits="DataAccessWeb.SessionState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h2 class="h2">Storing my Session Data
            </h2>
            <hr />
            <p>
                Enter the Item Name: 
            <asp:TextBox runat="server" ID="txtItem" />
                <asp:button text="AddItem" ID="btnAdd" runat="server" OnClick="btnAdd_Click"/>
                <asp:Label ID="lblError" runat="server" ForeColor="IndianRed"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
            <asp:listbox runat="server" ID="lstItems"></asp:listbox>
        </div>
    </div>
</asp:Content>

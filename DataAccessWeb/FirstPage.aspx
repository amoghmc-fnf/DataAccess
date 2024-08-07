﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="DataAccessWeb.FirstPage" %>

<asp:Content ID="contentFirstPage" ContentPlaceHolderID="mainContent" runat="server">

        <div>
            <div style="width: 182px; height: 25px">
                <span>Enter the item to add to cart</span>
            </div>
            <div>
                <span>
                <asp:TextBox runat="server" ID="txtItem" Height="23px" Width="168px"/>
                <asp:Button Text="Add Item" runat="server" ID="btnAdd" OnClick="btnAdd_Click" Width="163px"/>
                    </span>
            </div>
        </div>
        <p style="width: 397px">
            <span>
                Items that are in the cart:
            </span>
            <br />
            <asp:ListBox ID="lstItems" runat="server" Height="136px" Width="393px" OnSelectedIndexChanged="lstItems_SelectedIndexChanged" AutoPostBack="True">
            </asp:ListBox>
            <asp:Label Text="" ID="lblSelected" runat="server" />
        </p>
</asp:Content>
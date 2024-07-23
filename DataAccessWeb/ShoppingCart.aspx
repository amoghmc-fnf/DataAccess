<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="DataAccessWeb.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <p>List of Items</p>
            <asp:ListBox runat="server" AutoPostBack="true" ID="lstProducts" Height="315px" Width="217px" OnSelectedIndexChanged="lstProducts_SelectedIndexChanged"></asp:ListBox>
            <asp:Label Text="" ForeColor="IndianRed" ID="lblError" runat="server" />
        </div>

        <div class="col-md-8">
            <h2>Product Details</h2>
            <div class="row">
                <div class="col-md-6">
                    <p>
                        ID:
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtId" TextMode="Number" />
                    </p>
                    <p>
                        Name:
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtName" />
                    </p>
                    <p>
                        Price:
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtPrice" TextMode="Number" />
                    </p>
                </div>
                <div class="col-md-5">
                    <asp:Image ImageUrl="" runat="server" ID="imgProduct" />
                </div>
            </div>
            <div>
                <asp:DataList ID="dtRecentList" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" >
                    <HeaderTemplate>
                        <p>
                            <h2>Your recently viewed list</h2>
                        </p>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="plate">
                            <img src="<%#Eval("Image")%>" width="100px" height="200px" />
                            <br />
                            <hr />
                            <p>
                                <%#Eval("Name")%>
                            </p>
                            <p>
                                <%#Eval("Price")%>
                            </p>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>

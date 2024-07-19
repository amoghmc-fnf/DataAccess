<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ConnectedAccess.aspx.cs" Inherits="DataAccessWeb.ConnectedAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <h1>ADO.NET Connected Data Example</h1>
        <h3>List of Students:</h3>
        <table style="vertical-align: top">
            <tr style="vertical-align: top">
                <td>
                    <asp:ListBox ID="lstStudents" runat="server" Height="340px" Width="247px" OnSelectedIndexChanged="lstStudents_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td style="width: 235px">
                    <div>
                        <P>
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Fetch Details" Width="229px" />
                        </P>
                        <hr />
                        <p>
                            Student ID: <asp:TextBox runat="server" ID="txtId" CssClass="form-control" TextMode="Number"/>
                        </p>
                        <p>
                            Student Name: <asp:TextBox ID="txtName"  CssClass="form-control" runat="server"/>
                        </p>                        
                        <p>
                            Student Email: <asp:TextBox ID="txtEmail"  runat="server" CssClass="form-control" TextMode="Email"/>
                        </p>                        
                        <p>
                            Student Contact: <asp:TextBox ID="txtPhone"  runat="server" CssClass="form-control" TextMode="Phone"/>
                        </p>
                         <asp:Button Text="Add" ID="btnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click" Width="71px" />
                            <asp:Button Text="Delete" ID="btnDelete" runat="server" CssClass="btn btn-danger" OnClick="btnDelete_Click" Width="76px" />
                            <asp:Button Text="Update" ID="btnUpdate" runat="server" CssClass="btn btn-warning" OnClick="btnUpdate_Click" Width="84px" />
                    </div>
                </td>
            </tr>
        </table>
        <asp:Label ForeColor="IndianRed" Font-Size="14pt" runat="server" ID="lblError" />
    </div>
</asp:Content>

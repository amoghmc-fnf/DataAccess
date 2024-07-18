<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ConnectedAccess.aspx.cs" Inherits="DataAccessWeb.ConnectedAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <h1>ADO.NET Connected Data Example</h1>
        <h3>List of Students:</h3>
        <table style="vertical-align: top">
            <tr>
                <td>
                    <asp:ListBox ID="lstStudents" runat="server" AutoPostBack="True" Height="228px" Width="164px"></asp:ListBox>
                </td>
                <td>
                    <div>
                        <h2>Details of the Student</h2>

                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalcPage.aspx.cs" Inherits="DataAccessWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to calculator</h1>
            <div>
                <span>
                    <asp:TextBox runat="server" ID="txtItem1" Height="23px" Width="168px" />
                    <asp:TextBox runat="server" ID="txtItem2" Height="23px" Width="168px" />
                    <asp:Button Text="Calculate" runat="server" ID="btnCalculate" Width="163px" OnClick="btnCalculate_Click" />
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="X-Large" />
                </span>
            </div>
        </div>
        <p style="width: 731px; height: 214px;">
            <span>Select your desired operation
            </span>
            <br />
            <asp:ListBox ID="lstItems" runat="server" Height="136px" Width="724px">
                <asp:ListItem ID="lstItemAdd" Text="Add" />
                <asp:ListItem ID="lstItemSub" Text="Subtract" />
                <asp:ListItem ID="lstItemMul" Text="Multiply" />
                <asp:ListItem ID="lstItemDiv" Text="Divide" />
            </asp:ListBox>
            <br />
            <asp:Label ID="lblSelected" runat="server" Font-Bold="True" Font-Size="X-Large" />
        </p>
    </form>
</body>
</html>

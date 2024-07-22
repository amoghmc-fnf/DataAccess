<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Validation.aspx.cs" Inherits="DataAccessWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <script>
        function ValidateMe(sender, args) {
            if (args.Value === "Trainer" || args.Value === "Trainee") {
                args.IsValid = true;
            } else {
                alert("Not valid")
                args.IsValid = false;
            }
        }
    </script>
    <div class="col-md-6">
        <div>
            <p>
                Enter the Name:
                <asp:TextBox runat="server" ID="txtName" />
                <asp:RequiredFieldValidator ErrorMessage="Name is mandatory" ControlToValidate="txtName" runat="server" ForeColor="IndianRed" />
            </p>
            <p>
                Enter the Email Address:
                <asp:TextBox runat="server" ID="txtEmail" />
                <asp:RequiredFieldValidator ErrorMessage="Email is mandatory" ControlToValidate="txtEmail" runat="server" ForeColor="IndianRed" />
                <asp:RegularExpressionValidator ErrorMessage="Email is not in the proper format" ControlToValidate="txtEmail" runat="server" ForeColor="IndianRed" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"/>
            <p>
                Enter the Age:
                <asp:TextBox runat="server" ID="txtAge" TextMode="Number" />
                <asp:RangeValidator ErrorMessage="Age should be b/w 22 to 45" ControlToValidate="txtAge" runat="server" ForeColor="IndianRed" MinimumValue="22 " MaximumValue="45" Type="Integer" />
            </p>
            <p>
                Enter the Password:
                <asp:TextBox runat="server" TextMode="Password" ID="txtPwd" />
                <asp:RequiredFieldValidator ErrorMessage="Password is mandatory" ForeColor="IndianRed" ControlToValidate="txtPwd" runat="server" />
            </p>
            <p>
                ReType the Password:
                <asp:TextBox runat="server" TextMode="Password" ID="txtRetype" />
                <asp:CompareValidator ErrorMessage="Password Mismatch" ControlToValidate="txtRetype" ForeColor="IndianRed" ControlToCompare="txtPwd" Type="String" runat="server" />
            </p>
            <p>
                Enter UR Job:
                <asp:TextBox runat="server" ID="txtJob" OnTextChanged="txtJob_TextChanged" />
                <asp:CustomValidator ErrorMessage="Job should be either a Trainer or Trainee" ControlToValidate="txtJob" runat="server" ForeColor="IndianRed" ClientValidationFunction="ValidateMe" OnServerValidate="Unnamed7_ServerValidate" />
            </p>
        </div>
        <div>
            <asp:Button Text="Submit" runat="server" OnClick="Unnamed8_Click" />
        </div>
    </div>
    </a>
</asp:Content>

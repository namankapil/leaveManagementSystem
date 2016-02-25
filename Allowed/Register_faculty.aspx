<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register_faculty.aspx.cs" Inherits="Faculty_register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Faculty Registration</title>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href='https://fonts.googleapis.com/css?family=Montserrat' rel='stylesheet' type='text/css'>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Faculty Registration</h1>
            <asp:TextBox ID="TextBox_name" runat="server" CssClass="form-control" placeholder="Full Name" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_name" runat="server" ControlToValidate="TextBox_name" ErrorMessage="*Enter Name" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="TextBox_emp_id" runat="server" CssClass="form-control" placeholder="Employee ID" MaxLength="8"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_emp_id" runat="server" ControlToValidate="TextBox_emp_id" ErrorMessage="*Enter Employee ID" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_emp_id" runat="server" ControlToValidate="TextBox_emp_id" ErrorMessage="*8 digits Required" Font-Bold="True" ForeColor="Red" ValidationExpression="[0-9]{8}"></asp:RegularExpressionValidator>
            <br />
            <asp:TextBox ID="TextBox_password" runat="server" CssClass="form-control" placeholder="Password" MaxLength="50" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_password" runat="server" ControlToValidate="TextBox_password" ErrorMessage="*Enter Password" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="TextBox_email" runat="server" CssClass="form-control" placeholder="Email" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_email" runat="server" ControlToValidate="TextBox_email" ErrorMessage="*Enter Email" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_email" runat="server" ControlToValidate="TextBox_email" ErrorMessage="*Invalid Email" Font-Bold="True" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <asp:TextBox ID="TextBox_mobile" runat="server" CssClass="form-control" placeholder="Mobile" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_mobile" runat="server" ControlToValidate="TextBox_mobile" ErrorMessage="*Enter Mobile" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_mobile" runat="server" ControlToValidate="TextBox_mobile" ErrorMessage="*Invalid Mobile" Font-Bold="True" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
            <br />
            <asp:DropDownList ID="DropDownList_post" runat="server">
                <asp:ListItem Value="">Select Designation</asp:ListItem>
                <asp:ListItem Value="mentor">Mentor</asp:ListItem>
                <asp:ListItem Value="hod">HOD</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_designation" runat="server" ControlToValidate="DropDownList_post" ErrorMessage="*Select Designation" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList_branch" runat="server">
                <asp:ListItem Value="">Select Branch</asp:ListItem>
                <asp:ListItem Value="IT">IT</asp:ListItem>
                <asp:ListItem Value="CS">CS</asp:ListItem>
                <asp:ListItem Value="MECH">MECH</asp:ListItem>
                <asp:ListItem Value="CIVIL">CIVIL</asp:ListItem>
                <asp:ListItem Value="EXTC">EXTC</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_branch" runat="server" ControlToValidate="DropDownList_branch" ErrorMessage="*Select Branch" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Register" CssClass="form-control" OnClick="Button1_Click" BackColor="#3498DB" Font-Bold="True" ForeColor="White" />

        </div>
    </form>
</body>
</html>

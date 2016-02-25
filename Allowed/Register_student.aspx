<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register_student.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Registration</title>
    <link href='https://fonts.googleapis.com/css?family=Montserrat' rel='stylesheet' type='text/css'>
    <link href="StyleSheet.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <script src="bootstrap/js/bootstrap.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        
            <h1>Student Registration</h1>
            <p>&nbsp;</p>
            <asp:TextBox ID="TextBox_name" runat="server" placeholder="Full Name" CssClass="form-control" MaxLength="30" CausesValidation="True" ValidationGroup="validate_required"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_name" runat="server" ControlToValidate="TextBox_name" ErrorMessage="*Invalid Name" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="TextBox_sap" runat="server" placeholder="SAP ID" OnChange="txtZipOnChange('custValidator')" CssClass="form-control" MaxLength="11" CausesValidation="True" ValidationGroup="validate_required"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_SAP" runat="server" ControlToValidate="TextBox_sap" ErrorMessage="*Invalid SAP ID" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{11}"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_SAP" runat="server" ControlToValidate="TextBox_sap" ErrorMessage="*Enter SAP ID" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="DropDownList_gender" runat="server" CausesValidation="True">
                <asp:ListItem Selected="True" Text="Gender" Value="">Gender</asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_gender" runat="server" ControlToValidate="DropDownList_gender" ErrorMessage="*Invalid Gender" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList_year" runat="server" CausesValidation="True" CssClass="dropdown-toggle" role="menu">
                <asp:ListItem Selected="True" Text="Year" Value="">Year</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_year" runat="server" ControlToValidate="DropDownList_year" ErrorMessage="*Invalid Year" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <br />

            <asp:DropDownList ID="DropDownList_branch" runat="server" CausesValidation="True">
                <asp:ListItem Text="Select Branch" Value="">Select Branch</asp:ListItem>
                <asp:ListItem>IT</asp:ListItem>
                <asp:ListItem>CS</asp:ListItem>
                <asp:ListItem>EXTC</asp:ListItem>
                <asp:ListItem>MECH</asp:ListItem>
                <asp:ListItem>CIVIL</asp:ListItem>
                <asp:ListItem>TEXTTILE</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_branch" runat="server" ControlToValidate="DropDownList_branch" ErrorMessage="*Invalid Branch" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList_course" runat="server" BackColor="White" CausesValidation="True">
                <asp:ListItem Selected="True" Text="Select course" Value="">Select Course</asp:ListItem>
                <asp:ListItem>B.Tech</asp:ListItem>
                <asp:ListItem>MBA.Tech</asp:ListItem>
                <asp:ListItem>M.Tech</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_course" runat="server" ControlToValidate="DropDownList_course" ErrorMessage="*Invalid Course" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            Select Mentor
                <asp:DropDownList ID="DropDownList_mentor" runat="server" CausesValidation="True" DataSourceID="employee_datasource" DataTextField="name" DataValueField="name">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>

            <asp:SqlDataSource ID="employee_datasource" runat="server" ConnectionString="<%$ ConnectionStrings:LeaveConnectionString %>" SelectCommand="SELECT [name] FROM [employee] WHERE [post]='mentor' order by [name]"></asp:SqlDataSource>

            <br />
            &nbsp;<asp:TextBox ID="TextBox_email" runat="server" placeholder="Email ID" CssClass="form-control" MaxLength="40" CausesValidation="True"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Font-Bold="True">* Invalid Email</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_email" runat="server" ControlToValidate="TextBox_email" ErrorMessage="*Enter Email" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="TextBox_address" runat="server" placeholder="Address" CssClass="form-control" MaxLength="80" CausesValidation="True" Rows="3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_address" runat="server" ControlToValidate="TextBox_address" ErrorMessage="*Invalid Address" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="TextBox_mobile_self" runat="server" placeholder="Mobile (Self)" CssClass="form-control" MaxLength="10" CausesValidation="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_mobile" runat="server" ControlToValidate="TextBox_mobile_self" ErrorMessage="*Invalid Mobile Number" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_mobile_self" runat="server" ControlToValidate="TextBox_mobile_self" ErrorMessage="*Invalid Mobile Number" Font-Bold="True" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
            <br />
            <asp:TextBox ID="TextBox_mobile_parent" runat="server" placeholder="Mobile (Parent)" CssClass="form-control" MaxLength="10" CausesValidation="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_mobile_parent" runat="server" ControlToValidate="TextBox_mobile_parent" ErrorMessage="*Invalid Mobile" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_mobile_parent" runat="server" ControlToValidate="TextBox_mobile_parent" ErrorMessage="*Invalid Mobile" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
            <br />
            
            <asp:Button ID="Button_submit" runat="server" Text="Register" CssClass="form-control" OnClick="Button_submit_Click" BackColor="#3498DB" Font-Bold="True" ForeColor="White" />
        
            <br />
        
    </form>
</body>
</html>

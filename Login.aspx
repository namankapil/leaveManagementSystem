<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="LoginDefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href='https://fonts.googleapis.com/css?family=Montserrat' rel='stylesheet' type='text/css'/>
    <link href="~/Allowed/StyleSheet.css" rel="stylesheet" />
    <link rel="shortcut icon" href="../favicon.ico"/> 
        <link rel="stylesheet" type="text/css" href="Allowed/Login/css/style.css" />
        <script src="Allowed/Login/js/modernizr.custom.63321.js"></script>
        <!--[if lte IE 7]><style>.main{display:none;} .support-note .note-ie{display:block;}</style><![endif]-->
		<style>
			body {
				background: #e1c192 url(Allowed/Login/images/wood_pattern.jpg);
			}
		</style>
</head>
<body>

    <div class="container">
        <section class="main">
        <form id="form1" runat="server" class="form-2">
        <span class="log-in">Log in<br /></span>
            
            <hr /><br />
            <label for="login"><i class="icon-user"></i>User ID</label>
        <asp:textbox id="TextBox_ID" runat="server" cssclass="form-control" placeholder="Enter Your Id"></asp:textbox>
        <asp:requiredfieldvalidator id="requiredfieldvalidator_id" runat="server" controltovalidate="textbox_id" errormessage="*enter user id" forecolor="red"></asp:requiredfieldvalidator>
        
            <label for="password"><i class="icon-lock"></i>Password</label>
        <asp:textbox id="TextBox_password" runat="server" cssclass="form-control" placeholder="Enter Password" textmode="password"></asp:textbox>
        <asp:requiredfieldvalidator id="requiredfieldvalidator_password" runat="server" controltovalidate="textbox_password" errormessage="*enter password" forecolor="red"></asp:requiredfieldvalidator>
        
        
            
        <asp:radiobuttonlist id="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="1">
            <asp:listitem>Student</asp:listitem>
            <asp:listitem>Employee</asp:listitem>
        </asp:radiobuttonlist>
        <asp:requiredfieldvalidator id="requiredfieldvalidator_radiobutton" runat="server" controltovalidate="radiobuttonlist1" errormessage="*choose one" forecolor="red"></asp:requiredfieldvalidator>
                <br />
        <asp:button id="button1" runat="server" text="Login" cssclass="log-twitter" font-bold="true" forecolor="white" onclick="Button1_Click" style="float:none;" />
       
    </form>
     </section>
    
    </div>


</body>
</html>

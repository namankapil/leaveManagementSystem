<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Leave_same_day.aspx.cs" Inherits="Leave_same_day" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <%--Bootstrap--%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css"/>
    
   <%-- <link href="Allowed/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Allowed/bootstrap/css/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="Allowed/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="Allowed/moment.js"></script>
    <script src="Allowed/id.js"></script>
    <script src="Allowed/bootstrap-datetimepicker.min.js"></script>
    <script src="Allowed/bootstrap-datetimepicker.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Button ID="Button_logout" runat="server" BackColor="White" style="float:right;" BorderStyle="None" Font-Bold="True" Text="Logout" Font-Underline="True" ForeColor="Blue" OnClick="Button_logout_Click" CausesValidation="False" />
        <asp:Label  ID="Label_welcome" runat="server" Font-Bold="True" style="float:right;"></asp:Label>
       
    <div class="col-md-4" style="position:fixed;top: 50%;left: 50%; width:449px;height:358px;
                                 margin-top: -200px; /*set to a negative number 1/2 of your height*/
                                 margin-left: -224px; /*set to a negative number 1/2 of your width*/
                                 background-color:#f5f3f3;
                                 box-shadow: 0px 0px 5px #888888;
                                 "> 
            
            <h2>Same Day Return(Shirpur) Leave</h2>
            <br />
        <div class="container">
            <div class="row">
                <div class='col-sm-6' style="padding-left:0px;">
                            <asp:TextBox ID="TextBox_timeAndDay" runat="server" CssClass="form-control" placeholder="Select Depart Time" Width="425px"></asp:TextBox>
                            
                </div>
                <script type="text/javascript">
                    $(function () {
                        $('#TextBox_timeAndDay').datetimepicker(
                            {
                                locale: 'en',
                                format: 'D-M-YYYY hh:mm A'
                            });
                    });
                </script>
            </div>
        </div>
            <p>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_dayTime" runat="server" ControlToValidate="TextBox_timeAndDay" ErrorMessage="*Select Date and Time" ForeColor="Red"></asp:RequiredFieldValidator>
            </p>
            <p>NOTE: If Depart Time is less than academic hours(i.e. 05:00 PM) then leave is forwarded to HOD</p>
            
       <asp:TextBox ID="TextBox_reason_sameDay" runat="server" placeholder="Reason For Leave" CssClass="form-control" MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_reason_sameDay" ErrorMessage="*Select reason" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        <asp:Button ID="Button2_submit" runat="server" Text="Apply Leave" CssClass="btn btn-success" OnClick="Button2_submit_Click" />
            &nbsp;<asp:Label ID="Label_sameDay_result" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="Button_cancelLeave" runat="server" Text="Cancel Leave" BackColor="#F5F3F3" BorderStyle="None" Font-Bold="True" style="cursor:pointer;float:right;" Font-Underline="True" ForeColor="Blue" CausesValidation="False" OnClick="Button_cancelLeave_Click" />
               
            <asp:Button ID="Button_viewStatus" runat="server" Text="View Leave status" BackColor="#F5F3F3" BorderStyle="None" Font-Bold="True" style="cursor:pointer; float:right;" Font-Underline="True" OnClick="Button_viewStatus_Click" CausesValidation="False" ForeColor="Blue"/>
            </div>
            </form>
</body>
</html>
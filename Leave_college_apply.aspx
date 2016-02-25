<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Leave_college_apply.aspx.cs" Inherits="Leave_college_apply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link href="Allowed/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="Allowed/StyleSheet.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css"/>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.11.0.js"></script>
  <script type="text/javascript" src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>

 <script type="text/javascript" src="Allowed/TimePicker/jquery-ui-timepicker-addon.js"></script>
     
    <script>
        $(function () {
            $("#TextBox_date_from").datepicker({
                minDate: "dateToday",
                changeMonth: true,
                dateFormat: 'dd-mm-yy',
                onClose: function (selectedDate, instance) {
                    if (selectedDate != '') {
                        $("#to").datepicker("option", "minDate", selectedDate);
                        var date = $.datepicker.parseDate(instance.settings.dateFormat, selectedDate, instance.settings);
                        date.setMonth(date.getMonth() + 3);
                        console.log(selectedDate, date);
                        $("#TextBox_date_to").datepicker("option", "minDate", selectedDate);
                        $("#TextBox_date_to").datepicker("option", "maxDate", date);
                    }
                }
            });
            $("#TextBox_date_to").datepicker({
                minDate: "dateToday",
                changeMonth: true,
                dateFormat: 'dd-mm-yy',
                onClose: function (selectedDate) {
                    $("#TextBox_date_from").datepicker("option", "maxDate", selectedDate);
                }
            });

            $('#TextBox_date_sameDay').datepicker({});
        });


  </script>
</head>
<body>
    <form id="form1" runat="server">
    <br />
        <asp:Button ID="Button_logout" runat="server" BackColor="White" style="float:right;" BorderStyle="None" Font-Bold="True" Text="Logout" Font-Underline="True" ForeColor="Blue" OnClick="Button_logout_Click" CausesValidation="False" />
        <asp:Label  ID="Label_welcome" runat="server" Font-Bold="True" style="float:right;"></asp:Label>
            <div class="col-md-4" style="position:fixed;top: 50%;left: 50%; width:449px;height:408px;
                                 margin-top: -200px; /*set to a negative number 1/2 of your height*/
                                 margin-left: -224px; /*set to a negative number 1/2 of your width*/
                                 background-color:#f5f3f3;
                                 box-shadow: 0px 0px 5px #888888;
                                 "> 
           
            <h2>Apply for Leave</h2>
            <br />
        Leave From:<asp:TextBox ID="TextBox_date_from" runat="server" CssClass="form-control" style="z-index:1000;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_datefrom" runat="server" ControlToValidate="TextBox_date_from" ErrorMessage="*Select From Date" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        Leave To:<asp:TextBox ID="TextBox_date_to" runat="server" CssClass="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_dateTo" runat="server" ControlToValidate="TextBox_date_to" ErrorMessage="*Select Date" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
                 <asp:TextBox ID="TextBox_reason" runat="server" placeholder="Reason For Leave" CssClass="form-control" MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_reason" runat="server" ControlToValidate="TextBox_reason" ErrorMessage="*Select reason" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        <asp:Button ID="Button1" runat="server" Text="Apply Leave" CssClass="btn btn-success" OnClick="Button1_Click"/>
            <asp:Label ID="Label_result" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>

                <br />

                <asp:Button ID="Button_check_status" runat="server" style="float:right;" Text="Check Status" Font-Bold="True" Font-Underline="True" BackColor="#F5F3F3" BorderStyle="None" CausesValidation="False" ForeColor="Blue" OnClick="Button_check_status_Click" />    
               <asp:Button ID="Button_cancel_leave" runat="server" style="float:right;" Text="Cancel Leave" Font-Bold="True" Font-Underline="True" BackColor="#F5F3F3" BorderStyle="None" CausesValidation="False" ForeColor="Blue" OnClick="Button_cancel_leave_Click" />
            </div>
               
    </form>
</body>
</html>

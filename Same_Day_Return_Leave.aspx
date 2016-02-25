<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Same_Day_Return_Leave.aspx.cs" Inherits="Same_Day_Return_Leave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Leave System</title>
    <link href="Allowed/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <%--<link href="Allowed/StyleSheet.css" rel="stylesheet" />--%>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css"/>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.11.0.js"></script>
  <script type="text/javascript" src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
 <%-- <script type="text/javascript" src="Allowed/TimePicker/jquery-ui-timepicker-addon.js"></script>--%>
    <link href="Allowed/TimePicker/jquery.timepicker.css" rel="stylesheet" />
    <script src="Allowed/TimePicker/jquery.timepicker.min.js"></script> 

  <link rel="stylesheet" href="/resources/demos/style.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Same Day Return</h1>
        <asp:TextBox ID="TextBox_time_departure" runat="server" CssClass="form-control" placeholder="Departure Time"></asp:TextBox>
        <script type="text/javascript">
            $(function () {
                $("#TextBox_time_departure").timepicker({ 'timeFormat': 'h:i A' });
                $("#TextBox_time_arrival").timepicker();
            }
            );
            </script>
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
            });
            </script>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_departureTime" runat="server" ControlToValidate="TextBox_time_departure" ErrorMessage="*mandatory" ForeColor="Red"></asp:RequiredFieldValidator>
            
        <asp:TextBox ID="TextBox_date_from" runat="server" CssClass="form-control" style="z-index:1000;" placeholder="Select Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_datefrom" runat="server" ControlToValidate="TextBox_date_from" ErrorMessage="*Select From Date" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        <asp:TextBox ID="TextBox_placeToVisit" runat="server" placeholder="Place To Visit" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_placeToVisit" runat="server" ControlToValidate="TextBox_placeToVisit" ErrorMessage="*mandatory" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        <asp:TextBox ID="TextBox_time_arrival" runat="server" CssClass="form-control" placeholder="Arrival Time"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator_arrival_time" runat="server" ControlToValidate="TextBox_time_arrival" ErrorMessage="*mandatory" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="TextBox_reason" runat="server" CssClass="form-control" placeholder="Reason"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator_reason" runat="server" ControlToValidate="TextBox_reason" ErrorMessage="*mandatory" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="Button_applyLeave" runat="server" Text="Button" OnClick="Button_applyLeave_Click" CssClass="btn btn-success"  />
    </div>

    </form>
</body>
</html>

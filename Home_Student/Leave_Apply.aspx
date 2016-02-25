<%@ Page Language="C#" AutoEventWireup="true" EnableSessionState="ReadOnly" CodeFile="Leave_Apply.aspx.cs" Inherits="Leave_Apply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
    <link href="Allowed/StyleSheet.css" rel="stylesheet" />


    		<meta charset="UTF-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/> 
		<meta name="viewport" content="width=device-width, initial-scale=1.0"/> 
		<meta name="description" content="" />
		<meta name="keywords" content="" />
		<meta name="author" content="Codrops" />
		<link rel="shortcut icon" href="../favicon.ico"/> 
		<link rel="stylesheet" type="text/css" href="css/default.css" />
		<link rel="stylesheet" type="text/css" href="css/component.css" />
		<script src="js/modernizr.custom.js"></script>


    <link rel="stylesheet" href="http://localhost:7520/code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css"/>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.11.0.js"></script>
  <script type="text/javascript" src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>

 <script type="text/javascript" src="Allowed/TimePicker/jquery-ui-timepicker-addon.js"></script>
     <link rel="stylesheet" href="/resources/demos/style.css"/>
    <%--<script src="Allowed/TimePicker/jquery.timepicker.min.js"></script>
    <link href="Allowed/TimePicker/jquery.timepicker.css" rel="stylesheet" />--%>
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
        <asp:Button ID="Button_logout" runat="server" style="float:right; cursor:pointer;" BorderStyle="None" Font-Bold="True" Text="Logout" Font-Underline="True" ForeColor="#2C3F52" OnClick="Button_logout_Click" CausesValidation="False" BackColor="#F9F9F9" />
        <asp:Label  ID="Label_welcome" runat="server" Font-Bold="True" style="float:right;"></asp:Label>
       
                
        <div class="container demo-2">
			
			<header>
				<h1>Select Type Of Leave</h1>	
			</header>
			<ul class="grid cs-style-2">
				<li>
					<figure>
						<img src="images/2.png" alt="img02">
						<figcaption>
							<center><asp:Button ID="Button2" runat="server" Text="APPLY LEAVE" OnClick="Button_sameday_Click" BackColor="#2C3F52" Font-Bold="True" ForeColor="#ED4E6E" style="cursor:pointer;" BorderStyle="None" EnableTheming="True" Font-Size="X-Large" /></center>
						</figcaption>
					</figure>
				</li>
				<li>
					<figure>
						<img src="images/5.png" alt="img04">
						<figcaption>
							<center><asp:Button ID="Button1" runat="server" Text="APPLY LEAVE" OnClick="Button_redirect_leave_Click" BackColor="#2C3F52" Font-Bold="True" ForeColor="#ED4E6E" style="cursor:pointer;" BorderStyle="None" EnableTheming="True" Font-Size="X-Large"/></center>
						</figcaption>
					</figure>
				</li>
			<script src="js/toucheffects.js"></script>

    </form>
</body>
</html>

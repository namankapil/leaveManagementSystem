<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Gate_Check.aspx.cs" Inherits="Gate_Check" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Student Departure</title>
    <link href='https://fonts.googleapis.com/css?family=Montserrat' rel='stylesheet' type='text/css'/>
    <style>
        * {
            font-family: 'Montserrat', sans-serif;
          }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button_logout" runat="server" BackColor="White" style="float:right;" BorderStyle="None" Font-Bold="True" Text="Logout" Font-Underline="True" ForeColor="Blue" OnClick="Button_logout_Click" CausesValidation="False" />
        <asp:GridView ID="GridView_gateCheck" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="7" ForeColor="Black" GridLines="Horizontal">
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button id="button_departed"  runat="server" BorderStyle="None" Text="Departed" OnClick="button_departed_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>

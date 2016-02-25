<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeFile="Employee_Check_Leave.aspx.cs" Inherits="Employee_Check_Leave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
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
        <asp:Label ID="Label_welcome" runat="server" Text="" style="float:right;"></asp:Label>
    <div>
    <h2>Leave</h2>
    
        <asp:GridView ID="GridView_leaves" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" CellPadding="7" ForeColor="Black" >
            <Columns>
                <asp:TemplateField  >
          <ItemTemplate>
            <asp:Button ID="Button_approve" runat="server" 
                 Text="Approve" BorderStyle="None" CommandArgument="Button1"
                 OnClick="Btn1_Click" style="padding:5px;margin:1px"/><br />
                <asp:Button ID="Button_disapprove" runat="server" 
                 Text="Reject" BorderStyle="None" CommandArgument="Button1"
                 OnClick="Btn_disapprove_Click" style="padding:5px;margin:1px"/><br />
                
          </ItemTemplate>
                    
       </asp:TemplateField>
               <asp:TemplateField>
                   <ItemTemplate>
                       <asp:Button ID="Button_forwardToDean" runat="server" 
                 Text="Forward To Dean" BorderStyle="None" CommandArgument="Button1"
                 OnClick="Btn_forwardToDean_Click" style="padding:5px;"/>
                   </ItemTemplate>
               </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    
        <asp:Label ID="Label_leave_available" runat="server" Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Leave;
using System.Web.Security;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Leave_Apply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["sap_id"] != null)
            Label_welcome.Text = "Welcome, " + Session["student_name"];
        else
            Response.Redirect("~/Login.aspx");
    }
    
    protected void Button_logout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("~/Login.aspx");
    }

    protected void Button_redirect_leave_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Leave_college_apply.aspx");
        

    }
    protected void Button_sameday_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Leave_same_day.aspx");
    }
}
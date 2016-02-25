using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Leave;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

public partial class Leave_college_apply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["sap_id"] != null)
            Label_welcome.Text = "Welcome, " + Session["student_name"];
        else
            Response.Redirect("Login.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int days_holiday = 0; //number of days having holiday
        List<DateTime> date_range = GetDateRange(Convert.ToDateTime(TextBox_date_from.Text), Convert.ToDateTime(TextBox_date_to.Text).Date);
        int days_leave = date_range.Count; // total number of days leave applied for
        foreach (DateTime item in date_range)
        {
            if (item.DayOfWeek == DayOfWeek.Sunday)
            {
                days_holiday++;
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select date from academic_leave where date='" + item.ToString("yyyy-MM-dd") + "'", con);
                object c = cmd.ExecuteScalar();
                if (c != null)
                {
                    days_holiday++;
                }
                con.Close();
            }
        }
        Label_result.Visible = true;
        String mentor_email = "";

        if ((days_leave - days_holiday) != 0)
        {
            Label_result.Text = Data_Access.Apply_Leave(Session["sap_id"].ToString(), TextBox_date_from.Text, TextBox_date_to.Text, TextBox_reason.Text, out mentor_email, days_leave- days_holiday);

        }
        else
        {
            Label_result.Text = Data_Access.Apply_Leave(Session["sap_id"].ToString(), TextBox_date_from.Text, TextBox_date_to.Text, TextBox_reason.Text, out mentor_email, days_holiday);
        }

        Data_Access.MailSend(mentor_email, "Mentor Leave Notification", "New leave has been posted");
    }

    protected void Button_logout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");
    }

    private List<DateTime> GetDateRange(DateTime startingDate, DateTime endingDate)
    {
        if (startingDate > endingDate)
        {
            return null;
        }
        List<DateTime> range = new List<DateTime>();
        DateTime tmpDate = startingDate;
        while (tmpDate <= endingDate)
        {
            range.Add(tmpDate);
            tmpDate = tmpDate.AddDays(1);
        }
        return range;
    }
    protected void Button_check_status_Click(object sender, EventArgs e)
    {
        Label_result.Visible = true;
        Label_result.Text = Data_Access.Check_Status(Session["sap_id"].ToString());
    }
    protected void Button_cancel_leave_Click(object sender, EventArgs e)
    {
        int i;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        if(con.State!=ConnectionState.Open)
            con.Open();
        SqlCommand cmd = new SqlCommand("select sap_id from leave where sap_id='"+Session["sap_id"].ToString()+"' and departed='False'",con);
        object sapid=cmd.ExecuteScalar();
        cmd.Dispose();
        if (sapid == null)
        {
            Label_result.Text = "You have not applied for leave";
            Label_result.Visible = true;
        }
        else
        {
            cmd.CommandText = "delete from leave where sap_id='" + Session["sap_id"] + "' and departed='False'";
            i=cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Label_result.Text = "Leave has been Cancelled";
                Label_result.Visible = true;
            }
        }
        con.Close();
    }
}
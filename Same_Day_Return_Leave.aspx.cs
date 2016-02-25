using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Leave;

public partial class Same_Day_Return_Leave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_applyLeave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            DateTime start_time = Convert.ToDateTime(TextBox_date_from.Text) + new TimeSpan(16, 59, 59);
            DateTime return_time = Convert.ToDateTime(TextBox_date_from.Text) + new TimeSpan(21, 59, 59);
            DateTime departure_time = Convert.ToDateTime(TextBox_time_departure.Text);
            DateTime arrival_time = Convert.ToDateTime(TextBox_time_arrival.Text);
            if (TimeSpan.Compare(departure_time.TimeOfDay, start_time.TimeOfDay) == 1)
            {
                int i =Data_Access.apply_sameDayLeave(Session["sap_id"].ToString(), TextBox_date_from.Text, TextBox_reason.Text, TextBox_time_departure.Text);
                if (i == 1)
                {
                    Response.Write("forwarded to warden");
                }
            }
            else
            {
                Response.Write("forward to hod");
            }
        }
    }
}
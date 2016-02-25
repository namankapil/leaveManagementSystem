using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Leave;

public partial class Leave_same_day : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["sap_id"]!=null)
            Label_welcome.Text = "Welcome, " + Session["student_name"];
        else
            Response.Redirect("Login.aspx");
        }
    
    
    protected void Button_logout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");
    }
    protected void Button2_submit_Click(object sender, EventArgs e)
    { 
        DateTime t2 = Convert.ToDateTime("04:59:59 PM");
        DateTime t1 = Convert.ToDateTime(TextBox_timeAndDay.Text);
        if (TimeSpan.Compare(t1.TimeOfDay, t2.TimeOfDay) == 1) //forward to warden
        {
            int i= Data_Access.apply_sameDayLeave(Session["sap_id"].ToString(),t1.Date.ToString(),TextBox_reason_sameDay.Text,t1.TimeOfDay.ToString());
            if (i == 0)
            {
                Label_sameDay_result.Text = "You have already applied for same day leave";
                Label_sameDay_result.Visible = true;
            }
            else
            {
                Label_sameDay_result.Text = "Successfully Applied for Leave";
                Label_sameDay_result.Visible = true;
            }
        }
        else
        {
            String mentor_email;
            
            String i = Data_Access.Apply_Leave(Session["sap_id"].ToString(),t1.Date.ToString(),t1.Date.ToString(), TextBox_reason_sameDay.Text, out mentor_email, 1);
            Label_sameDay_result.Text = i;
            Label_sameDay_result.Visible = true;
            Data_Access.MailSend(mentor_email, "Same Day Leave", "Same day leave has been posted, you may take your action before 4:00 PM");
        }
    }
    protected void Button_viewStatus_Click(object sender, EventArgs e)
    {
        int hostelOrAcademic;
        int status=Data_Access.StatusSameDayLeave(Session["sap_id"].ToString(),out hostelOrAcademic);
        // hostelorAcademic=1 means academic & 0 means hostel wali
        Label_sameDay_result.Visible=true;
        if (hostelOrAcademic == 0 && status==0)
        {
            Label_sameDay_result.Text = "Leave forwarded to Warden";
        }
        else if (hostelOrAcademic == 0 && status == 3)
        {
            Label_sameDay_result.Text = "Leave approved by Warden";
        }
        else if (hostelOrAcademic == 1 && (status == 0 || status==2))
        {
            Label_sameDay_result.Text = "You have already applied for leave";
        }
        else if (hostelOrAcademic==1 && status==1)
        {
            Label_sameDay_result.Text = "Leave forwarded to HOD";
        }
        else if (hostelOrAcademic == 1 && status == 3)
        {
            Label_sameDay_result.Text = "Leave approved by HOD";
        }
        else if(status==10)
        {
            Label_sameDay_result.Text = "You have not applied for Leave";
        }
    }
    protected void Button_cancelLeave_Click(object sender, EventArgs e)
    {
        int hostelOrAcademic;
        int status = Data_Access.StatusSameDayLeave(Session["sap_id"].ToString(), out hostelOrAcademic);
        if (status == 10)
        {
            Label_sameDay_result.Visible = true;
            Label_sameDay_result.Text = "You have not applied for Leave";
        }
        else
        {
            int i;
            if (hostelOrAcademic == 1)
            {
                i = Data_Access.CancelSameDayLeave(Session["sap_id"].ToString(), hostelOrAcademic);
            }
            else
            {
                i = Data_Access.CancelSameDayLeave(Session["sap_id"].ToString(), hostelOrAcademic);
            }
            if (i >= 0)
            {
                Label_sameDay_result.Visible = true;
                Label_sameDay_result.Text = "Leave has been cancelled";
            }
        }
    }
}
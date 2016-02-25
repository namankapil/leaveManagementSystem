using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DAL_Leave;

public partial class Hostel_Check_Leave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["emp_id"] != null)
        {
            Label_welcome.Text = "Welcome, " + Session["employee_name"].ToString();
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                if (Session["post"].ToString() == "warden")
                {
                    da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.year,student.course,student.mobile_self,hostel_leave.date_from,hostel_leave.reason,hostel_leave.time_departure from student inner join hostel_leave on hostel_leave.sap_id=student.sap_id where hostel_leave.leave_status=0 and hostel_leave.departed='False'", con);
                }
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Columns.Count != 0)
                {
                    GridView_leaves.DataSource = dt;
                    GridView_leaves.DataBind();
                }
                else
                {
                    Label_leave_available.Visible = true;
                    Label_leave_available.Text = "No Leaves Found";
                }
                
            }
        }
        else
        {
            Response.Redirect("Leave_Apply.aspx");
        }
    }
    
    protected void Button_logout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");
    }

    protected void Btn1_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow) (sender as Control).Parent.Parent;
        int rowIndex = gvRow.RowIndex;
        String sap_id= GridView_leaves.Rows[rowIndex].Cells[1].Text;
        byte x=Data_Access.Approve_Reject(sap_id,"warden",1,"branch not req(hostel Leave)");
        if (x == 1)
        { Response.Write("Approved"); }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();
        if (Session["post"].ToString() == "warden")
        {
            da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.year,student.course,student.mobile_self,hostel_leave.date_from,hostel_leave.reason,hostel_leave.time_departure from student inner join hostel_leave on hostel_leave.sap_id=student.sap_id where hostel_leave.leave_status=0 and hostel_leave.departed='False'", con);
        }
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Columns.Count != 0)
        {
            GridView_leaves.DataSource = dt;
            GridView_leaves.DataBind();
        }
        else
        {
            Label_leave_available.Visible = true;
            Label_leave_available.Text = "No Leaves Found";
        }
                
    }

    protected void Btn_disapprove_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int rowIndex = gvRow.RowIndex;
        String sap_id = GridView_leaves.Rows[rowIndex].Cells[1].Text;
        byte x = Data_Access.Approve_Reject(sap_id, "warden",0, "branch not req(hostel Leave)");
        if (x == 1)
        { Response.Write("Rejected"); }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DAL_Leave;
using System.Web.Security;

public partial class Employee_Check_Leave : System.Web.UI.Page
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
                if (Session["post"].ToString() == "mentor")
                {
                    da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.branch,student.year,student.course,student.mobile_self,leave.date_from,leave.date_to,leave.academic_days,leave.reason from student inner join leave on leave.sap_id=student.sap_id where leave.leave_status=0 and leave.departed='False' and leave.emp_id='" + Session["emp_id"].ToString() + "'", con);
                }
                else if (Session["post"].ToString() == "hod")
                {
                    da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.branch,student.year,student.course,student.mobile_self,leave.date_from,leave.date_to,leave.academic_days,leave.reason from student inner join leave on leave.sap_id=student.sap_id where leave.leave_status=1 and leave.departed='False' and student.branch='" + Session["branch"].ToString() + "'", con);
                }
                else if (Session["post"].ToString() == "dean")
                {
                    da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.branch,student.year,student.course,student.mobile_self,leave.date_from,leave.date_to,leave.academic_days,leave.reason from student inner join leave on leave.sap_id=student.sap_id where leave.leave_status=2 and leave.departed='False'", con);
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
                if (Session["post"].ToString() == "mentor" || Session["post"].ToString() == "dean")
                {
                    GridView_leaves.Columns[1].Visible = false;
                }
            }
        }
        else
        {
            Response.Redirect("Leave_Apply.aspx");
        }
    }
    protected void Btn1_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int index = gvRow.RowIndex;

        //Fetches the employee id corresponding to the row index
        string sap_id = GridView_leaves.Rows[index].Cells[2].Text;
        string student_branch = GridView_leaves.Rows[index].Cells[4].Text;
        byte x= Data_Access.Approve_Reject(sap_id,Session["post"].ToString(),1,student_branch);
        if(x==1)
        {
        Response.Write("Approved");
        } 

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();
        if (Session["post"].ToString() == "mentor")
        {
            da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.branch,student.year,student.course,student.mobile_self,leave.date_from,leave.date_to,leave.reason from student inner join leave on leave.sap_id=student.sap_id where leave.leave_status=0 and leave.departed='False' and leave.emp_id='" + Session["emp_id"].ToString() + "'", con);
        }
        else if (Session["post"].ToString() == "hod")
        {
            da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.branch,student.year,student.course,student.mobile_self,leave.date_from,leave.date_to,leave.reason from student inner join leave on leave.sap_id=student.sap_id where leave.leave_status=1 and leave.departed='False' and student.branch='" + Session["branch"].ToString() + "'", con);
        }
        else if (Session["post"].ToString() == "dean")
        {
            da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.branch,student.year,student.course,student.mobile_self,leave.date_from,leave.date_to,leave.reason from student inner join leave on leave.sap_id=student.sap_id where leave.leave_status=2 and leave.departed='False'", con);
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
    protected void Button_logout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");
    }
    protected void Btn_disapprove_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int index = gvRow.RowIndex;

        //Fetches the employee id corresponding to the row index
        string sap_id = GridView_leaves.Rows[index].Cells[2].Text;
        string student_branch = GridView_leaves.Rows[index].Cells[4].Text;
        byte x = Data_Access.Approve_Reject(sap_id, Session["post"].ToString(), 0,student_branch);
        if (x == 1)
        {
            Response.Write("Rejected");
        }
         
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();
        if (Session["post"].ToString() == "mentor")
        {
            da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.branch,student.year,student.course,student.mobile_self,leave.date_from,leave.date_to,leave.reason from student inner join leave on leave.sap_id=student.sap_id where leave.leave_status=0 and leave.departed='False' and leave.emp_id='" + Session["emp_id"].ToString() + "'", con);
        }
        else if (Session["post"].ToString() == "hod")
        {
            da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.branch,student.year,student.course,student.mobile_self,leave.date_from,leave.date_to,leave.reason from student inner join leave on leave.sap_id=student.sap_id where leave.leave_status=1 and leave.departed='False' and student.branch='" + Session["branch"].ToString() + "'", con);
        }
        else if (Session["post"].ToString() == "dean")
        {
            da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.branch,student.year,student.course,student.mobile_self,leave.date_from,leave.date_to,leave.reason from student inner join leave on leave.sap_id=student.sap_id where leave.leave_status=2 and leave.departed='False'", con);
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

    protected void Btn_forwardToDean_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int index = gvRow.RowIndex;

        //Fetches the sap id corresponding to the row index
        string sap_id = GridView_leaves.Rows[index].Cells[2].Text;
        byte x = Data_Access.Approve_Reject(sap_id, Session["post"].ToString(), 2,"");
        if (x == 1)
        {
            Response.Write("Forwarded to Dean Sir");
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();
        if (Session["post"].ToString() == "mentor") 
        {
            da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.branch,student.year,student.course,student.mobile_self,leave.date_from,leave.date_to,leave.reason from student inner join leave on leave.sap_id=student.sap_id where leave.leave_status=0 and leave.departed='False' and leave.emp_id='" + Session["emp_id"].ToString() + "'", con);
        }
        else if (Session["post"].ToString() == "hod")
        {
            da.SelectCommand = new SqlCommand("select student.sap_id,student.name,student.branch,student.year,student.course,student.mobile_self,leave.date_from,leave.date_to,leave.reason from student inner join leave on leave.sap_id=student.sap_id where leave.leave_status=1 and leave.departed='False' and student.branch='" + Session["branch"].ToString() + "'", con);
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
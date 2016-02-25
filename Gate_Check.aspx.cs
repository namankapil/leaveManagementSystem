using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

public partial class Gate_Check : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select sap_id,branch from leave where departed='False' and leave_status=3", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView_gateCheck.DataSource = dt;
            GridView_gateCheck.DataBind();
    }
    protected void button_departed_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int index = gvRow.RowIndex;
        String sap_id = GridView_gateCheck.Rows[index].Cells[1].Text;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        if (con.State != ConnectionState.Open)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand("update leave set departed='True' where sap_id='"+sap_id+"'", con);
        Int32 i=cmd.ExecuteNonQuery();
        con.Close();
        if (i == 1)
        {
            Response.Write("Departed");
        }
        SqlDataAdapter da = new SqlDataAdapter("select * from leave where departed='False' and leave_status=3", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView_gateCheck.DataSource = dt;
        GridView_gateCheck.DataBind();
    }

    protected void Button_logout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");
    }
}
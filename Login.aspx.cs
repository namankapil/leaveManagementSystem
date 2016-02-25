using System;
using System.Web;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Leave;
using System.Security;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class LoginDefault : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Session["sap_id"] != null)
            {
                Response.Redirect("Leave_Apply.aspx");
            }
            else if (Session["emp_id"] != null)
            {
                if (Session["post"].ToString() == "gate_check")
                {
                    Response.Redirect("Gate_Check.aspx");
                }
                else
                {
                    Response.Redirect("Employee_Check_Leave.aspx");
                }
            }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String post,branch;
        if (Page.IsValid)
        {
            String password = Encrypt(TextBox_password.Text);
            String name;
            if (RadioButtonList1.SelectedValue == "Student")
            {
                name = Data_Access.Login(TextBox_ID.Text, password, 1,out post,out branch);
                if (name == "")
                {
                    Response.Write("ID not registered");
                }
                else if (name == "Invalid Password")
                {
                    Response.Write(name);
                }      
                else
                {
                    Session["student_name"] = name;
                    Session["sap_id"] = TextBox_ID.Text;
                    FormsAuthentication.RedirectFromLoginPage(name, false);
                    Response.Redirect("Home_Student/Leave_Apply.aspx");
                }
            }
            else
            {
                name = Data_Access.Login(TextBox_ID.Text, password, 0,out post,out branch);
                if (name == "")
                {
                    Response.Write("Employee ID not registered");
                }
                else if (name == "Invalid Password")
                {
                    Response.Write(name);
                }
                else
                {
                    Session["employee_name"] = name;
                    Session["emp_id"] = TextBox_ID.Text;
                    Session["post"] = post;
                    Session["branch"] = branch;
                    FormsAuthentication.RedirectFromLoginPage(name, false);
                    if (Session["post"].ToString() == "gate_check")
                    {
                        Response.Redirect("Gate_Check.aspx");
                    }
                    else if (Session["post"].ToString() == "warden")
                    {
                        Response.Redirect("Hostel_Check_Leave.aspx");
                    }
                    else
                    {
                        Response.Redirect("Employee_Check_Leave.aspx");
                    }
                }
            }
        }

    }

    private string Encrypt(string clearText)
    {
        string EncryptionKey = "17525455DN";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
}
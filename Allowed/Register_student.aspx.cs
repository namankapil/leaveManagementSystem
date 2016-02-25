using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Leave;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Security.Cryptography;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button_submit_Click(object sender, EventArgs e)
    {
        if (TextBox_sap.Text != "" && TextBox_name.Text != "" && DropDownList_branch.SelectedValue != "" &&
                DropDownList_year.SelectedValue != "" && DropDownList_course.SelectedValue != "" && DropDownList_gender.SelectedValue != "" &&
                TextBox_mobile_self.Text != "" && TextBox_mobile_parent.Text != "" &&
                TextBox_email.Text != "" && TextBox_address.Text != "" && DropDownList_mentor.SelectedValue!="")
        {
            if (Page.IsValid)
            {
                //encrypt sap_id here

                String password = Encrypt(TextBox_sap.Text.Trim());
                int i = Data_Access.Register_student(TextBox_sap.Text, TextBox_name.Text, password, DropDownList_branch.SelectedValue,
                    DropDownList_year.SelectedValue, DropDownList_course.SelectedValue, DropDownList_gender.SelectedValue, TextBox_mobile_self.Text, TextBox_mobile_parent.Text,
                    TextBox_email.Text, TextBox_address.Text,DropDownList_mentor.SelectedValue
                    );

                if (i == 2)
                {
                    Response.Write("Successful");
                }
                else if(i==3)
                {
                    Response.Write("SAP ID already registered");
                }
                else
                {
                    Response.Write("Unsuccessful");
                }
            }
        }else{
            Response.Write("Enter all the fields");
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
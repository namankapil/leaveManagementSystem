using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Leave;
using System.Text;
using System.Security.Cryptography;
using System.IO;

public partial class Faculty_register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid) 
        {
            String password = Encrypt(TextBox_password.Text);
            int j = Data_Access.Register_employee(TextBox_emp_id.Text, TextBox_name.Text, password, DropDownList_post.SelectedValue,
                                          TextBox_email.Text, DropDownList_branch.SelectedValue,TextBox_mobile.Text);
            if (j == 1)
            {
                Response.Write("Successful");
            }
            else if (j == 2)
            {
                Response.Write("Employee ID already registered");
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
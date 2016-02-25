using System;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace DAL_Leave
{
    public static class Data_Access
    {

        public static int i;
        public static int Register_student(String sap_id, String name, String password, String branch, String year, String course,
                                           String gender, String mobile_self, String mobile_parent, String email_id, String address, String mentor)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select sap_id from student where sap_id=@sapid", con);
            cmd.Parameters.AddWithValue("@sapid", sap_id);
            object id = cmd.ExecuteScalar();
            if (id == null)
            {
                cmd.CommandText = "insert into student values (@sap_id,@name,@password,@branch,@year,@course,@gender,@mobile_self,@mobile_parent,@email_id,@address)";
                cmd.Parameters.AddWithValue("@sap_id", sap_id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@branch", branch);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@course", course);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@mobile_self", mobile_self);
                cmd.Parameters.AddWithValue("@mobile_parent", mobile_parent);
                cmd.Parameters.AddWithValue("@email_id", email_id);
                cmd.Parameters.AddWithValue("@address", address);
                i = cmd.ExecuteNonQuery();
                cmd.CommandText = "select emp_id from employee where name='" + mentor + "'";
                String emp_id = cmd.ExecuteScalar().ToString();
                cmd.CommandText = "insert into assigned values(@sap,@emp_id)";
                cmd.Parameters.AddWithValue("@sap", sap_id);
                cmd.Parameters.AddWithValue("@emp_id", emp_id);
                i += cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            else
            {
                con.Close();
                return 3;
            }

        }

        public static int Register_employee(String emp_id, String name, String password, String post, String email, String branch, String mobile)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select emp_id from employee where emp_id=@emp", con);
            cmd.Parameters.AddWithValue("@emp", emp_id);
            object id = cmd.ExecuteScalar();
            if (id == null)
            {
                cmd.CommandText = "insert into employee values(@emp_id,@name,@password,@post,@email,@branch,@mobile)";
                cmd.Parameters.AddWithValue("@emp_id", emp_id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@post", post);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@branch", branch);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            else
            {
                return 2;
            }
        }

        public static String Login(String id, String password, int employee_or_student,out String post,out String branch) //employee_or_student =1 means student hai
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
                if (employee_or_student == 1) //for student
                {
                    cmd.CommandText="select password from student where sap_id=@sap";
                    cmd.Parameters.AddWithValue("@sap", id);
                }
                else // for employee
                {
                    cmd.CommandText="select password from employee where emp_id=@emp";
                    cmd.Parameters.AddWithValue("@emp", id);
                }
            object pass = cmd.ExecuteScalar();
            if (pass == null)  //id doesnt exist
            {
                con.Close();
                post = null;
                branch = "";
                return "";
            }
            else            // id exists
            {
                
                if (pass.ToString() == password)    //password correct
                {
                    String name;
                    cmd.Dispose();
                    if (employee_or_student == 1)
                    {
                        cmd.CommandText = "select name from student where sap_id=@sap_id";
                        cmd.Parameters.AddWithValue("@sap_id", id);
                        name = cmd.ExecuteScalar().ToString();
                        post = null;
                    }
                    else
                    {
                        cmd.CommandText = "select name,post,branch from employee where emp_id=@emp_id";
                        cmd.Parameters.AddWithValue("@emp_id", id);
                        SqlDataReader dr = cmd.ExecuteReader();
                        name = "";
                        while (dr.Read())
                        {
                            name = dr["name"].ToString();
                            post = dr["post"].ToString();
                            branch = dr["branch"].ToString();
                            return name;
                        }
                    }
                    
                    con.Close();
                    post = ""; //to prevent error(else code thinks if it may not return in while)
                    branch = "";
                    return name;
                }
                else    //wrong password
                {
                    post = null;
                    branch = null;
                    return "Invalid Password";
                }

            }
        }

        public static String Apply_Leave(String SAP_ID,String date_from, String date_to, String reason,out String mentor_email,int academic_days)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select emp_id from assigned where sap_id='"+SAP_ID+"'",con);
            String emp_id = cmd.ExecuteScalar().ToString();
            cmd.Dispose();
            cmd.CommandText = "select email from employee where emp_id='"+emp_id+"'";
            mentor_email = cmd.ExecuteScalar().ToString();
            cmd.Dispose();
            if (academic_days != 1)
            {
                cmd.CommandText = "select sap_id from leave where departed='False' and sap_id='" + SAP_ID + "'";
            }
            else 
            {
                cmd.CommandText = "select sap_id from leave where academic_days='" + academic_days + "' and departed='False' and sap_id='" + SAP_ID + "'";
            }
            object sap=cmd.ExecuteScalar();
            
            if (sap == null)     
            {
                cmd.CommandText = "select branch from student where sap_id='"+SAP_ID+"'";
                object branch = cmd.ExecuteScalar().ToString();
                cmd.CommandText = "insert into leave values(@sap,@emp,@date_from,@date_to,0,0,@reason,'"+branch.ToString()+"',@academic_days)";
                cmd.Parameters.AddWithValue("@sap", SAP_ID);
                cmd.Parameters.AddWithValue("@emp", emp_id);
                cmd.Parameters.AddWithValue("@date_from", (Convert.ToDateTime(date_from)).Date);
                cmd.Parameters.AddWithValue("@date_to", (Convert.ToDateTime(date_to)).Date);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.Parameters.AddWithValue("@academic_days", academic_days);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return "Successfully applied for Leave";
            }
            else
            {
                return "You have already applied for Leave";
            }
        }

        public static String Check_Status(String sap_id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select leave_status from leave where sap_id=@sap and departed='False'",con);
            cmd.Parameters.AddWithValue("@sap", sap_id);
            object x = cmd.ExecuteScalar();
            if (x == null)
            {
                return "You haven't applied for Leave";
            }
            else if (Convert.ToInt32(x) == 0)
            {
                return "Email Not Verified Yet";
            }
            else if (Convert.ToInt32(x) == 1)
            {
                return "Congratulations! Email Verfied";
            }
            else if (Convert.ToInt32(x) == 2)
            {
                return "Forwarded to Dean";
            }
            else if (Convert.ToInt32(x) == 4)
            {
                return "Rejected by Mentor";
            }
            else if (Convert.ToInt32(x) == 5)
            {
                return "Rejected by HOD";
            }
            else if (Convert.ToInt32(x) == 6)
            {
                return "Rejected by Dean";
            }
            else
            {
                return "Approved";
            }
        }

        public static byte Approve_Reject(String sap_id,String post,byte approveOrReject,String branch_student) //approveOrReject=1(approve),=0(reject)
        {
            byte x;
            SqlCommand cmd,cmd_getEmail;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (post == "mentor")
            {
               
                if (approveOrReject == 1) //approved
                {
                    cmd = new SqlCommand("update leave set leave_status=1 where sap_id='" + sap_id + "' and departed='False' and leave_status=0", con);
                    cmd_getEmail = new SqlCommand("select email from employee where post='hod' and branch='"+branch_student+"'",con);
                    MailSend(cmd_getEmail.ExecuteScalar().ToString(),"Nmims Leave","New leave has arrived");
                }
                else //reject
                {
                    cmd = new SqlCommand("update leave set leave_status=4 where sap_id='" + sap_id + "' and departed='False' and leave_status=0", con);
                    cmd_getEmail = new SqlCommand("select email_id from student where sap_id='" + sap_id + "'",con);
                    MailSend(cmd_getEmail.ExecuteScalar().ToString(), "Leave Status", "Leave Rejected by Mentor");
                }
                
            }
            else if (post == "hod")
            {
                if (approveOrReject == 1) //approved
                {
                    cmd = new SqlCommand("update leave set leave_status=3 where sap_id='" + sap_id + "' and departed='False' and leave_status=1", con);
                    cmd_getEmail = new SqlCommand("select email_id from student where sap_id='" + sap_id + "'",con);
                    MailSend(cmd_getEmail.ExecuteScalar().ToString(), "Leave Status", "Leave Approved by HOD");
                }
                else if (approveOrReject == 2) //forward to dean
                {
                    cmd = new SqlCommand("update leave set leave_status=2 where sap_id='" + sap_id + "' and departed='False' and leave_status=1", con);
                    cmd_getEmail = new SqlCommand("select email from employee where post='dean'", con);
                    MailSend(cmd_getEmail.ExecuteScalar().ToString(), "Leave Status", "Leave for more than 2 academic days, Forwarded to Dean Sir");
                }
                else  //reject
                {
                    cmd = new SqlCommand("update leave set leave_status=5 where sap_id='" + sap_id + "' and departed='False' and leave_status=1", con);
                    cmd_getEmail = new SqlCommand("select email_id from student where sap_id='" + sap_id + "'",con);
                    MailSend(cmd_getEmail.ExecuteScalar().ToString(), "Leave Status", "Leave Rejected by HOD");
                }
                     
            }

            else if (post == "warden") //for warden
            {
                if (approveOrReject == 1)
                {
                    cmd = new SqlCommand("update hostel_leave set leave_status=3 where sap_id='"+sap_id+"'and departed='False' and leave_status=0", con);
                    cmd_getEmail = new SqlCommand("select email_id from student where sap_id='" + sap_id + "'", con);
                    MailSend(cmd_getEmail.ExecuteScalar().ToString(), "Leave Status", "Leave approved by Hostel Authority");
                }
                else
                {
                    cmd = new SqlCommand("update hostel_leave set leave_status=6 where sap_id='"+sap_id+"'and departed='False' and leave_status=0",con);
                    cmd_getEmail = new SqlCommand("select email_id from student where sap_id='" + sap_id + "'", con);
                    MailSend(cmd_getEmail.ExecuteScalar().ToString(), "Leave Status", "Leave rejected by Hostel Authority");
                }
            }
            else // for dean
            {
                if (approveOrReject == 1) //approved
                {
                    cmd = new SqlCommand("update leave set leave_status=3 where sap_id='" + sap_id + "' and departed='False' and leave_status=2", con);
                    cmd_getEmail = new SqlCommand("select email_id from student where sap_id='" + sap_id + "'", con);
                    MailSend(cmd_getEmail.ExecuteScalar().ToString(), "Leave Status", "Leave has been Approved");
                }
                else //reject
                {
                    cmd = new SqlCommand("update leave set leave_status=6 where sap_id='" + sap_id + "' and departed='False' and leave_status=2", con);
                    cmd_getEmail = new SqlCommand("select email_id from student where sap_id='" + sap_id + "'", con);
                    MailSend(cmd_getEmail.ExecuteScalar().ToString(), "Leave Status", "Leave Rejected by Dean Sir");
                }
            }
            x = Convert.ToByte(cmd.ExecuteNonQuery());
            con.Close();
            return x;
        }

        public static void MailSend(String mailAddrTo, String subject, String body)
        {
            using (MailMessage mm = new MailMessage("nmimsleave@gmail.com", mailAddrTo))
            {
                mm.Subject = subject;
                mm.Body = body;
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                NetworkCredential networkCred = new NetworkCredential("nmimsleave@gmail.com", "rJK7tFg87WKWBB&$pH69A&nvngybfx");
                client.UseDefaultCredentials = true;
                client.Credentials = networkCred;
                client.Port = 587;
                client.Send(mm);
            }
        }

        public static int apply_sameDayLeave(String sap_id,String date_from,String reason,String time_departure)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select sap_id from hostel_leave where sap_id='" + sap_id + "' and departed='False' ",con);
            object j = cmd.ExecuteScalar();
            if (j == null)
            {
                cmd = new SqlCommand("insert into hostel_leave values (@sap_id,@date_from,0,0,@reason,@time_departure)", con);
                cmd.Parameters.AddWithValue("@sap_id", sap_id);
                cmd.Parameters.AddWithValue("@date_from", Convert.ToDateTime(date_from).Date);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.Parameters.AddWithValue("@time_departure", Convert.ToDateTime(time_departure).TimeOfDay);
                int i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return i;
            }
            else
            {
                cmd.Dispose();
                con.Close();
                return 0;
            }
        }

        public static int StatusSameDayLeave(String sap_id,out int hostelOrAcademic)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("select leave_status from hostel_leave where sap_id='" + sap_id + "' and departed='False'", con))
                {
                    object status_leave = cmd.ExecuteScalar();
                    if (status_leave == null) 
                    {
                        cmd.Dispose();
                        cmd.CommandText = "select leave_status from leave where sap_id='" + sap_id + "' and departed='False' and academic_days=1";
                        status_leave= cmd.ExecuteScalar();
                        if (status_leave == null)
                        {
                            hostelOrAcademic = 1; 
                            return 10;
                        }
                        else
                        {
                            hostelOrAcademic = 1; // 1 means academic leave
                            return Convert.ToInt32(status_leave);  
                        }
                    }
                    else
                    {
                        hostelOrAcademic = 0; // 0 means hostel leave
                        return Convert.ToInt32(status_leave);
                    }
                }
            }
        }

        public static int CancelSameDayLeave(String sap_id,int academicOrHostel)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd;
                
                if (academicOrHostel == 1)
                {
                    cmd = new SqlCommand("delete from leave where sap_id='" + sap_id + "' and academic_days=1 and departed='False'", con);
                }
                else
                {
                    cmd = new SqlCommand("delete from hostel_leave where sap_id='" + sap_id + "' and departed='False'", con);
                }
                int i = cmd.ExecuteNonQuery();
                con.Close();    
                return i;
            }
        }
    }
}


//0- forwarded to mentor OR email not verified
//1- forward to hod OR email verified
//2- forwarded to dean
//3- approved
//4- rejected by mentor
//5- rejected by hod
//6- rejected by dean
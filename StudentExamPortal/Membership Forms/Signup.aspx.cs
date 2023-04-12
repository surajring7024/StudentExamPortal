using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentExamPortal
{
    public partial class Signup : System.Web.UI.Page
    {
        static int x = 0;
        static int y = 1;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //ScriptManager.RegisterStartupScript(GetType(), "Javascript", "javascript:FUNCTIONNAME(); ", true);
        }

        protected void getinfo_Click(object sender, EventArgs e)
        {
            string en = Enroll.Text;
            SQl_Details a1 = new SQl_Details();

            string str = "select stu_id from M_student_Registration where Enroll_no='" + en + "'";
            string z = "select count(lg.stu_id) from M_Login lg inner join M_Student_Registration ms on lg.stu_id=ms.Stu_Id where ms.Enroll_No ='" + en + "'";
            try
            {
                a1.getConnection();
                y = Convert.ToInt32(a1.ExSc(z));
            }
            catch (Exception ex)
            {
                y = 1;
                Response.Write("<script> alert('"+ ex.Message + "'); </script>");
         
            }
            if (y == 0)
            {
                try
                {

                    x = Convert.ToInt32(a1.ExSc(str));
                    Session["stu_id"] = x;
                }
                catch (Exception ex)
                {
                    x = 0;
                }
                if (x != 0)
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "key", "toggleText()", true);
                    string xyz = "select email from M_student_Registration where Enroll_no = '" + en + "'";
                    string email = a1.ExSc(xyz).ToString();

                    Email.Text = email;

                    string abc = "select Mob_no from M_student_Registration where Enroll_no = '" + en + "'";
                    string mob = a1.ExSc(abc).ToString();

                    Mobile.Text = mob;

                    string a = "select stu_name from M_student_Registration where Enroll_no = '" + en + "'";
                    string name = a1.ExSc(a).ToString();
                    Name.Text = name;

                    string b = "select address from M_student_Registration where Enroll_no = '" + en + "'";
                    string address = a1.ExSc(b).ToString();
                    Address.Text = address;

                    string c = "select mc.course_name  from M_Course mc inner join M_Student_Registration ms on mc.Course_Id=ms.Course_Id where Enroll_no = '" + en + "'";
                    string course = a1.ExSc(c).ToString();
                    Course.Text = course;

                    string d = "select mc.Ac_year  from M_Academic mc inner join M_Student_Registration ms on mc.AC_Id=ms.AC_id where Enroll_no = '" + en + "'";
                    string academic = a1.ExSc(d).ToString();
                    Academic.Text = academic;

                    string f = "select mc.sem  from M_semister mc inner join M_Student_Registration ms on mc.sem_Id=ms.sem_id where Enroll_no = '" + en + "'";
                    string sem = a1.ExSc(f).ToString();
                    Semester.Text = sem;
                }
                else
                {
                    string s = "Enrollment No doesn't exist";
                   
                    Response.Write("<script> alert('" + s + "'); </script>");
                    
                }
            }
            else
            {
                Response.Write("<script> alert('User already exist'); </script>");
                
            }

            a1.CloseConnection();

        }

        protected void Send_Click(object sender, EventArgs e)
        {
            string otp="";
            string en = Enroll.Text;
            SQl_Details a1 = new SQl_Details();
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            otp += Convert.ToString(_rdm.Next(_min, _max));
            Session["OTPS"] = otp;
            string xyz = "select email from M_student_Registration where Enroll_no = '" + en + "'";
            int flag = 0;
            try
            {
                a1.getConnection();
                string email = a1.ExSc(xyz).ToString();
                string msg = "Sign Up OTP is:" + otp + "";
                string subject = "Signup OTP";

               a1.sendMail(email, msg, subject);
                Response.Write("<script> alert('OTP Sent Successfully'); </script>");
                flag = 1;
               
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('"+ ex.Message + "'); </script>");
                flag = 0;
            }
            if (flag == 1)
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "key", "toggleText1()", true);
            }
        }

        protected void Validate_Click(object sender, EventArgs e)
        {
            string otpval = OTP.Text;
            if (otpval == Session["OTPS"].ToString())
            {

                ScriptManager.RegisterStartupScript(this, Page.GetType(), "key", "toggleText2()", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, Page.GetType(), "key", "toggleText2()", true);
                Response.Write("<script> alert('OTP entered is wrong please re-enter'); </script>");         
                OTP.Text = "";
            }
        }

        protected void Valid_Click(object sender, EventArgs e)
        {

            SQl_Details a2 = new SQl_Details();
            try
            {
                a2.getConnection();
                string en = Username.Text;
                string sql = "select count(username) from M_Login  where username= '" + en + "'";
                int a = 1;
                try
                {
                    a = Convert.ToInt32(a2.ExSc(sql));

                }
                catch
                {
                    a = 1;
                }

                if (a == 0)
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "key", "toggleText3()", true);
                }
                else
                {
                    Response.Write("<script> alert('username already exist try another one'); </script>");
                    
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('"+ex.Message+"'); </script>");
                
            }
            a2.CloseConnection();
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            string en = Enroll.Text;
            string username = Username.Text;
            string password1 = Password.Text;
            string password2 = RePassword.Text;
            string sec_que = Que.Text;
            string sec_ans = Ans.Text;
            string mob = Mobile.Text;
            string email = Email.Text;
            
            DateTime now1 = System.DateTime.Now;
            string now = now1.ToString("yyyy-MM-dd HH:mm:ss");

            var key = "b14ca5898a4e4133bbce2ea2315a1916";

            SQl_Details a1 = new SQl_Details();
            var encryptedString1 = AesOperation.EncryptString(key, password1);
            var encryptedString2 = AesOperation.EncryptString(key, password2);
            string str2 = "insert into M_login values (" + Convert.ToInt32(Session["stu_id"]) + ",'" + username + "','" + encryptedString2 + "','" + sec_que + "','" + sec_ans + "','" + mob + "','" + email + "',0,0,0,NULL)";
            int a;
            //string str3 = "select top 1 login_id from M_login order by Login_Id desc";
            try
            {
                a1.getConnection();
                //a = Convert.ToInt32(a1.ExSc(str3));
            }
            catch
            {
                a = 0;
            }

            // string str4 = "insert into pwd_change_recovery values("+a+",'"+encryptedString2+"','"+now+"')";
            var decryptedString2 = AesOperation.DecryptString(key, encryptedString2);
            if (encryptedString1.Equals(encryptedString2))
            {
                try
                {

                    a1.executeCMD(str2);
                    // a1.executeCMD(str4);

                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "'); </script>");
                    
                }
                Response.Write("<script> alert('Sign Up Successful...!!'); </script>");
               

            }
            else
            {
                Response.Write("<script> alert('Enter same Password in both fields !!'); </script>");
                
            }

            string xyz = "select email from M_student_Registration where Enroll_no = '" + en + "'";

            try
            {
                a1.getConnection();
                string login = "select login_id from M_Login where username='" + username + "'";
                string email1 = a1.ExSc(xyz).ToString();
                try
                {
                    a = Convert.ToInt32(a1.ExSc(login));
                }
                catch 
                {
                    a = 0;
                }
                string sql5 = "insert into pwd_change_recovery values(" + a + ",'" + encryptedString2 + "','" + now + "')";
                string msg = "Successful Sign Up" + Environment.NewLine + "Enrollment No: " + en + Environment.NewLine + "Username: " + username + Environment.NewLine + "Password: " + decryptedString2 + "";
                string subject = "LOGIN Details";
                a1.executeCMD(sql5);
                a1.sendMail(email1, msg, subject);
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");               
            }
            a1.CloseConnection();
            Session.Abandon();
            Response.Redirect("../Membership Forms/Stu_Login.aspx");
        }
    }
}
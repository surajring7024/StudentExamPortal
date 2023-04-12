using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentExamPortal
{
    public partial class ForgetPass : System.Web.UI.Page
    {
        static int x;
        protected void Page_Load(object sender, EventArgs e)
        {
            Email.Enabled = false;
            Send.Enabled = false;
            OTP.Enabled = false;
            validate.Enabled = false;
            password.Enabled = false;
            Set.Enabled = false;
        }

        protected void getinfo_Click(object sender, EventArgs e)
        {
            SQl_Details a1 = new SQl_Details();
            string user = username.Text;
            string email;

            try
            {
                a1.getConnection();
                string sql = "select login_id from M_login where username='" + user + "'";
                
                string sql2 = "select email from M_login where username='" + user + "'";
                try
                {
                    x = Convert.ToInt32(a1.ExSc(sql));
                    Session["login_id"] = x;
                }
                catch
                {
                    x = 0;
                }
                if (x != 0)
                {
                    email = a1.ExSc(sql2).ToString();
                    Email.Text = email;
                    Send.Enabled = true;
                    getinfo.Enabled = false;
                    username.Enabled = false;
                }
                else
                {
                    Response.Write("<script> alert('Enter valid username'); </script>");
                }
            }
            catch
            {
                Response.Write("<script> alert('Enter Username...!'); </script>");
            }
            finally
            {
                a1.CloseConnection();
            }

        }

        protected void Send_Click(object sender, EventArgs e)
        {
            Session["IsOTPSend"] = false;
            Session["IsValid"] = false;
            SQl_Details a1 = new SQl_Details();

            string otp = "";
            //string en = textBox1.Text;

            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            otp += Convert.ToString(_rdm.Next(_min, _max));
            string user = username.Text;
            string xyz = Email.Text;
            

            try
            {
                a1.getConnection();
                string query_Prev_OTP_Id = "select Top 1 OTP_Id from OTP where Login_Id = " + Convert.ToInt32(Session["login_id"]) + " and  Validity= " + 1 + "";
                int Prev_OTP_Id = Convert.ToInt32(a1.ExSc(query_Prev_OTP_Id));

                string query_Prev_OTP_Id_False = "Update OTP set Validity = " + 0 + " where OTP_Id =" + Prev_OTP_Id + "";
                a1.executeCMD(query_Prev_OTP_Id_False);

                DateTime S_Time = DateTime.Now;
                string ST = S_Time.ToString("yyyy-MM-dd HH:mm:ss");
                string E_Time = S_Time.AddMinutes(5).ToString("yyyy-MM-dd HH:mm:ss");

                string msg = "Your OTP is: " + otp + "";
                string subject = "OTP for Forget Password";

                string sql = "insert into otp values('" + otp + "'," + x + ",'" + ST + "','" + E_Time + "',1)";
                a1.executeCMD(sql);
                a1.sendMail(xyz, msg, subject);
                Response.Write("<script> alert(' OTP Sent Successfully'); </script>");
               
               Session[ "IsOTPSend"] = true;
                OTP.Enabled = true;
                validate.Enabled = true;

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('"+ex.Message+"'); </script>");
                
            }
            
                a1.CloseConnection();
            
        }

        protected void validate_Click(object sender, EventArgs e)
        {
            SQl_Details a1 = new SQl_Details();
            string otp = OTP.Text;
            try
            {
                a1.getConnection();
                string query_E_Time = "Select E_Time from OTP where Login_Id = " + x + "and Validity = " + 1 + "";
                DateTime E_Time = Convert.ToDateTime(a1.ExSc(query_E_Time));
                DateTime CurrentTime = DateTime.Now;
                int result = DateTime.Compare(E_Time,CurrentTime);
                //MessageBox.Show("the result is " + result.ToString());
                if (result > 0)
                {
                    // to validate whether the Enter otp matches the otp of User's Login_Id in table
                    string query_OTP_Val = "select OTP_Id from OTP where OTP = " + otp + " and Login_Id = " + x + "and Validity = " + 1 + "";

                    int OTP_Id = Convert.ToInt32(a1.ExSc(query_OTP_Val));

                    try
                    {
                        if (OTP_Id != 0)
                        {
                            Response.Write("<script> alert('OTP Verified Successfully'); </script>");

                            Session["IsValid"] = true;
                            password.Enabled = true;
                           
                            Set.Enabled = true;
                        }
                        else
                        {
                            Response.Write("<script> alert('INVALID OTP'); </script>");
                            OTP.Enabled = true;
                            validate.Enabled = true;
                        }
                    }
                    catch
                    {
                        Response.Write("<script> alert('There is error in OTP section'); </script>");
                        OTP.Enabled = true;
                        validate.Enabled = true;
                    }
                }
                else
                {
                    Response.Write("<script> alert('OTP Expired'); </script>");
                    Send.Enabled = true;
                    
                   
                }
            }
            catch (Exception E)
            {
                Response.Write("<script> alert('"+E.Message+"'); </script>");
                OTP.Enabled = true;
                validate.Enabled = true;
            }
            finally
            {
                a1.CloseConnection();
            }
        }

        protected void Set_Click(object sender, EventArgs e)
        {
            SQl_Details a1 = new SQl_Details();
            int flag = 0;
            string password1 = password.Text;
            string password2 = password.Text;
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            var pass = AesOperation.EncryptString(key, password1);
            var ConformPassword = AesOperation.EncryptString(key, password2);

            try
            {
                a1.getConnection();

                if (Convert.ToBoolean(Session["IsValid"])  && Convert.ToBoolean(Session["IsOTPSend"]) && pass == ConformPassword)
                {
                    // To verify that the password user entering in neither of 3 previous password
                    string query_pass_change = "select LP_Id from Pwd_Change_Recovery where Prev_Password = '" + pass + "' ";
                    int LP_Id = Convert.ToInt32(a1.ExSc(query_pass_change));



                    if (LP_Id != 0)
                    {
                        password.Text = "";
                        password.Enabled = true;
                        Set.Enabled = true;
                        flag = 1;
                       
                        
                    }
                    else
                    {
                        // query to count the number of previous password
                        string query_Count_Prev_Password = "select Count(LP_Id) from Pwd_Change_Recovery where Login_Id =" + x + " ";
                        int CountPassword = Convert.ToInt32(a1.ExSc(query_Count_Prev_Password));




                        if (CountPassword >= 3)
                        {
                            // to get the LP_Id of first entered password
                            string query_Get_First_Pass = "select top 1 LP_Id from Pwd_Change_Recovery where Login_Id = " + x + " Order By LP_Id ";
                            // to delete the First Entered Password
                            int L_Id = Convert.ToInt32(a1.ExSc(query_Get_First_Pass));
                            string Delete_First_Pass = "Delete from Pwd_Change_Recovery where LP_Id = " + L_Id + "";
                            a1.executeCMD(Delete_First_Pass);

                        }

                        string t = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        // to add the new password  to the Pwd_Change_Recovery
                        string query_insert_password = "Insert Into Pwd_Change_Recovery(Login_Id,Prev_Password,PassChange_DateTime) values(" + x + ",'" + pass + "','" + t + "')";
                        a1.executeCMD(query_insert_password);
                        string update = "update M_Login set password='" + ConformPassword + "' where Login_id=" + x + "";
                        a1.executeCMD(update);

                        Response.Write("<script> alert('submitted succesfully');window.location='\\Stu_Login.aspx' </script>");

                       // Response.Redirect("../Membership Forms/Stu_Login.aspx");                                           
                    }
                }
                else
                {
                    Response.Write("<script> alert('Generate the New OTP and then Verify It'); </script>");
                    Send.Enabled = true;
                    
                    
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('"+ex.Message+"'); </script>");
                password.Enabled = true;
                Set.Enabled = true;
            }
                a1.CloseConnection();
            
            Session.Abandon();
            if (flag == 1)
            {
                Response.Write("<script> alert('Password Already Exists..... Please Try Another Password') </script>");
            }
        }
        
    }
}
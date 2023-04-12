using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentExamPortal
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            //login
            SQl_Details a3 = new SQl_Details();
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            string user = username.Text;
            string pwd = password.Text;
            string xyz = "select fail_count from M_login where username='" + user + "'";
            string abc = "select disable_time from M_login where username='" + user + "'";
            string cmd7 = "select login_id from M_login where username= '" + user + "'";
            DateTime current_time = DateTime.Now;
            DateTime disabletime;
            string z;
            int f = 0, w = 0;
            int result = 0;
            try
            {
                
                a3.getConnection();
                f = Convert.ToInt32(a3.ExSc(xyz));
                z = Convert.ToString(a3.ExSc(abc));
                w = Convert.ToInt32(a3.ExSc(cmd7));
                // z=disabletime.ToString();    
                if (z == "")
                {
                    result = 0;
                }
                else
                {
                    disabletime = Convert.ToDateTime(z);
                    result = DateTime.Compare(current_time, disabletime);
                }
            }
            catch
            {
                f = 0;
                result = 0;
            }
            finally
            {
                a3.CloseConnection();
            }
            if (result > 0)
            {
                try
                {
                    a3.getConnection();
                    string cmd6 = "update M_login set fail_count=0,is_temp_dis=0,disable_time=NULL where login_ID=" + w + "";
                    a3.executeCMD(cmd6);
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('"+ex.Message+"'); </script>");
                    
                }
                
                    a3.CloseConnection();
                

            }

            if (f < 3 && result >= 0)
            {


                var encryptedString = AesOperation.EncryptString(key, pwd);
                string cmd1 = "select login_id from M_login where username= '" + user + "' and password='" + encryptedString + "'";
                string cmd4 = "select login_id from M_login where username= '" + user + "'";
                string cmd8 = "select stu_id from M_login where username='" + user + "'";
                string hostName = Dns.GetHostName(); // Retrive the Name of HOST

                // Get the IP
                string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

                //MAC address;
                string mac = "";
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {

                    if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                    {
                        if (nic.GetPhysicalAddress().ToString() != "")
                        {
                            mac = nic.GetPhysicalAddress().ToString();
                        }
                    }
                }
                try
                {
                    a3.getConnection();
                    int b = 0;
                    int c = 0;
                    int stu = 0;
                    try
                    {
                        b = (Int32)a3.ExSc(cmd1);

                    }
                    catch (Exception E)
                    {
                        b = 0;
                    }
                    try
                    {
                        c = (Int32)a3.ExSc(cmd4);
                    }
                    catch
                    {
                        c = 0;
                    }
                    try
                    {
                        stu = (Int32)a3.ExSc(cmd8);

                    }
                    catch (Exception E)
                    {
                        stu = 0;
                    }
                    if (b != 0)
                    {
                        //Response.Write("<script> alert('Login Success'); </script>");

                        //student page
                        

                        DateTime d = DateTime.Now;
                        
                        string p = d.ToString("yyyy-MM-dd HH:mm:ss");
                        string cmd2 = "insert into Login_transitions values(" + b + ",'" + p + "',NULL,'" + myIP + "','" + mac + "','Login Success')";
                        a3.executeCMD(cmd2);
                        Session["Stu_id"] = stu;
                        Response.Redirect("../Student Forms/ShowProfile.aspx");

                    }
                    else
                    {
                        Response.Write("<script> alert('Username Password Incorrect'); </script>");
                        // reg

                        DateTime d = DateTime.Now;
                        string p = d.ToString("yyyy-MM-dd HH:mm:ss");
                        string cmd2 = "insert into Login_transitions values(" + c + ",'" + p + "',NULL,'" + myIP + "','" + mac + "','Username or pwd is incorrect')";
                        f++;
                        string cmd3 = "Update M_login set Fail_count=" + f + " where login_id=" + c + "";

                        a3.executeCMD(cmd2);
                        a3.executeCMD(cmd3);
                        if (f == 3)
                        {
                            Response.Write("<script> alert('Your account is disable for 1 hour'); </script>");
                            DateTime dateTime1 = DateTime.Now;
                            DateTime dateTime = dateTime1.AddHours(1);
                            string p1 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                            string cmd5 = "update M_login set is_temp_dis=1,disable_time='" + p1 + "' where login_ID=" + c + "";
                            a3.executeCMD(cmd5);

                        }
                        username.Text = "";
                        password.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "'); </script>");
                    
                }
                
                    a3.CloseConnection();
                    
            }
            else
            {
                Response.Write("<script> alert('Your account is disable for 1 hour'); </script>");
               
            }
            
        }
    

        protected void Button1_Click(object sender, EventArgs e)
        {
            //forget password
            Response.Redirect("Membership Forms/ForgetPass.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            Response.Redirect("Signup.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentExamPortal
{
    public partial class Student_Registeration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (HttpContext.Current.Session["login"] == null)
            {
                Response.Redirect("../Membership Forms/Admin_Login.aspx");
            }

            
            if (!IsPostBack)
            {
                if (Session["login"] == null)
                {
                    Response.Redirect("../Membership Forms/Admin_Login.aspx");
                }
                SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Student_Final_Project;Integrated Security=True");

                string str1 = "select * from M_academic";
                string str2 = "select * from M_semister";
                string str3 = "select * from M_course";
                try
                {
                    SqlCommand cmd = new SqlCommand(str1, con);
                    SqlCommand cmd2 = new SqlCommand(str2, con);
                    SqlCommand cmd3 = new SqlCommand(str3, con);
                    con.Open();

                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        string temp = r[1].ToString();
                        DropDownList1.Items.Add(temp);
                    }
                    r.Close();

                    SqlDataReader r2 = cmd2.ExecuteReader();
                    while (r2.Read())
                    {
                        string x = r2[2].ToString();
                        DropDownList2.Items.Add(x);
                    }
                    r2.Close();

                    SqlDataReader r3 = cmd3.ExecuteReader();
                    while (r3.Read())
                    {
                        string y = r3[2].ToString();
                        DropDownList3.Items.Add(y);
                    }
                    r3.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "'); </script>");
                }
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SQl_Details a1 = new SQl_Details();

            string name = firstname.Text +" "+ midname.Text +" "+ lastname.Text;
            string address = Address.Text;
            string email = Email.Text;
            string phone = Mobile.Text;
            string ac_year = DropDownList1.Text;
            string sem = DropDownList2.Text;
            string course = DropDownList3.Text;
            string gender =DropDownList4.Text;

            DateTime abc = Convert.ToDateTime( DOB.Text);
            string dob = abc.ToString("yyyy-MM-dd");

            try
            {
                string sql = "select top 1 stu_id from M_student_registration order by stu_id desc ";  //student id
                string sql2 = "select course_id from M_course where course_name='" + course + "'";          //course id
                string sql3 = "select Sem_id from M_semister where sem='" + sem + "'";                  // sem id
                string sql4 = "select Ac_id from M_academic where AC_year='" + ac_year + "'";
                int y = 0;
                int z = 0;
                int w = 0;
                int v = 0;
                try
                {
                    a1.getConnection();
                    y = Convert.ToInt32(a1.ExSc(sql));
                    z = Convert.ToInt32(a1.ExSc(sql2));
                    w = Convert.ToInt32(a1.ExSc(sql3));
                    v = Convert.ToInt32(a1.ExSc(sql4));
                    y++;
                }
                catch (Exception ex)
                {                  
                    y = 0;
                    z = 0;
                    w = 0;
                    v = 0;
                    
                }
                string enroll = course + "0" + z + "18" + w + "" + y + "";          //Enrollment No

                string str = "insert into M_student_registration values('" + name + "','" + enroll + "'," + z + ",'" + email + "','" + phone + "','" + address + "','" + gender + "','" + dob + "'," + v + "," + w + ",1,1)";
                a1.executeCMD(str);
                string msg = "Dear Student, Your Registration is successful...! "+enroll+" this is your Enrollment No. Please Sign Up Before Login.....! ";
                string subject = "Enrollment No.";
                a1.sendMail(email,msg,subject);
                //redirect
                a1.CloseConnection();

                Response.Write("<script> alert('Your Enrollment No:" + enroll + "'); </script>");
                Response.Redirect("../Admin Forms/Student_Registeration.aspx");
            }
            catch
            {
                Response.Write("<script> alert('You cannot leave blank fields'); </script>");
            }
        }
        private void Form6_Load(object sender, EventArgs e)
        {

            
        }
    }
}
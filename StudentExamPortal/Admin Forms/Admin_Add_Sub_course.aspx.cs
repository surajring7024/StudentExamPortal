using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentExamPortal
{
    public partial class Admin_Add_Sub_course : System.Web.UI.Page
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
                string str4 = "select * from M_Subject";
                try
                {
                    SqlCommand cmd = new SqlCommand(str1, con);
                    SqlCommand cmd2 = new SqlCommand(str2, con);
                    SqlCommand cmd3 = new SqlCommand(str3, con);
                    SqlCommand cmd4 = new SqlCommand(str4, con);
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

                    SqlDataReader r4 = cmd4.ExecuteReader();
                    while (r4.Read())
                    {
                        string z = r4[2].ToString();
                        DropDownList4.Items.Add(z);
                    }
                    r4.Close();
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
            string ac = DropDownList1.Text;
            string sem = DropDownList2.Text;
            string course = DropDownList3.Text;
            string Subject = DropDownList4.Text;
            string sql1 = "select Ac_id from M_Academic where Ac_year='" + ac + "'";
            string sql2 = "select sem_id from M_semister where sem='" + sem + "'";
            string sql3 = "select course_id from M_Course where Course_name='" + course + "'";
            string sql4 = "select sub_id from M_Subject where sub_name='" + Subject + "'";
            SQl_Details a1 = new SQl_Details();
            int a, b, c, d;
            try
            {
                a1.getConnection();
                a = Convert.ToInt32(a1.ExSc(sql1));
                b = Convert.ToInt32(a1.ExSc(sql2));
                c = Convert.ToInt32(a1.ExSc(sql3));
                d = Convert.ToInt32(a1.ExSc(sql4));

            }
            catch
            {
                a = 0;
                b = 0;
                c = 0;
                d = 0;
            }
            string str = "insert into X_Course_sub  values(" + d + "," + c + "," + a + "," + b + ")";
            try
            {
                a1.executeCMD(str);
                Response.Redirect("../Admin Forms/Admin_Add_Sub_Course.aspx");
            }
            catch(Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
            a1.CloseConnection();
        }
    }
}
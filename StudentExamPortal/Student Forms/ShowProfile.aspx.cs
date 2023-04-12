using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentExamPortal
{
    public partial class ShowProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (HttpContext.Current.Session["Stu_Id"] == null)
            {
                Response.Redirect("../Membership Forms/Stu_Login.aspx");
            }

            Enroll.Enabled = false;
            Name.Enabled = false;
            Email.Enabled = false;
            Mobile.Enabled = false;
            Address.Enabled = false;
            Course.Enabled = false;
            Academic.Enabled = false;
            Semester.Enabled = false;
            string stu_id = Session["Stu_id"].ToString();
            
            

           // SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Student_Final_Project;Integrated Security=True");
            SQl_Details a1 = new SQl_Details();

            

            string str = "select * from M_student_registration where stu_id=" + stu_id + "";
            try
            {
                
               
                a1.getConnection();
                SqlDataReader r = (SqlDataReader)a1.GetSqlDataReader(str); 
                r.Read();
                string temp = r[2].ToString();
                Enroll.Text = temp;
                r.Close();

                SqlDataReader r2 = (SqlDataReader)a1.GetSqlDataReader(str);
                r2.Read();
                string temp2 = r2[1].ToString();
                Name.Text = temp2;
                r2.Close();

                SqlDataReader r3 = (SqlDataReader)a1.GetSqlDataReader(str);
                r3.Read();
                string temp3 = r3[3].ToString();
                Course.Text = temp3;
                r3.Close();

                SqlDataReader r4 = (SqlDataReader)a1.GetSqlDataReader(str);
                r4.Read();
                string temp4 = r4[5].ToString();
                Academic.Text = temp4;
                r4.Close();

                SqlDataReader r5 = (SqlDataReader)a1.GetSqlDataReader(str);
                r5.Read();
                string temp5 = r5[9].ToString();
                Semester.Text = temp5;
                r5.Close();

                SqlDataReader r6 = (SqlDataReader)a1.GetSqlDataReader(str);
                r6.Read();
                string temp6 = r6[10].ToString();
                Mobile.Text = temp6;
                r6.Close();

                SqlDataReader r7 = (SqlDataReader)a1.GetSqlDataReader(str);
                r7.Read();
                string temp7 = r7[4].ToString();
                Email.Text = temp7;
                r7.Close();

                SqlDataReader r8 = (SqlDataReader)a1.GetSqlDataReader(str);
                r8.Read();
                string temp8 = r8[6].ToString();
                Address.Text = temp8;
                r8.Close();

            }
            catch
            {

            }
            finally
            {
                a1.CloseConnection();
            }
        }
    }
}
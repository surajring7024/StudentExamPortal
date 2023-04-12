using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentExamPortal
{
    public partial class Admin_Add_Exam : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (HttpContext.Current.Session["login"] == null)
            {
                Response.Redirect("../Membership Forms/Admin_Login.aspx");
            }
            
            if (!IsPostBack) {
                if (Session["login"] == null)
                {
                    Response.Redirect("../Membership Forms/Admin_Login.aspx");
                }

                SQl_Details details = new SQl_Details();
                string str = "select * from M_Course";
                string str2 = "select * from M_exam";
                try
                {
                    
                    details.getConnection();
                   
                    SqlDataReader r =(SqlDataReader)details.GetSqlDataReader(str) ;
                    while (r.Read())
                    {
                        DropDownList1.Items.Add(r[2].ToString());
                    }
                    r.Close();

                    SqlDataReader r2 = (SqlDataReader)details.GetSqlDataReader(str2);
                    while (r2.Read())
                    {
                        DropDownList3.Items.Add(r2[1].ToString());
                    }
                    r2.Close();
                }
                catch (Exception ee)
                {
                    Response.Write("<script> alert('" + ee.Message + "'); </script>");
                }
                finally
                {
                    details.CloseConnection();
                }
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            SQl_Details a1 = new SQl_Details();
            string examname1 = DropDownList3.SelectedItem.ToString();
            string coursename1 = DropDownList1.SelectedItem.ToString();
            string subjectname1 = DropDownList2.SelectedItem.ToString();
           
            string d1 = Stime.Text;
            string d2 = Etime.Text;
            DateTime d3 = Convert.ToDateTime(d2);
            DateTime d4 = Convert.ToDateTime(d2);
            string d5 = d3.ToString("yyyy-MM-dd HH:mm:ss");
            string d6 = d4.ToString("yyyy-MM-dd HH:mm:ss");
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Student_Final_Project;Integrated Security=True;MultipleActiveResultSets=true");

            string str = "select * from Exam_Time_table where Course_Id = (select Course_id from M_Course where Course_Name = @coursename) and Sub_Id = (select Sub_Id from M_Subject where Sub_Name = @subjectname) and Exam_id=(select Exam_id from M_Exam where exam_name=@examname)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.Add("@coursename", SqlDbType.VarChar).Value = coursename1;
            cmd.Parameters.Add("@subjectname", SqlDbType.VarChar).Value = subjectname1;
            cmd.Parameters.Add("@examname", SqlDbType.VarChar).Value = examname1;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    reader.Close();                    
                    con.Close();
                   
                    Response.Write("<script> alert('Time Table for this exam Already Existed'); </script>");
                }

                else
                {
                    reader.Close();
                    a1.getConnection();
                    string str2 = "select Exam_Id from M_Exam where Exam_Name='" + examname1 + "'";
                    string str3 = "select Course_id from M_Course where Course_Name ='" + coursename1 + "'";
                    string str4 = "select Sub_Id from M_Subject where Sub_Name ='" + subjectname1 + "'";
                    int a = 0;
                    try
                    {
                        a1.getConnection();
                        a = Convert.ToInt32(a1.ExSc(str2));
                    }
                    catch
                    {
                        a = 0;
                    }
                    int b = 0;
                    try
                    {
                        b = Convert.ToInt32(a1.ExSc(str3));
                    }
                    catch
                    {
                        b = 0;
                    }
                    int c = 0;
                    try
                    {
                        c = Convert.ToInt32(a1.ExSc(str4));
                    }
                    catch
                    {
                        c = 0;
                    }
                    string str1 = "insert into Exam_Time_table values(" + a + "," + b + "," + c + ",'" + d5 + "','" + d6 + "')";

                    a1.executeCMD(str1);
                    //
                    Response.Redirect("../Admin Forms/Admin_Add_Exam.aspx");
                    

                }
            }
            catch (Exception EE)
            {
                Response.Write("<script> alert('" + EE.Message + "'); </script>");
            }
            finally
            {
                a1.CloseConnection();

            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Text = "";
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Student_Final_Project;Integrated Security=True;MultipleActiveResultSets=true");
            string coursename1 = DropDownList1.SelectedItem.ToString();
            string str = "select s.sub_name from M_Subject s inner join X_Course_Sub xcs on s.Sub_Id = xcs.Sub_Id inner join M_Course mc on mc.Course_Id = xcs.Course_Id where mc.Course_Name = '" + coursename1 + "'";
            SqlCommand cmd = new SqlCommand(str, con);

            try
            {
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    DropDownList2.Items.Add(r[0].ToString());

                }
                r.Close();

            }
            catch (Exception ee)
            {
                Response.Write("<script> alert('" + ee.Message + "'); </script>");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}
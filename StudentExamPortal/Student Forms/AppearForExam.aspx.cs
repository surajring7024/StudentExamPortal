using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace StudentExamPortal
{
    public partial class AppearForExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (HttpContext.Current.Session["Stu_Id"] == null)
            {
                Response.Redirect("../Membership Forms/Stu_Login.aspx");
            }

            if (!IsPostBack)
            {
                SQl_Details a1  = new SQl_Details();
                a1.getConnection();

                string query_get_Course_Id = "select Course_Id from M_Student_Registration where Stu_Id = " + Convert.ToInt32(Session["Stu_Id"]) + "";
                Session["Course_Id"] = 0;

                try
                {
                    Session["Course_Id"] = Convert.ToInt32(a1.ExSc(query_get_Course_Id));
                }
                catch
                {
                    Session["Course_Id"] = 0;
                }

                string query_GetExam_Id = "select distinct Exam_Id from X_student_exam where Stu_id =" + Convert.ToInt32(Session["Stu_Id"]) + "";
                SqlDataAdapter da_Exam = (SqlDataAdapter)a1.GETSqlDataAdapter(query_GetExam_Id);
                DataSet ds_Exam = new DataSet();
                da_Exam.Fill(ds_Exam);
                try
                {
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter();
                    foreach (DataRow i in ds_Exam.Tables[0].Rows)
                    {
                        int Exam_Id = 0;
                        try
                        {
                            Exam_Id = Convert.ToInt32(i[0]);
                        }
                        catch
                        {
                            Exam_Id = 0;
                        }

                        //to get all the subject related to this course and exam
                        string query_GetSub_Id = "select Sub_Id from Exam_Time_Table where Exam_Id=" + Exam_Id + " and Course_Id=" + Convert.ToInt32(Session["Course_Id"]) + " order by S_Time";
                        SqlDataAdapter da1 = (SqlDataAdapter)a1.GETSqlDataAdapter(query_GetSub_Id);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        try
                        {
                            foreach (DataRow dr in ds1.Tables[0].Rows)
                            {
                                int Sub_Id = Convert.ToInt32(dr[0]);

                                // to get Sub_Id . for verifing the exam starting time is past the current time 
                                string query_Exam_S_Time = "select S_Time from Exam_Time_Table where Exam_Id = " + Exam_Id + " and Course_Id = " + Convert.ToInt32(Session["Course_Id"]) + " and Sub_Id = " + Sub_Id + "";

                                string query_Exam_E_Time = "select E_Time from Exam_Time_Table where Exam_Id = " + Exam_Id + " and Course_Id = " + Convert.ToInt32(Session["Course_Id"]) + " and Sub_Id = " + Sub_Id + "";

                                DateTime S_Time = Convert.ToDateTime(a1.ExSc(query_Exam_S_Time));
                                DateTime E_Time = Convert.ToDateTime(a1.ExSc(query_Exam_E_Time));

                                DateTime Current = DateTime.Now;

                                int Result = DateTime.Compare(S_Time, Current);
                                int Result1 = DateTime.Compare(E_Time, Current);

                                if (Result1 > 0 && Result < 0)
                                {
                                    da = (SqlDataAdapter)a1.GETSqlDataAdapter("select distinct M.Exam_Name, S.Sub_Name, S_Time, E_Time from       M_Subject S inner join Exam_Time_Table E on S.Sub_Id = E.Sub_Id inner join M_Exam M on      E.Exam_Id=M.Exam_Id  where M.Exam_Id = " + Exam_Id + " and Course_Id =" + Convert.ToInt32(Session["Course_Id"]) + " and M.Is_Enable = " + 1 + " and S.Sub_Id =         " + Sub_Id + "");

                                    da.Fill(ds);
                                    GridView1.DataSource = ds.Tables[0];
                                    GridView1.DataBind();
                                }
                            }
                        }
                        catch
                        {
                            Response.Write("<script>alert('something wrong while creating dataset1');</script>");
                        }
                    }
                }
                catch
                {
                    Response.Write("<script>alert('Something went wrong while displaying Exam');</script>");
                }
                a1.CloseConnection();

            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btninsert_Click(object sender, EventArgs e)
        {
            SQl_Details a1=new SQl_Details();

            a1.getConnection();

            string Exam_Name = Convert.ToString(GridView1.SelectedRow.Cells[2].Text);
            string Sub_Name = Convert.ToString(GridView1.SelectedRow.Cells[3].Text);


            // Get Exam_Id
            string query_Exam_Id = "select Exam_Id from M_Exam where Exam_Name = '" + Exam_Name + "'";
            Session["Exam_Id"] = Convert.ToInt32(a1.ExSc(query_Exam_Id));


            // Get Sub_Id
            string query_Sub_Id = "select Sub_Id from M_Subject where Sub_Name = '" + Sub_Name + "'";
            Session["Sub_Id"] = Convert.ToInt32(a1.ExSc(query_Sub_Id));

            // to check the student already appear for the exam or not
            string query_val = "select SEHId from X_Student_Exam_Header where Sub_Id = " + Convert.ToInt32(Session["Sub_Id"]) + " and Exam_Id = " + Convert.ToInt32(Session["Exam_Id"]) + " and stu_id="+ Session["Stu_ID"] + "";
            int SEH_Id;
            try
            {
                SEH_Id= Convert.ToInt32(a1.ExSc(query_val)); 
            }
            catch 
            {
                SEH_Id = 0;
            }
             

            // to check the student appear for the exam before examTime
            string query_Time_Val = "select S_Time, E_Time from Exam_Time_Table where Exam_Id = " + Convert.ToInt32(Session["Exam_Id"]) + " and Sub_Id = " + Convert.ToInt32(Session["Sub_Id"]) + "";

            SqlDataReader r = (SqlDataReader)a1.GetSqlDataReader(query_Time_Val);

            r.Read();
            DateTime S_Time = Convert.ToDateTime(GridView1.SelectedRow.Cells[4].Text);
            DateTime E_Time = Convert.ToDateTime(GridView1.SelectedRow.Cells[5].Text);
            r.Close();

            DateTime Current_Time = DateTime.Now;

            int appear_Early = DateTime.Compare(S_Time, Current_Time);
            int appear_Late = DateTime.Compare(Current_Time, E_Time);

            if (SEH_Id != 0)
            {
                Response.Write("<script>alert('Already Given the Exam');</script>");
            }

            else
            {
               // Response.Redirect("ExamPaper.aspx");
                if (appear_Early > 0)
                {
                    Response.Write("<script>alert('Exam Yet to start');</script>");
                }
                else if (appear_Late >= 0)
                {
                    Response.Write("<script>alert('You are late Exam is Already Over');</script>");
                }
                else
                {
                    Response.Redirect("ExamPaper.aspx");
                }

            }
        }

    }
}
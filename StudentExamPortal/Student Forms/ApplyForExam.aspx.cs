using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.CodeDom.Compiler;
using System.Data.SqlClient;

namespace StudentExamPortal
{
    public partial class ApplyForExam : System.Web.UI.Page
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
                SQl_Details a1 = new SQl_Details();

                a1.getConnection();
                // to fetch the subject related to the student . for exam fetching purpose
                string query_Fetch_Course_Id = "Select Course_Id from M_Student_Registration where Stu_Id =" +
                    Convert.ToInt32(Session["Stu_id"]) + "";
                int Course_Id = Convert.ToInt32(a1.ExSc(query_Fetch_Course_Id));


               // string query_GetExam_Id = "select distinct Exam_Id from Exam_Time_Table where Course_Id =" + Course_Id + "";
                // SqlDataAdapter da = new SqlDataAdapter(query_GetExam_Id,con);
                SqlDataAdapter da = (SqlDataAdapter)a1.GETSqlDataAdapter("select distinct Exam_Id from Exam_Time_Table where Course_Id =" + Course_Id + "");
                DataSet ds = new DataSet();
                da.Fill(ds);
                try
                {
                    foreach (DataRow i in ds.Tables[0].Rows)
                    {
                        int Exam_Id = Convert.ToInt32(i[0]);
                        if (Exam_Id != 0)
                        {
                            // to validate that the particular exam is pass its appear date/time or the student is already register to the exam.
                            string query_Exam_Is_Enable = "select IsEnable from X_Student_Exam where Exam_Id = " + Exam_Id + " and Stu_Id = " + Convert.ToInt32(Session["Stu_id"]) + "";
                            bool Is_Enable = false;
                            try
                            {
                                Is_Enable = Convert.ToBoolean(a1.ExSc(query_Exam_Is_Enable));
                            }
                            catch
                            { }

                            // the use of order by S_Time Desc is to get the S_Time of last Subject From current Exam
                            string query_Exam_Start_Time = "select top(1) S_Time from Exam_Time_Table where Exam_Id = " + Exam_Id + " order by S_Time Desc";
                            DateTime S_Time = Convert.ToDateTime(a1.ExSc(query_Exam_Start_Time));

                            DateTime Current_Time = DateTime.Now;

                            int result = DateTime.Compare(Current_Time, S_Time);

                            if (result > 0)
                            {
                                // to disable the exam if its past the exam time 
                                string query_Update_Is_Enable = "update X_Student_Exam set IsEnable = " + 0 + "     where Exam_Id = " + Exam_Id + " and Stu_Id = " + Convert.ToInt32(Session["Stu_id"]) + " ";
                                a1.executeCMD(query_Update_Is_Enable);
                            }
                            else
                            {
                                if (!Is_Enable)
                                {
                                    // to fetch Exam names for paticular Subject
                                    string query_Exam_Name = "Select Exam_Name from M_Exam where Exam_Id = " + Exam_Id + "";
                                    string Exam_Name = (a1.ExSc(query_Exam_Name)).ToString();


                                    // to add the Exam name in check box list
                                    CheckBoxList1.Items.Add(Exam_Name);
                                }
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('No Exam Related to this Course');</script>");
                        }
                    }
                }
                catch
                {
                    Response.Write("<script>alert('something wrong while creasting dataset');</script>");
                }
                a1.CloseConnection();
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            SQl_Details a1 = new SQl_Details();
            a1.getConnection();



            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected)
                {
                    string Query_Exam_Id = "select Exam_Id from M_Exam where Exam_Name='" + li.ToString() + "'";
                    int Exam_Id = 0;
                    try
                    {
                        Exam_Id = Convert.ToInt32(a1.ExSc(Query_Exam_Id));
                    }
                    catch
                    {
                        Exam_Id = 0;
                    }
                    if (Exam_Id != 0)
                    {



                        string query_Insert_Student_Exam = "insert into X_Student_Exam(Exam_Id, Stu_Id, IsActive, IsEnable) values(" + Exam_Id + "," + Convert.ToInt32(Session["Stu_id"]) + ", " + 1 + ", " + 1 + ")";
                        a1.executeCMD(query_Insert_Student_Exam);



                        Response.Write("<script>alert('Successfully Applied For the Exam');</script>");



                    }
                }
            }
            Response.Redirect("ApplyForExam.aspx");
        }
    }

}
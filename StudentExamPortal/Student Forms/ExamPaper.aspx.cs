using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace StudentExamPortal
{
    public partial class ExamPaper : System.Web.UI.Page
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

                List<int> L = new List<int>();
                Session["i"] = 0;
                Session["Total_Correct_Ans"] = 0;
                Session["Total_Questions"] = 5;

                SQl_Details a1=new SQl_Details();
                a1.getConnection();
                


                // to get the total number of question which are assign to this subject by admin
                string query_total_Question = "select count(Que_Id) from X_Course_Que_Sub where Sub_Id = " + Convert.ToString(Session["Sub_Id"]) + "";
                int Max_Question_Count = Convert.ToInt32(a1.ExSc(query_total_Question));

                if (Max_Question_Count < Convert.ToInt32(Session["Total_Questions"]))
                {
                    Session["Total_Questions"] = Max_Question_Count;
                }

                while (L.Count < Convert.ToInt32(Session["Total_Questions"]))
                {
                    // to get the random que_Id 
                    string query_Get_Q_Id = "select top(1) Que_Id from X_Course_Que_Sub where Sub_Id = " + Convert.ToString(Session["Sub_Id"]) + " ORDER BY NEWID()";
                    int QId = Convert.ToInt32(a1.ExSc(query_Get_Q_Id));



                    if (!L.Contains(QId))
                    {
                        Response.Write("<script>alert(Q_Id);</script>");
                        L.Add(QId);
                    }
                }
                Session["List"] = L;




                //Question Loading
                if (L.Count > 0)
                {
                    SqlDataReader r = (SqlDataReader)a1.GetSqlDataReader("select * from M_Question where Que_Id=" + L.ElementAt(0));
                    r.Read();

                    RadioButton1.Checked = false;
                    RadioButton2.Checked = false;
                    RadioButton3.Checked = false;
                    RadioButton4.Checked = false;

                    Label1.Text = "Q. 1";
                    TextBox1.Text = r[1].ToString();
                    RadioButton1.Text = r[2].ToString();
                    RadioButton2.Text = r[3].ToString();
                    RadioButton3.Text = r[4].ToString();
                    RadioButton4.Text = r[5].ToString();
                    r.Close();
                }
                else
                {
                    Response.Write("<script>alert('No Questions to Display\n Contact Admin');</script>");
                }


                a1.CloseConnection();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int str = Convert.ToInt32(Session["Stu_id"]);

            int i = Convert.ToInt32(Session["i"]);
            int Total_Correct_Ans = Convert.ToInt32(Session["Total_Correct_Ans"]);
            int Total_Questions = Convert.ToInt32(Session["Total_Questions"]);
            var list = (List<int>)Session["List"];
            int Que_Id = list.ElementAt(i);

            SQl_Details a1=new SQl_Details();
            a1.getConnection();

            string getAns = "select Correct_Ans from M_question where Que_Id=" + Que_Id;
            string Correct_Ans = Convert.ToString(a1.ExSc(getAns));
            string Sel_Ans = "";

            if (RadioButton1.Checked == true)
            {
                Sel_Ans = "a";
            }
            else if (RadioButton2.Checked == true)
            {
                Sel_Ans = "b";
            }
            else if (RadioButton3.Checked == true)
            {
                Sel_Ans = "c";
            }
            else if (RadioButton4.Checked == true)
            {
                Sel_Ans = "d";
            }

            int Is_Correct_Or_Not = 0;

            if (Sel_Ans == Correct_Ans)
            {
                Total_Correct_Ans++;
                Is_Correct_Or_Not = 1;

            }

            // to insert entries in X_Student_Exam_Details 
            string query_Insert_XSED = "Insert into X_Student_Exam_Details(Stu_Id,Exam_Id,Sub_Id,Que_Id,Answer,Correct_Or_Not) values(" + Convert.ToInt32(Session["Stu_Id"]) + "," + Convert.ToInt32(Session["Exam_Id"]) + "," + Convert.ToInt32(Session["Sub_Id"]) + "," + Que_Id + ",'" + Sel_Ans + "'," + Is_Correct_Or_Not + ")";
            try
            {
                a1.executeCMD(query_Insert_XSED);
            }
            catch
            {
                Response.Write("<script>alert('something wrong while inserting in X_Student_Exam_Details');</script>");
            }
            i++;

            if (i < Total_Questions)
            {

                SqlDataReader r = (SqlDataReader)a1.GetSqlDataReader("select * from M_Question where Que_Id=" + list.ElementAt(i));
                r.Read();

                RadioButton1.Checked = false;
                RadioButton2.Checked = false;
                RadioButton3.Checked = false;
                RadioButton4.Checked = false;

                Label1.Text = "Q." + (i + 1).ToString();
                TextBox1.Text = r[1].ToString();
                RadioButton1.Text = r[2].ToString();
                RadioButton2.Text = r[3].ToString();
                RadioButton3.Text = r[4].ToString();
                RadioButton4.Text = r[5].ToString();
                r.Close();

            }
            else
            {
                String Result_Status = "Fail";
                if (Total_Correct_Ans >= (Total_Questions / 2))
                {
                    Result_Status = "Pass";
                }

                // to insert entries in X_Student_Exam_Header
                string query_Insert_XSEH = "Insert into X_Student_Exam_Header(Stu_Id,Exam_Id,Course_Id,Sub_Id,Out_Of_Marks,Obtain_Marks,Result_Status) values(" + Convert.ToInt32(Session["Stu_Id"]) + "," + Convert.ToInt32(Session["Exam_Id"]) + ", " + Convert.ToInt32(Session["Course_Id"]) + ", " + Convert.ToInt32(Session["Sub_Id"]) + ", " + Total_Questions + ", " + Total_Correct_Ans + ",'" + Result_Status + "')";
                a1.executeCMD(query_Insert_XSEH);

                Response.Write("<script>alert('Submit to End the Exam\n Redirecting to Home Page');</script>");

                int Login_Id = Convert.ToInt32(Session["Login_Id"]);
                //Session.Abandon();
                Session.Clear();
                Session["Login_Id"] = Login_Id;
                Session["Stu_id"]=str;
                Response.Redirect("AppearForExam.aspx");
            }

            Session["i"] = i;
            Session["Total_Correct_Ans"] = Total_Correct_Ans;

            a1.CloseConnection();
        }
    }
}
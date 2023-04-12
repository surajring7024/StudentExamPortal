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
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (HttpContext.Current.Session["Stu_Id"] == null)
            {
                Response.Redirect("../Membership Forms/Stu_Login.aspx");
            }

            SQl_Details a1 = new SQl_Details();
            if (!IsPostBack)
            {
                a1.getConnection();
                string query_Stu_Info = "select Exam_Name, Sub_Name, Out_Of_Marks, Obtain_Marks, Result_Status from M_Exam E inner join X_Student_Exam_Header X on E.Exam_Id=X.Exam_Id inner join M_Subject S on S.Sub_Id = X.Sub_Id  where X.Stu_Id = " + Convert.ToInt32(Session["Stu_Id"]) + "";
                

                SqlDataReader rdr = (SqlDataReader)a1.GetSqlDataReader(query_Stu_Info);
                GridView1.DataSource = rdr;
                GridView1.DataBind();
                a1.CloseConnection();

            }
        }
    }
}
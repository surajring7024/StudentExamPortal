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
    public partial class ViewTimeTable : System.Web.UI.Page
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
                BindData();
            }                 
            
        }
        public void BindData()
        {
            SQl_Details a1 = new SQl_Details();

            string stu_id = Session["Stu_id"].ToString();
           
            a1.getConnection();
           

            SqlDataAdapter da = (SqlDataAdapter)a1.GETSqlDataAdapter("select  mee.Exam_Name,s.Sub_Name, et.s_time,et.e_time from M_Subject s inner join Exam_Time_table et on s.Sub_Id = et.Sub_Id inner join M_Exam mee on mee.Exam_Id=et.Exam_Id inner join M_Student_Registration sss on sss.Course_Id = et.Course_Id where sss.stu_id =" + stu_id + "");
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            a1.CloseConnection();
        }
    }
}
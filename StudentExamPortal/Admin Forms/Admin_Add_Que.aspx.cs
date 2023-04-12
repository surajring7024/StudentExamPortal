using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentExamPortal
{
    public partial class Admin_Add_Que : System.Web.UI.Page
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
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            SQl_Details a1 = new SQl_Details();
            string path = ExcelPath.Text;
            string sheetname = ExcelSheet.Text;
            string myexceldataquery = "select Que_Id, Que_Text, Op1, Op2, Op3, Op4, Correct_Ans, Is_Active, Is_Enable from [" + sheetname + "$]";
            string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + path + ";extended properties=" + "\"excel 8.0;hdr=FALSE;\"";

            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Student_Final_Project;Integrated Security=True");

            try
            {
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                con.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
                bulkcopy.DestinationTableName = "M_Question";
                while (dr.Read())
                {
                    bulkcopy.WriteToServer(dr);
                }
                dr.Close();
                oledbconn.Close();
                Response.Redirect("../Admin Forms/Admin_Add_Que.aspx");
            }
            catch (Exception ee)
            {
                Response.Write("<script> alert('" + ee.Message + "'); </script>");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
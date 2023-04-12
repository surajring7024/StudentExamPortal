using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentExamPortal
{
    public partial class Admin_Add_Subject : System.Web.UI.Page
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

        protected void Submit_Click(object sender, EventArgs e)
        {

            string scode = Subject_code.Text;
            string sname = Subject_Name.Text;
            int active = Convert.ToInt32(isactive.Text);
            int enable = Convert.ToInt32(isenable.Text);

            SQl_Details a1 = new SQl_Details();
            string str = "select count(sub_code) from M_subject where sub_code='" + scode + "'";
            string str1 = "select count(sub_name) from M_subject where sub_name='" + sname + "'";
            int a, b;
            try
            {
                a1.getConnection();
                a = Convert.ToInt32(a1.ExSc(str));
            }
            catch
            {
                a = 0;
            }
            try
            {
                b = Convert.ToInt32(a1.ExSc(str1));
            }
            catch
            {
                b = 0;
            }
            finally
            {
                a1.CloseConnection();
            }

            if (a > 0 && b > 0)
            {
               
                string str2 = "update M_subject set sub_Code='" + scode + "',sub_name='" + sname + "',is_active=" + active + ",is_enable=" + enable + " where course_code='" + scode + "'";
                try
                {
                    a1.getConnection();
                    a1.executeCMD(str2);
                    Response.Write("<script> alert('Subject Updated Successfully'); </script>");
                }
                catch (Exception Ex)
                {
                    Response.Write("<script> alert('" + Ex.Message + "'); </script>");
                }
                finally
                {
                    a1.CloseConnection();
                }

                Response.Redirect("../Admin Forms/Admin_Add_Subject.aspx");
            }
            else
            {
                string str2 = "insert into M_Subject values('" + scode + "','" + sname + "'," + active + "," + enable + ")";
                try
                {
                    a1.getConnection();
                    a1.executeCMD(str2);
                    Response.Write("<script> alert('Subject Added Successfully'); </script>");
                }
                catch (Exception Ex)
                {
                    Response.Write("<script> alert('" + Ex.Message + "'); </script>");
                }
                finally
                {
                    a1.CloseConnection();
                }
                Response.Redirect("../Admin Forms/Admin_Add_Subject.aspx");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentExamPortal
{
    public partial class Student_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
             
            HttpContext.Current.Response.Cookies.Clear();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            DateTime date_time_now=DateTime.Now;
            string dateTime=date_time_now.ToString("yyyy-MM-dd HH:mm:ss");
            SQl_Details a1 = new SQl_Details();

            a1.getConnection();

            string get_LTID = "select top 1 LTId from login_transitions where login_id=(select login_id from m_login where stu_id=" + Convert.ToInt32(Session["Stu_id"]) + ") order by LTId desc";
            int LTID;
            try
            {
                LTID=Convert.ToInt32(a1.ExSc(get_LTID));
            }
            catch
            {
                LTID = 0;
            }
            string str = "update login_transitions set Login_TimeOut='"+dateTime+"' where LTid= "+LTID;

            try
            {
                a1.executeCMD(str);
            }
            catch
            {
                
            }
            finally
            {
                a1.CloseConnection();
            }

            Session.Clear();
            Session.Abandon();
            Session.SessionID.Remove(0);
            Response.Redirect("../Membership Forms/Stu_Login.aspx");
        }
    }
}
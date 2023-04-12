using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentExamPortal
{
    public partial class Admin_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) { }
            else {
                Response.Buffer = true;
                Response.CacheControl = "no-cache";
                Response.AddHeader("Pragma", "no-cache");
                Response.Expires = -1441;
                Session.Abandon();

                username.Text = "";
                password.Text = "";
            }
            
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            //login
            string user = username.Text;
            string pass= password.Text;
            SQl_Details a1 = new SQl_Details();

            

            string cmd1 = "select id from admin where ad_username= '" + user + "' and ad_password='" + pass + "'";
   
            int x = 0;
            try
            {
                a1.getConnection();
                x = Convert.ToInt32(a1.ExSc(cmd1));
            }

            catch
            {
                x = 0;
            }
            finally
            {

                a1.CloseConnection();
            }
            if (x != 0)
            {

                Response.Write("<script> alert('Login Success'); </script>");
                Session["login"] = user;
                Response.Redirect("../Admin Forms/Student_Registeration.aspx");
            }
            else
            {
                Response.Write("<script> alert('Username or pwd is incorrect'); </script>");
                Response.Redirect("../Membership Forms/Admin_Login.aspx");
            }
        }
    }
}
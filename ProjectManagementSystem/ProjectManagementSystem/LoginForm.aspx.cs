using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;

namespace ProjectManagementSystem
{
    public partial class LoginForm : System.Web.UI.Page
    {
       public bool wrongLogin = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;
            int exist = 0;
            int userID = 0;

            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select count(*) from Users where email=@email And password=@pass;", con))
                {
                    cmd.Parameters.AddWithValue("@email",email);
                    cmd.Parameters.AddWithValue("@pass", password);
                    exist = (int)cmd.ExecuteScalar();


                }
            }
            if (exist>0)
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select UserId, isAdmin from Users where email=@email And password=@pass;", con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pass", password);
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Session["userId"] = rdr["UserId"];
                            Session["isAdmin"] = rdr["isAdmin"];
                        }
                       // userID = (int)cmd.ExecuteScalar();
                        
                        Response.Redirect("Default.aspx"); 

                    }
                }
                
            }
            else
            {
                wrongLogin = true;
            }
           


           
        }

        [System.Web.Services.WebMethod]
        public static string logout(string id)
        {
            HttpContext.Current.Session["userId"] = null;
            HttpContext.Current.Session["isAdmin"] = null;
             
            return "";
        }
    }
}
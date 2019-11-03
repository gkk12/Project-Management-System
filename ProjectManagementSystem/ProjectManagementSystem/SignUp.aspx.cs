using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace ProjectManagementSystem
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }
        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            string designation = DesignationTextBox.Text;
            using (SqlConnection con = new SqlConnection (WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("insert into Users values(@name,@email,@password,0,0,@desig,@CreatedOn)",con))
                {
                    cmd.Parameters.AddWithValue("@name",name);
                    cmd.Parameters.AddWithValue("@email",email);
                    cmd.Parameters.AddWithValue("@password",password);
                    cmd.Parameters.AddWithValue("@desig", designation);
                    cmd.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
                    
                    int i = cmd.ExecuteNonQuery();
                }
                
            }
            Response.Redirect("AfterSignUp.aspx");

        }

    }
}
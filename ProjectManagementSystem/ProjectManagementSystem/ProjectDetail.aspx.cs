using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ProjectManagementSystem
{
    public partial class ProjectDetail : System.Web.UI.Page
    {
      public  List<Comment> Comments;
      public string str = "";
      public Project proj = new Project();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["Id"] != null)
                {
                    this.str = Request.QueryString["Id"];
                    // Response.Redirect("~/ShowForums.aspx");

                    proj.GetProjectByID(str);
                    this.Comments = Comment.GetApprovedCommentByID(str);
                }

            }
        }
        protected void Comment_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                this.str = Request.QueryString["Id"];
              
            }
            string cmnt = commentBox.InnerText;
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd  = new SqlCommand("insert into comments values(@userId, @commentText,0 ,@commentTime,@projId,0 )",con))
                {
                    cmd.Parameters.AddWithValue("@userId",Convert.ToInt16(Session["userId"]));
                    cmd.Parameters.AddWithValue("@commentText", cmnt);
                    cmd.Parameters.AddWithValue("@commentTime", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@projId", str);
                    int o = cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd  = new SqlCommand("Update  Project set reviews = ISNULL(reviews, 0) + 1 where Id="+str,con))
                {
                    int i = cmd.ExecuteNonQuery();
                }
                
            }
            Response.Redirect("AfterComment.aspx");
    
        
        }
    }
}
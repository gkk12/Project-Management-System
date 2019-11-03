using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Script.Serialization;
namespace ProjectManagementSystem
{
    /// <summary>
    /// Summary description for notifications
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class notifications : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetNotifications()
        {
            List<Comment> comments = new List<Comment>();
            try
            {

            
           
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select commentTime , title, name from comments inner join Project on comments.projectId=project.Id inner join Users on comments.userId=users.UserId where seen=0;", conn))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        comments.Add(new Comment {
                     //   commentText = sdr["commentText"].ToString(),
                        commentTime = sdr["CommentTime"].ToString(),
                        DevName = sdr["name"].ToString(),
                        title=sdr["title"].ToString()

                        });
                    }
                }
                
            }
            }
            catch //(Exception)
            {

             //   throw;
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(comments));

           /// return "Hello World";
        }

        [WebMethod]
        public void MarkRead()
        {
           // List<Comment> comments = new List<Comment>();
            try
            {



                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Update comments set seen=1;", conn))
                    {
                        int i=cmd.ExecuteNonQuery();
                    }

                }
            }
            catch //(Exception)
            {

                //   throw;
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize("success"));

            /// return "Hello World";
        }
    }
}

using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;

namespace ProjectManagementSystem
{
    public class Comment
    {
        public int Id { get; set; }
        public string DevName { get; set; }
        public string commentText { get; set; }
        public bool isApproved { get; set; }
        public string commentTime { get; set; }
        public string DevDesignation { get; set; }

        public string ApproveButton { get; set; }
        public string title { get; set; }
        public List<Comment> GetComment()
        {
            List<Comment> Comments = new List<Comment>();

            try
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select ID, Name, commentText ,isApproved , CommentTime from comments inner join Users On comments.userId=Users.UserId where isApproved=0 ;",con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Comments.Add(new Comment { 
                        Id=Convert.ToInt16(reader["ID"]),
                        DevName = reader["Name"].ToString(),
                        commentText = reader["commentText"].ToString(),
                        commentTime = Convert.ToDateTime(reader["CommentTime"]).ToString("MMM dd, yyyy"),//reader["CommentTime"].ToString()
                        ApproveButton = "<button class='form-control ' value=\"" + reader["ID"] .ToString()+ "\" onclick=\"myFunction(this)\"OnClick=\"Approve_Click\" type=\"button\">Approve</button>"
                        });
                    }

                }
            }

            }
            catch
            {
                
              //  throw;
            }
            return Comments;
           
        }


        public void ApproveComment(string Id){
            
            try
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("update comments set isApproved=1 where ID=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id",Id);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            }
            catch
            {
                
              //  throw;
            }
        }
        public static List<Comment> GetApprovedComment()
        {
            List<Comment> Comments = new List<Comment>();

            try
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Select ID, Name,Designation, commentText ,isApproved , CommentTime from comments inner join Users On comments.userId=Users.UserId where isApproved=1;", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Comments.Add(new Comment
                            {
                                Id = Convert.ToInt16(reader["ID"]),
                                DevName = reader["Name"].ToString(),
                                commentText = reader["commentText"].ToString(),
                                DevDesignation=reader["Designation"].ToString(),
                                commentTime = Convert.ToDateTime(reader["CommentTime"]).ToString("MMM dd, yyyy")//reader["CommentTime"].ToString()
                              
                            });
                        }

                    }
                }

            }
            catch
            {

                //  throw;
            }
            return Comments;

        }

        public static List<Comment> GetApprovedCommentByID(string Id)
        {
            List<Comment> Comments = new List<Comment>();

            try
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select commentText,CommentTime, Name ,Designation from  comments inner join Users on comments.userid=users.UserId where isApproved=1 AND projectId=" + Id, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Comments.Add(new Comment
                            {
                                
                                DevName = reader["Name"].ToString(),
                                commentText = reader["commentText"].ToString(),
                                DevDesignation = reader["Designation"].ToString(),
                                commentTime = Convert.ToDateTime(reader["CommentTime"]).ToString("MMM dd, yyyy")//reader["CommentTime"].ToString()

                            });
                        }

                    }
                }

            }
            catch
            {

                //  throw;
            }
            return Comments;

        }

        
        
    }
}
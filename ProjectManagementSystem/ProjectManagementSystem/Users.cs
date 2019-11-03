using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ProjectManagementSystem
{
    public class Users
    {
        public int Id { get; set; }
        public string DevName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string CreatedOn { get; set; }
        public string ApproveButton { get; set; }


        public static List<Users> GetAllPendingUsers()
        {
            List<Users> Users = new List<Users>();
            try
            {
                 using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd  = new SqlCommand("Select * from Users where isActive=0",conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Users.Add(new Users
                        {
                            Id = Convert.ToInt16(reader["UserId"]),
                            DevName=reader["Name"].ToString(),
                            Designation = reader["Designation"].ToString(),
                            CreatedOn = reader["CreatedOn"].ToString(),
                            ApproveButton = "<button class='form-control ' value=\"" + reader["UserId"].ToString() + "\" onclick=\"myFunction(this)\"OnClick=\"Approve_Click\" type=\"button\">Approve</button>"

                        });    
                    }

                    
                }
            }
            }
            catch (Exception)
            {
                
                //throw;
            }
            return Users;
        }


        public void ApproveUser( string Id)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd  = new  SqlCommand("update Users set isActive=1 where userId=@userId",conn))
                {
                    cmd.Parameters.AddWithValue("@userId", Id);
                    int i = cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
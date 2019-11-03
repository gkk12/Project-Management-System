using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ProjectManagementSystem
{
    public class Project
    {
        public int id { get; set; }
       
        public string deadline  { get; set; }
        public string title { get; set; }
        public string client { get; set; }
        public int projectTypeId { get; set; }
        public string projectType { get; set; }
        public string Description { get; set; }
        public string createdOn { get; set; }
        public string status { get; set; }
        public int reviews { get; set; }
        public int remaingDays { get; set; }
        public string markCompleteBtn { get; set; }
        public bool  isCompleted { get; set; }



        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            try
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Select project.Id, userId,title,DeadLine,Client,Description,CreatedOn, ProjectTypes.Project from Project inner join ProjectTypes On Project.ProjectTypeId=ProjectTypes.Id;", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            projects.Add(new Project { 
                            id=Convert.ToInt16(reader["Id"]),
                            title = reader["title"].ToString(),
                            deadline = reader["DeadLine"].ToString(),
                            client = reader["Client"].ToString(),
                            Description = reader["Description"].ToString(),
                            projectType = reader["Project"].ToString()

                            });
                        }
                    }

                }
            }
            catch (Exception)
            {

                // throw;
            }
            return projects;
        }
        public Project GetProjectByID(string Id)
        {
            Project proj = new Project();
            try
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Select Project.Id,title,DeadLine,Client,ProjectTypeId,Description,Project ,Status from Project inner join ProjectTypes On Project.ProjectTypeId=ProjectTypes.Id where Project.Id =" + Id, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                          
                              id = Convert.ToInt16(reader["Id"]);
                              title = reader["title"].ToString();
                               deadline = reader["DeadLine"].ToString();
                               client = reader["Client"].ToString();
                               Description = reader["Description"].ToString();
                               projectTypeId = Convert.ToInt16(reader["ProjectTypeId"]);//.ToString();
                               status = reader["Status"].ToString();
                               projectType = reader["project"].ToString();
                            
                           
                        }
                    }

                }
            }
            catch (Exception)
            {

                // throw;
            }
            return proj;
        }

        public void SaveProject(int useID) {

            try
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Insert into Project values(@userID,@title ,@deadline ,@client, @projectType,@Description, @createdOn,'In Progree',0,0);", con))
                    {
                        cmd.Parameters.AddWithValue("@userID", useID);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@deadline", deadline);
                        cmd.Parameters.AddWithValue("@client", client);
                        cmd.Parameters.AddWithValue("@projectType", projectTypeId);
                        cmd.Parameters.AddWithValue("@Description", Description);
                        cmd.Parameters.AddWithValue("@createdOn", createdOn);
                        int i = cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception)
            {
                
               // throw;
            }

        

        }

        public void updateProject()
        {

            try
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd  = new SqlCommand("update Project set title=@title ,DeadLine=@deadline, Client=@client, ProjectTypeId=@pid, Description=@desc where id=@id;",con))
                    {
                       // cmd.Parameters.AddWithValue("@userID", 2);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@deadline", deadline);
                        cmd.Parameters.AddWithValue("@client", client);
                        cmd.Parameters.AddWithValue("@pid", projectTypeId);
                        cmd.Parameters.AddWithValue("@desc", Description);
                        cmd.Parameters.AddWithValue("@id", id);
                        int i = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                
              //  throw;
            }

        }


        public static List<Project> GetprojectsSummmary()
        {
            List<Project> proj = new List<Project>();
            try
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Select id, title, description, CreatedOn, DeadLine,reviews , Status from Project", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            proj.Add(new Project {
                             id = Convert.ToInt16(reader["Id"]),
                            title = reader["title"].ToString(),
                            deadline = reader["DeadLine"].ToString(),
                           
                            Description = reader["Description"].ToString(),
                             createdOn = reader["CreatedOn"].ToString(),
                             reviews = Convert.ToInt16(reader["reviews"]),
                             remaingDays = (Convert.ToDateTime(reader["DeadLine"]) - DateTime.Now).Days,
                             status = reader["Status"].ToString(),
                            
                        
                        });
                           


                        }
                    }

                }
            }
            catch (Exception)
            {

                // throw;
            }
            return proj;
        }

    }
}
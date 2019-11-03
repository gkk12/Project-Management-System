using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ProjectManagementSystem
{
    public partial class Create : System.Web.UI.Page
    {
        bool isAdmin = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }

            isAdmin = Convert.ToBoolean(Session["isAdmin"]);
            if (!isAdmin)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                List<ProjectType> proj = ProjectType.GetAllTypes();
                DropDownListProjectTypes.DataValueField = "Id";
                DropDownListProjectTypes.DataTextField = "Name";
                DropDownListProjectTypes.DataSource = proj;
                DropDownListProjectTypes.DataBind();
            }
        
        }


        protected void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
               var aa= DropDownListProjectTypes.SelectedItem.Value;
                Project project = new Project
                {
                    title = projectTitle.Text,
                    deadline = projectDeadline.Text,
                    client = clientName.Text,
                    projectTypeId = Convert.ToInt16(aa),
                    Description = projectDescription.Text,
                    createdOn = DateTime.Now.ToString()
                };
                project.SaveProject(Convert.ToInt16(Session["userId"]));

            }
            catch (Exception)
            {

                // throw;
            }


            Response.Redirect("Default.aspx"); 
        }
    }

    public class ProjectType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<ProjectType> GetAllTypes()
        {
            List<ProjectType> proj = new List<ProjectType>();
            try
            {


            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from ProjectTypes",con))
                {
                    SqlDataReader rdr =cmd.ExecuteReader();
                   
                    while (rdr.Read())
                    {
                        proj.Add(new ProjectType { 
                        Id=Convert.ToInt16( rdr["Id"]),
                        Name=rdr["Project"].ToString()
                        });
                    }
                }
            }
            }
            catch
            {


            }
            return proj;



        }
    }
}
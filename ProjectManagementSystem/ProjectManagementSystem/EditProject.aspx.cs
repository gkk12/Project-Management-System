using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementSystem
{
    public partial class EditProject : System.Web.UI.Page
    {
        string str="-1";
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
                Response.Redirect("ProjectDetail.aspx");
            }
            if (!IsPostBack)
            {
                
            
            Project proj = new Project();
            if (Request.QueryString["Id"] != null)
            {
                this.str = Request.QueryString["Id"];
               // Response.Redirect("~/ShowForums.aspx");
                
                proj.GetProjectByID(str);
            }


            projectTitle.Text = proj.title;
            projectDeadline.Text = proj.deadline;
            clientName.Text = proj.client;
            projectType.Text = proj.projectTypeId.ToString();
            projectDescription.Text = proj.Description;

            }
        }
        protected void updateButton_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                this.str = Request.QueryString["Id"];
                // Response.Redirect("~/ShowForums.aspx");

                //proj.GetProjectByID(str);
            }

            Project proj = new Project();
            proj.id = Convert.ToInt16(str);
          proj.title   = projectTitle.Text;
          proj.deadline  = projectDeadline.Text ;
           proj.client  = clientName.Text;
            proj.projectTypeId= Convert.ToInt16(projectType.Text);
           proj.Description =  projectDescription.Text;
           proj.updateProject();
           Response.Redirect("Default.aspx");
        
        }

    }
}
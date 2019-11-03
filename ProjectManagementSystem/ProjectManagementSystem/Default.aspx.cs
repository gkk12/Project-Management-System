using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementSystem
{
    public partial class _Default : Page
    {
        public List<Project> projects;
        public bool isAdmin =false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"]==null)
            {
                Response.Redirect("LoginForm.aspx");
            }
            isAdmin =Convert.ToBoolean(Session["isAdmin"]);
            Project p = new Project();
            projects = p.GetAllProjects();


        }
    }
}
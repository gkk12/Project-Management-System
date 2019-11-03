using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace ProjectManagementSystem
{
    /// <summary>
    /// Summary description for ProjectSummary1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProjectSummary1 : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetProjectSummary()
        {
            List<Project> projects = Project.GetprojectsSummmary();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(projects));
           // return "Hello World";
        }
    }
}

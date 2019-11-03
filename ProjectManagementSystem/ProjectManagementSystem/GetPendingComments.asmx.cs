using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace ProjectManagementSystem
{
    /// <summary>
    /// Summary description for GetPendingComments
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class GetPendingComments : System.Web.Services.WebService
    {

        [WebMethod]
        public void PendingComments()
        {
            Comment comment = new Comment();
            List<Comment> Comments = new List<Comment>();
            Comments = comment.GetComment();
            if (Comments!=null)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Comments));    
            }
            
           // return "Hello World";
        }
    }
}

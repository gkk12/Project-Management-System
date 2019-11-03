using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace ProjectManagementSystem
{
    /// <summary>
    /// Summary description for Accounts
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Accounts : System.Web.Services.WebService
    {

        [WebMethod]
        public void PendingAccounts()
        {

            List<Users> user = Users.GetAllPendingUsers();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(user));

         //   return "Hello World";
        }
    }
}

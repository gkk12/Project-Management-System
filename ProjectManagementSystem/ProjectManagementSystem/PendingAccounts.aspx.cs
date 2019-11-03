using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementSystem
{
    public partial class PendingAccounts : System.Web.UI.Page
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
        }

        [System.Web.Services.WebMethod]
        public static string ApproveAccount(string Id)
        {
            Users user = new Users();
            user.ApproveUser(Id);

            return "Success";
        }


        [System.Web.Services.WebMethod]
        public static string GetPendingAccounts(string Id)
        {

            return "";
        }
    }
}
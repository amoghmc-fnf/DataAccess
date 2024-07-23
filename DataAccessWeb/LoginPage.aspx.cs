using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccessWeb
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            var username = loginCtrl.UserName;
            var password = loginCtrl.Password;
            var users = Application["users"] as Dictionary<string, string>;
            if (users.ContainsKey(username))
            {
                if (users[username] == password)
                {
                    FormsAuthentication.RedirectFromLoginPage(username, false);
                }
            }
        }
    }
}
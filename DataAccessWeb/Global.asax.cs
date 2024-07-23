using DataAccessWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace DataAccessWeb
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var path = Server.MapPath("~//Images");
            var data = ApplicationData.CreateProducts(path);
            Application["data"] = data;

            //For user authenication purpose.......
            var users = new Dictionary<string, string>();
            users.Add("admin", "apple@123");
            users.Add("user", "user@123");
            users.Add("tester", "tester@123");
            Application["users"] = users;
        }
     
        protected void Session_Start(object sender, EventArgs e)
        {
            Queue<Product> recentList = new Queue<Product>();
            Session.Add("recentList", recentList);
        }

    }
}
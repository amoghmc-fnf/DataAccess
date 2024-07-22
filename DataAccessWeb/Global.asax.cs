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
        }

    }
}
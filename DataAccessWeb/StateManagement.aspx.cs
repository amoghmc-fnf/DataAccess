using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccessWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ExtractUsingQueryString();
                ExtractUsingCookies();
            }
        }

        private void ExtractUsingCookies()
        {
            var cookie = Request.Cookies["RegisterInfo"];
            if (cookie == null)
            {
                lblDetails.Text = "This page is requested directly, so no input details are available";
            }
            else
            {
                var values = cookie.Values;
                var name = values["name"];
                var email = values["email"];
                var age = values["age"];
                var pwd = values["pwd"];
                var stringInput = $"Name: {name}<br/>Email: {email}<br/>Age: {age}<br/>Password: {pwd}<br/>";
                stringInput += "<b>COOKIES</b>";
                lblDetails.Text = stringInput;
            }
        }

        private void ExtractUsingQueryString()
        {
            if (Request.QueryString.Count == 0)
            {
                lblDetails.Text = "Invalid Request!";
            }
            else
            {
                var name = Request.QueryString["name"];
                var email = Request.QueryString["email"];
                var age = Request.QueryString["age"];
                var pwd = Request.QueryString["pwd"];
                var stringInput = $"Name: {name}<br/>Email: {email}<br/>Age: {age}<br/>Password: {pwd}<br/>";
                stringInput += "<b>QUERY STRING</b>";
                lblDetails.Text = stringInput;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccessWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtJob_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed7_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "Trainer" || args.Value == "Trainee")
                args.IsValid = true;
            else
                args.IsValid = false;
        }

        protected void Unnamed8_Click(object sender, EventArgs e)
        {
            //QueryStringExample();
            CookiesExample();

        }

        private void CookiesExample()
        {
            if (Page.IsValid)
            {
                HttpCookie cookie = new HttpCookie("RegisterInfo");
                cookie.Values.Add("name", txtName.Text);
                cookie.Values.Add("email", txtEmail.Text);
                cookie.Values.Add("age", txtAge.Text);
                cookie.Values.Add("pwd", txtPwd.Text);
                Response.Cookies.Add(cookie);
                Response.Redirect("StateManagement.aspx");
            }
        }

        private void QueryStringExample()
        {
            if (Page.IsValid)
            {
                string url = $"StateManagement.aspx?name={txtName.Text}&email={txtEmail.Text}&age={txtAge.Text}&pwd={txtPwd.Text}&";
                Response.Redirect(url);
            }
        }
    }
}
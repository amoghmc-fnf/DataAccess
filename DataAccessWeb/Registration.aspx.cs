using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccessWeb
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var users = Application["users"] as Dictionary<string, string>;
            if (users.ContainsKey(txtName.Text))
            {
                lblError.Text = "User is already registered, Please contact Admin!!!";
                return;
            }

            users.Add(txtName.Text, txtPwd.Text);
            lblError.Text = "User registered Successfully! Please visit HomePage to login";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccessWeb
{
    public partial class SessionState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                if (Session["Items"] == null)
                    Session.Add("Items", new List<string>());
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Session["Items"] == null)
            {
                lblError.Text = "No session info of the name Items is stored!";
                return;
            }
            var oldItems = Session["Items"] as List<string>;
            oldItems.Add(txtItem.Text);
            Session["Items"] = oldItems;
            lblError.Text = "Item added to the session";

            lstItems.DataSource = oldItems;
            lstItems.DataBind();
        }
    }
}
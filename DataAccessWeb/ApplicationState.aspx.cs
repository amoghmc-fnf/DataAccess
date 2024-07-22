using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccessWeb
{
    public partial class ApplicationState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                if (Application["Items"] == null)
                    Application.Add("Items", new List<string>());
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Application["Items"] != null)
            {
                var data = Application["Items"] as List<string>;
                data.Add(txtItem.Text);
                Application["Items"] = data;
                lstItems.DataSource = data;
                lstItems.DataBind();
            }
        }
    }
}
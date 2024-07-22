using DataAccessWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccessWeb
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstProducts.DataSource = Application["data"] as HashSet<Product>;
                lstProducts.DataTextField = "Name";
                lstProducts.DataValueField = "Id";
                lstProducts.DataBind();
            }
        }
    }
}
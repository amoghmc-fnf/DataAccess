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

        protected void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var product = findProduct(Convert.ToInt32(lstProducts.SelectedItem.Value));
            if (product == null)
            {
                lblError.Text = "No product found to display";
                return;
            }
            txtId.Text = product.Id.ToString();
            txtName.Text = product.Name.ToString();
            txtPrice.Text = product.Price.ToString();
            imgProduct.ImageUrl = product.Image;

            var recentList = Session["recentList"] as Queue<Product>;
            if (recentList.Count == 5)
            {
                recentList.Dequeue();
            }
            recentList.Enqueue(product);
            var list = recentList.Reverse();
            dtRecentList.DataSource = list;
            dtRecentList.DataBind();
        }

        private Product findProduct(int id)
        {
            var data = Application["data"] as HashSet<Product>;
            return data.FirstOrDefault(p => p.Id == id);
        }

    }
}
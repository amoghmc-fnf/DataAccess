using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccessWeb
{
    public partial class FirstPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lstItems.Items.Add(txtItem.Text);
            txtItem.Text = "";
        }

        protected void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelected.Text = $"The selected item is {lstItems.SelectedItem.Text}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccessWeb
{
    public partial class CalcPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            var item1 = int.Parse(txtItem1.Text);
            var item2 = int.Parse(txtItem2.Text);
            const string result = "Result is: ";
            switch(lstItems.SelectedItem.Text)
            {
                case "Add":
                    lblSelected.Text = result + (item1 + item2).ToString();
                    break;
                case "Subtract":
                    lblSelected.Text = result + (item1 - item2).ToString();
                    break;
                case "Multiply":
                    lblSelected.Text = result + (item1 * item2).ToString();
                    break;
                case "Divide":
                    lblSelected.Text = result + (item1 / item2).ToString();
                    break;
            }
        }
    }
}
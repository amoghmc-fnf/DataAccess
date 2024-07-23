using DataAccessWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccessWeb
{
    public partial class Repeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var com = new EmployeeDb();
                rpEmployees.DataSource = com.GetAllEmployees();
                rpEmployees.DataBind();
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int empId = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect($"EditEmployee.aspx?empId={empId}");
        }


        protected void Delete_Click(object sender, EventArgs e)
        {

        }
    }
}
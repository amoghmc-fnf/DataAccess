using DataAccessWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccessWeb
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var empId = int.Parse(Request.QueryString["empId"]);
                var records = new EmployeeDb().GetAllEmployees();
                var rec = records.FirstOrDefault(emp => emp.EmpId == empId);
                if (rec == null)
                {
                    throw new Exception($"Error! Employee with ID {empId} not found!");
                }
                txtId.Text = rec.EmpId.ToString();
                txtName.Text = rec.EmpName;
                txtAddress.Text = rec.EmpAddress;
                txtSalary.Text = rec.EmpSalary.ToString();
                txtDept.Text = rec.DeptId.ToString();
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            try
            {
                emp.EmpId = Convert.ToInt32(txtId.Text);
                emp.EmpName = txtName.Text;
                emp.EmpAddress = txtAddress.Text;
                emp.EmpSalary = Convert.ToInt32(txtSalary.Text);
                emp.DeptId = Convert.ToInt32(txtDept.Text);
                new EmployeeDb().UpdateEmployee(emp);
                lblError.Text = "Employee updated successfully!";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Repeater.aspx");
        }
    }
}
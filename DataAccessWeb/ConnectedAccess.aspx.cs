using DataAccessWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccessWeb
{
    public partial class ConnectedAccess : System.Web.UI.Page
    {
        static IDataComponent component = new ConnectedComponent();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = string.Empty;
                GetAllStudentsFeature();
            }
        }

        private void GetAllStudentsFeature()
        {
            var students = component.GetAllStudents();
            lstStudents.DataSource = students;
            lstStudents.DataTextField = "StudentName";
            lstStudents.DataValueField = "StudentId";
            lstStudents.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //create the student object with inputs from the user 
            var student = new Student();
            student.StudentName = txtName.Text;
            student.StudentEmail = txtEmail.Text;
            student.StudentPhone = Convert.ToInt64(txtPhone.Text);
            //Call the API to insert the record

            try
            {
                component.AddNewStudent(student);
                lblError.Text = "Student added successfully to the database";
                GetAllStudentsFeature();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                component.DeleteStudent(Convert.ToInt32(txtId.Text));
                lblError.Text = "Student deleted successfully from the database";
                GetAllStudentsFeature();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var student = new Student();
            student.StudentId = Convert.ToInt32(txtId.Text);
            student.StudentName = txtName.Text;
            student.StudentEmail = txtEmail.Text;
            student.StudentPhone = Convert.ToInt64(txtPhone.Text);

            try
            {
                component.UpdateStudent(student);
                lblError.Text = "Student updated successfully to the database";
                GetAllStudentsFeature();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                var selected = int.Parse(lstStudents.SelectedItem.Value);
                var records = component.GetAllStudents();
                var selectedStudent = records.FirstOrDefault(s => s.StudentId == selected);
                if (selectedStudent != null)
                {
                    txtId.Text = selectedStudent.StudentId.ToString();
                    txtName.Text = selectedStudent.StudentName;
                    txtEmail.Text = selectedStudent.StudentEmail;
                    txtPhone.Text = selectedStudent.StudentPhone.ToString();
                }
                else
                {
                    lblError.Text = "Student details not found!!!";
                }
            }
            catch (Exception ex)
            {
                lblError.Text += ex.Message;
            }
        }

        protected void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
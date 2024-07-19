using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccessWeb.Models
{
    public class DisconnectedComponent : IDataComponent
    {
        private readonly string _connString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        private const string SELECTSTATEMENT = "SELECT * FROM STUDENTTABLE";

        private SqlDataAdapter adapter;
        private DataSet dataSet;

        public DisconnectedComponent()
        {
            adapter = new SqlDataAdapter(SELECTSTATEMENT, _connString);
            dataSet = new DataSet("myTables");
            adapter.Fill(dataSet, "StudentTable");
        }
        public void AddNewStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
        {
            //Create a new List object of the type Student....
            List<Student> students = new List<Student>();
            //Iterate thro the Rows of the Table in the dataset
            foreach (DataRow row in dataSet.Tables["StudentTable"].Rows)
            {
                //For each row, create a Student object and fill the data into it. 
                Student student = new Student();
                student.StudentId = Convert.ToInt32(row[0]);
                student.StudentName = row[1].ToString();
                student.StudentEmail = row[2].ToString();
                student.StudentPhone = (long)row[3];
                //Add the Student to the list
                students.Add(student);
            }
            //Return the List.
            return students;
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
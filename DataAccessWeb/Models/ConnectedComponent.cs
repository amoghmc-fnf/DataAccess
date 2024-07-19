using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataAccessWeb.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public long StudentPhone { get; set; }
    }

    public interface IDataComponent
    {
        List<Student> GetAllStudents();
        void AddNewStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int studentId);
    }

    public class ConnectedComponent : IDataComponent
    {
        #region CONSTANTS
        private const string STRCONNECTION = "Data Source=FNFIDVPRE20529\\SQLSERVER;Initial Catalog=FnfTraining;Integrated Security=True;Encrypt=False";
        private const string STRSELECT = "SELECT StudentName FROM STUDENTTABLE";
        private const string STRSELECTALL = "SELECT * FROM STUDENTTABLE";
        private const string STRADD = "INSERT INTO STUDENTTABLE VALUES(@name, @email, @phone)";
        private const string STRUPDATE = "UPDATE STUDENTTABLE SET StudentName = @name, StudentEmail= @email, ContactNo = @phone WHERE StudentId = @id";

        private const string STRDELETE = "DELETE FROM STUDENTTABLE WHERE StudentId = @id";
        #endregion

        #region Implementation
        public void AddNewStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(STRCONNECTION))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(STRADD, conn);
                    conn.Open();


                    cmd.Parameters.AddWithValue("@name", student.StudentName);
                    cmd.Parameters.AddWithValue("@email", student.StudentEmail);
                    cmd.Parameters.AddWithValue("@phone", student.StudentPhone);

                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error while adding student!", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (var conn = new SqlConnection(STRCONNECTION))
            {
                try
                {
                    var cmd = new SqlCommand(STRDELETE, conn);
                    conn.Open();

                    //Add the parameters for the delete query
                    cmd.Parameters.AddWithValue("@id", studentId);
                    var rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected != 1)
                    {
                        throw new Exception($"Student with the Id {studentId} does not exist to delete");
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error in Deleting Student", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<string> GetAllStudents()
        {
            SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = sqlCon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = STRSELECT;
            try
            {
                sqlCon.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                List<string> students = new List<string>();
                if (!dr.HasRows)
                {
                    throw new Exception("No Student data is available");
                }
                while (dr.Read())
                {
                    students.Add(dr["StudentName"].ToString());
                }
                return students;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(STRCONNECTION))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(STRUPDATE, conn);
                    conn.Open();


                    cmd.Parameters.AddWithValue("@id", student.StudentId);
                    cmd.Parameters.AddWithValue("@name", student.StudentName);
                    cmd.Parameters.AddWithValue("@email", student.StudentEmail);
                    cmd.Parameters.AddWithValue("@phone", student.StudentPhone);

                    var rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected != 1)
                    {
                        throw new Exception($"Student with the Id {student.StudentId} does not exist to update");
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error while updating student!", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        List<Student> IDataComponent.GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(STRCONNECTION))
            {
                SqlCommand cmd = new SqlCommand(STRSELECTALL, conn);
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //create student object for each row
                    Student student = new Student();
                    //fill the properties with the column values
                    student.StudentId = Convert.ToInt32(reader[0]);
                    student.StudentName = reader[1].ToString();
                    student.StudentEmail = reader[2].ToString();
                    student.StudentPhone = Convert.ToInt64(reader[3]);
                    //add the student to the collection
                    students.Add(student);
                }
                conn.Close();
            }
            return students;
        }
        #endregion
    }
}
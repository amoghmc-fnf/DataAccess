using DataAccessRecap.Data;
using DataAccessRecap.Models;

namespace DataAccessRecap.Services;

public interface IDataService
{
    void AddNewStudent(Student student);
    List<Student> GetAllStudents();
    void UpdateStudent(Student student);
    void DeleteStudent(int studentId);
}

public class StudentDataService : IDataService
{
    private readonly StudentDbContext _context;

    public StudentDataService(StudentDbContext context)
    {
        if (context == null) throw new ArgumentNullException("context cannot be null");
        _context = context;
    }

    public void AddNewStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public void DeleteStudent(int studentId)
    {
        var rec = _context.Students.ToList().FirstOrDefault(s => s.StudentId == studentId);

        if (rec == null)
            throw new Exception("Student not found to delete");

        _context.Remove(rec);
        _context.SaveChanges();
    }

    public List<Student> GetAllStudents()
    {
        return _context.Students.ToList();
    }

    public void UpdateStudent(Student student)
    {
        var rec = _context.Students.ToList().FirstOrDefault(s => s.StudentId == student.StudentId);

        if (rec == null)
            throw new Exception("Student not found to update");

        rec.StudentName = student.StudentName;
        rec.StudentEmail = student.StudentEmail;
        rec.ContactNo = student.ContactNo;

        _context.SaveChanges();
    }
}
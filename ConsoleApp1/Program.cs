
using DataAccessRecap.Data;
using DataAccessRecap.Models;
using DataAccessRecap.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    internal class Program
    {
        static IDataService service;
        private static ServiceProvider CreateServices()
        {
            var services = new ServiceCollection()
                .AddDbContext<StudentDbContext>()
                .AddSingleton<IDataService, StudentDataService>()
                .BuildServiceProvider();
            return services;
        }
        static void Main(string[] args)
        {
            var services = CreateServices();
            service = services.GetRequiredService<IDataService>();

            //testUpdatingFeature();
            testDeletingFeature();
            testReadingFeature();
            //testAddingFeature();
        }

        private static void testDeletingFeature()
        {
            service.DeleteStudent(1);
        }

        private static void testUpdatingFeature()
        {
            var student = new Student
            {
                ContactNo = 9889933333,
                StudentName = "Phani Raj B N",
                StudentEmail = "phanibn@gmail.com",
                StudentId = 1
            };
            service.UpdateStudent(student);

        }

        private static void testReadingFeature()
        {
            var records = service.GetAllStudents();
            foreach (var record in records)
            {
                Console.WriteLine(record);
            }
        }

        private static void testAddingFeature()
        {

            var rec = new Student
            {
                StudentEmail = "Amogh",
                StudentName = "amc@gmail.com",
                ContactNo = 8923928425
            };

            service.AddNewStudent(rec);
        }
    }
}

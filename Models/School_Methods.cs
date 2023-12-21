using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

namespace Labb3_Entity.Models
{
    public class School_Methods
    {

        SchoolContext DB = new SchoolContext();

       
        

        private string connectionString { get; set; }

        // Hämta alla anställda från databasen
        public void ShowAllEmployees()
        {

            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=true";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select (FirstName + ' ' + LastName) as FullName from Employee", connection);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}", reader["FullName"]);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ShowOnlyTeachers()
        {

            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=true";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select (FirstName+ ' '+ LastName) as Teacher from Employee WHERE FK_TitelID = '1'; ", connection);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}", reader["Teacher"]);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void ShowOnlyAdmin()
        {

            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=true";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select (FirstName+ ' '+ LastName) as Adminstration from Employee WHERE FK_TitelID = '2';", connection);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}", reader["Adminstration"]);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ShowOnlyPrincipal()
        {

            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=true";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select (FirstName+ ' '+ LastName) as Principal from Employee WHERE FK_TitelID = '3'; ", connection);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}", reader["Principal"]);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ShowStudentsFirstName()
        {

            var sorted = DB.Students.OrderBy(e => e.FirstName);

            foreach (var student in sorted)
            {
                Console.WriteLine(student.FirstName + ", " + student.LastName);
            }
        }


        public void ShowStudentsLastName()
        {

            var sorted = DB.Students.OrderBy(e => e.LastName);

            foreach (var student in sorted)
            {
                Console.WriteLine(student.LastName + ", " + student.FirstName);
            }
        }

        public void ShowStudentsFirstNameDescending()
        {

            var sorted = DB.Students.OrderByDescending
                (e => e.FirstName);

            foreach (var student in sorted)
            {
                Console.WriteLine(student.FirstName + ", " + student.LastName);
            }
        }

        public void ShowStudentsLastNameDescending()
        {

            var sorted = DB.Students.OrderByDescending
                (e => e.LastName);

            foreach (var student in sorted)
            {
                Console.WriteLine(student.LastName + ", " + student.FirstName);
            }
        }

        public void ShowAllClasses()
        {
            var sorted = DB.Classes.OrderBy(e => e.ClassName);
            foreach (var classs in sorted)
            {
                Console.WriteLine(classs.ClassName);
            }
        }


        public void ShowClassNet23()
        {

            
                var schoolObject = from s in DB.Students
                                   from sk in DB.StudentClasses
                                   where s.StudentId == sk.FkStudentId
                                   where sk.FkClassId == 1
                                   select new
                                   {
                                       FirstName = s.FirstName,
                                       LastName = s.LastName,


                                   };

                foreach (var item in schoolObject)
                {
                    Console.WriteLine($" {item.FirstName}  {item.LastName}");
                }
            

        }

        public void ShowClassNet24()
        {

            using (var db = new SchoolContext())
            {
                var schoolObject = from s in db.Students
                                   from sk in db.StudentClasses
                                   where s.StudentId == sk.FkStudentId
                                   where sk.FkClassId == 2
                                   select new
                                   {
                                       FirstName = s.FirstName,
                                       LastName = s.LastName,


                                   };

                foreach (var item in schoolObject)
                {
                    Console.WriteLine($" {item.FirstName}  {item.LastName}");
                }
            }


        }

        public void ShowClassNet25()
        {

            using (var db = new SchoolContext())
            {
                var schoolObject = from s in db.Students
                                   from sk in db.StudentClasses
                                   where s.StudentId == sk.FkStudentId
                                   where sk.FkClassId == 3
                                   select new
                                   {
                                       FirstName = s.FirstName,
                                       LastName = s.LastName,


                                   };

                foreach (var item in schoolObject)
                {
                    Console.WriteLine($" {item.FirstName}  {item.LastName}");
                }
            }
        }


        public void LatestGrades()
        {
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=true";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select student.Firstname, student.LastName, grade.GradeDate, grade.GradeInfo,CourseName, Employee.FirstName, Employee.LastName from Grade join Student on Grade.FK_StudentID = Student.StudentID join Course on Grade.FK_CourseID = Course.CourseID join Employee on Employee.EmployeeID = Course.FK_Employee where GradeDate >= DATEADD(MONTH, -1, GETDATE()) AND GradeDate <= GETDATE() Order BY GradeDate", connection);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(" Student:{0} {1} ,CourseName:{2}, GradeInfo: {3}, Date: {4}",reader["FirstName"], reader["LastName"], reader ["CourseName"] ,
                                reader["GradeInfo"], reader["GradeDate"]);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

               
            }

        }

        public void AverageGrades()
        {
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=true";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select Course.CourseName,avg(convert(Float,Gradeinfo)) as Average,max(convert(Float,Gradeinfo)) as Maxium,min(convert(Float,Gradeinfo)) as Minimum from Grade join Course on Course.CourseID = Grade.FK_CourseID\r\nGroup by course.CourseName", connection);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("CourseName:{0}, Average:{1}, Maxium:{2}, Minimum: {3} ", reader["CourseName"], reader["Average"], reader["Maxium"], reader["Minimum"]);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }


        }


        public void AddStudent()
        {

            Console.WriteLine("Ange förnamn:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Ange efternamn:");
            string lastName = Console.ReadLine();


            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName

            };

            Console.WriteLine($"Nu har du lagt {firstName} {lastName} som ny student ");

            DB.Students.Add(student);
            DB.SaveChanges();


        }

        public void AddEmployee()
        {
            Console.WriteLine("Skriv förnamn");
            string firstName = Console.ReadLine();
            Console.WriteLine("Skriv efternamn");
            string lastName = Console.ReadLine();

            var Employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName
            };

            Console.WriteLine($"Nu har du lagt {firstName} {lastName} som ny anställd");
            DB.Employees.Add(Employee);
            DB.SaveChanges();

            
        }
    }
}




    

    
    
   



    


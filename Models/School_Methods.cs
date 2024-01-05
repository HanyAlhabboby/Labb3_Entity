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
using System.Security;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

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
                    SqlCommand command = new SqlCommand("Select (FirstName + ' ' + LastName) as FullName, titel, WorkingDate, Salary from Employee join Titel on Titel.TitelID = Employee.FK_TitelID", connection);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("FullName: {0}, WorkingDate:{1}, Titel:{2}, Salary:{3}", reader["FullName"], reader["WorkingDate"], reader["Titel"], reader["Salary"]);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        //Hämtar alla lärare
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

        //Visar enbart adminstör
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

        //Visar enbart rektorn
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

        //Visar alla studenter med sortering av deras förr namnet
        public void ShowStudentsFirstName()
        {

            var sorted = DB.Students.OrderBy(e => e.FirstName);

            foreach (var student in sorted)
            {
                Console.WriteLine(student.FirstName + ", " + student.LastName);
            }
        }

        //Visar alla student med sortering av deras efternamn
        public void ShowStudentsLastName()
        {

            var sorted = DB.Students.OrderBy(e => e.LastName);

            foreach (var student in sorted)
            {
                Console.WriteLine(student.LastName + ", " + student.FirstName);
            }
        }

        //Visar alla studenter förr namn alfabet ordning
        public void ShowStudentsFirstNameDescending()
        {

            var sorted = DB.Students.OrderByDescending
                (e => e.FirstName);

            foreach (var student in sorted)
            {
                Console.WriteLine(student.FirstName + ", " + student.LastName);
            }
        }

        //Visar alla studenter efternamn alfabet ordning
        public void ShowStudentsLastNameDescending()
        {

            var sorted = DB.Students.OrderByDescending
                (e => e.LastName);

            foreach (var student in sorted)
            {
                Console.WriteLine(student.LastName + ", " + student.FirstName);
            }
        }


        //Visar alla klasser
        public void ShowAllClasses()
        {
            var sorted = DB.Classes.OrderBy(e => e.ClassName);
            foreach (var classs in sorted)
            {
                Console.WriteLine(classs.ClassName);
            }
        }

        //Visar klass NET23
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
        //Visar klass NET24
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
        //Visar klass NET25
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

        //Visar senaste betygen
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

        //Visar average betygen per kurs
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

        //Lägger till ny student i en class 
        public void AddStudent()
        {

            Console.WriteLine("Ange förnamn:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Ange efternamn:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Ange Personnummer, 10 siffror!");
            string personalNumber = Console.ReadLine();
            Console.WriteLine("Vilken klass ska studenten gå på?");
            Console.WriteLine("1. NET23, 2. NET24, 3. NET25");
            int input = int.Parse(Console.ReadLine());
            //lägg till fel hantering (begränsa mellan 1-3 if sats)
            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                PersonalNumber = personalNumber
            };

            DB.Add(student);
            DB.SaveChanges();

            var studentClass = new StudentClass
            {
                FkStudentId = student.StudentId,
                FkClassId = input
            };

            DB.Add(studentClass);
            DB.SaveChanges();

            Console.WriteLine($"Nu har du lagt {firstName} {lastName} som ny student med personnummer:{personalNumber} ");
           
        }

        //lägger till en anställd
        public void AddEmployee()
        {

            Console.WriteLine("Skriv förnamn");
            string firstName = Console.ReadLine();
            Console.WriteLine("Skriv efternamn");
            string lastName = Console.ReadLine();
            Console.WriteLine("Befattning:");
            Console.WriteLine("1.Lärare, 2.Adminstör, 3.Rektorn");
            int input = int.Parse(Console.ReadLine());

            DateTime today = DateTime.Today;
            
            var Employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                WorkingDate = today,
                FkTitelId = input
               

            };

            Console.WriteLine($"Nu har du lagt {firstName} {lastName} med dagens datum {today} som ny anställd");
            DB.Employees.Add(Employee);
            DB.SaveChanges();

        }

        public void AddGrade() //adda betyg
        {
            Console.WriteLine("Skriv in ID på vilken student som ska få betyget: ");
            var students = DB.Students.ToList();
            foreach (var item in students)
            {
                Console.WriteLine(item.StudentId + " " + item.FirstName + " " + item.LastName);
            }

            int studentChoice = int.Parse(Console.ReadLine()); //användarensVal

            var student = DB.Students.FirstOrDefault(s => s.StudentId == studentChoice);

            //Visar lärare och deras ID
            Console.WriteLine("Skriv in ID på vilken lärare som ska sätta betyget: ");
            var teachers = DB.Employees.Where(e => e.FkTitelId == 1).ToList();
            foreach (var item in teachers)
            {
                Console.WriteLine(item.EmployeeId + " " + item.FirstName + " " + item.LastName);
            }

            int teacherChoice = int.Parse(Console.ReadLine());
            var teacher = DB.Courses.FirstOrDefault(c => c.FkEmployee == teacherChoice);

            //Visar Kurserna och deras ID
            Console.WriteLine("Skriv in ID på kursen ");
            var courses = DB.Courses.ToList();
            foreach (var item in courses)
            {
                Console.WriteLine(item.CourseId + " " + item.CourseName);
            }

            int courseChoice = int.Parse(Console.ReadLine());
            var course = DB.Courses.FirstOrDefault(c => c.CourseId == courseChoice);

            Console.WriteLine("Skriv ner betyget du vill lägga  (mellan 0-100)");
            string gradeInput = Console.ReadLine();

            DateTime today = DateTime.Today;

            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    var grade = new Grade
                    {
                        FkStudentId = studentChoice,
                        FkCourseId = courseChoice,
                        GradeDate = today,
                        GradeInfo = gradeInput
                    };

                    DB.Grades.Add(grade);
                    DB.SaveChanges();

                    transaction.Commit();
                    Console.WriteLine("Transaktion lyckades och betygt har lagts till");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Transaktion misslyckades");
                }
            }
        }

        //Räknar hur många lärare som finns i systemet
        public void CountTeachers()
        {
            var Teachers = DB.Employees
        .Where(e => e.FkTitelId == 1)
        .Count();

            Console.WriteLine("Antal lärare som finns just nu: {0}", Teachers);
        }

        //Visar average lönen för lärare
        public void TeacherAverageSalary()
        {

            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=true";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select avg(Salary) as TeacherAverage from Employee where FK_TitelID = '1'", connection);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Teachers Average Salary:{0} ", reader["TeacherAverage"]);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        // Visar average lönen för admin
        public void AdminAverageSalary()
        {
            
                connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=true";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("Select avg(Salary) as AdminstationAverage from Employee where FK_TitelID = '2'", connection);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("Adminstration Average Salary:{0} ", reader["AdminstationAverage"]);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }

            
        } 

        //Visar average lönen för rektorn
        public void PrincipalAverageSalary()
        {
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=true";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select avg(Salary) as PrincipalAverage from Employee where FK_TitelID = '3'", connection);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Principal Average Salary:{0} ", reader["PrincipalAverage"]);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }

        // Visar alla studenter med hjälp av Stored Procedure
        public void ShowStudentSP()
        {
            var students = DB.Students.ToList();
            foreach (var item in students)
            {
                Console.WriteLine(item.StudentId);
            }

            Console.WriteLine("Skriv in studentId på den student du vill hämta information om: ");
            int userInput = int.Parse(Console.ReadLine());

            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=true";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetStudentInfo", connection);

                    command.Parameters.Add(new SqlParameter("@StudentID", userInput));
                    command.CommandType = CommandType.StoredProcedure;


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("FirstName:{0}, LastName:{1}, PersonalNumber:{2} ", 
                                reader["FirstName"], reader["LastName"], reader["PersonalNumber"]);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }

        }


    
    }




}




    

    
    
   



    


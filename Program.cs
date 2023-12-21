using Labb3_Entity.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Labb3_Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            School_Methods schoolContext = new School_Methods();
           

            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Visa alla anställda");
            Console.WriteLine("2. Visa anställda inom en kategori");
            Console.WriteLine("3. Visa alla elever");
            Console.WriteLine("4. Visa alla klasser som finns");
            Console.WriteLine("5. Visa alla betyg som eleverna har fått senaste månad");
            Console.WriteLine("6. Visa alla kurser med snittbetyg, lägst samt högst betyg ");
            Console.WriteLine("7. Lägg till elever");
            Console.WriteLine("8. Lägg till personal");
            Console.WriteLine("9. Avsluta programmet");

            while (true)
            {

                int.TryParse(Console.ReadLine(), out int choice);
                






                switch (choice)
            {
                case 1:
                        schoolContext.ShowAllEmployees();
                        
                        


                        break;
                case 2:

                    // Hämta anställda inom den angivna kategorin från databasen

                    


                    Console.WriteLine("Ange kategori:");
                    Console.WriteLine("1. Lärare" + " 2. Adminstör" + " 3. Rektor");
                    string kategori = Console.ReadLine();

                    if (kategori == "1")
                    {
                        
                        schoolContext.ShowOnlyTeachers();
                            

                    }

                    else if (kategori == "2")
                    {

                        schoolContext.ShowOnlyAdmin();
                            
                    }

                    else if (kategori == "3")
                    {

                        schoolContext.ShowOnlyPrincipal();
                            
                    }
                    break;


                case 3:
                    Console.WriteLine("Ange hur de ska vara sorterade:");
                    Console.WriteLine("1. Förnamn" + " 2. Efternamn");
                    
                    string sorting = Console.ReadLine();

                    if (sorting == "1")
                    {
                        schoolContext.ShowStudentsFirstName();

                        Console.WriteLine("------------------------------------------------");

                        Console.WriteLine("tryck 1 om du vill ha fallande sortering");
                        string answer = Console.ReadLine();
                        if (answer == "1")
                        {
                            schoolContext.ShowStudentsFirstNameDescending();
                        }
                    }

                    else if (sorting == "2")
                    {
                        schoolContext.ShowStudentsLastName();
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("tryck 1 om du vill ha fallande sortering");
                        string answer = Console.ReadLine();
                        if (answer == "1")
                        {
                            schoolContext.ShowStudentsLastNameDescending();
                        }
                    }
                    break;

                case 4:
                    schoolContext.ShowAllClasses();
                    Console.WriteLine("Välj klass vill du se vilka elever går på?");
                    Console.WriteLine("1.NET23  2.NET24  3.NET25");
                    string answer1 = Console.ReadLine();
                    if (answer1 == "1")
                    {
                        schoolContext.ShowClassNet23();
                    }
                    else if (answer1 == "2")
                    {
                        schoolContext.ShowClassNet24();

                    }

                    else if (answer1 == "3")
                    {
                        schoolContext.ShowClassNet25();
                    }

                    break;

                case 5:
                    schoolContext.LatestGrades();
                    break;

                case 6:
                        schoolContext.AverageGrades();
                        break;

                    case 7:
                        schoolContext.AddStudent();
                        break;
                    case 8:
                        schoolContext.AddEmployee();
                        break;
                    case 9:
                        Console.WriteLine("Tack och hej");
                        return;
                    default:




                        Console.WriteLine("Ogiltigt val, testa igen");
                    break;
            }

            }


        }
    }
}
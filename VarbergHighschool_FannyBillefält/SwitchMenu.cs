using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarbergHighschool_FannyBillefält.Models;

namespace VarbergHighschool_FannyBillefält
{
    internal class SwitchMenu
    {
        internal void WelcomeMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                UI.PrintedWelcomeMenu();
                string? input = Console.ReadLine();
                Console.Clear();

                DbManager dbManager = new DbManager();

                switch (input)
                {
                    case "1":
                        StaffMenu();
                        break;
                    case "2":
                        StudentMenu();
                        break;
                    case "3":
                        EconomyMenu();
                        break;
                    case "4":
                        dbManager.AllCourses();
                        UI.ReturnToPreviousMenu();
                        break;
                    case "5":
                        Console.WriteLine("Hej då! Tack för denna gången.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        Console.WriteLine("\nTryck Enter för att fortsätta...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }


            }
        }

        internal void StaffMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                UI.Printed_StaffMenu();
                string? input = Console.ReadLine();
                Console.Clear();

                DbManager dbManager = new DbManager();

                switch (input)
                {
                    case "1":
                        dbManager.TeachersPerDepartment();
                        UI.ReturnToPreviousMenu();
                        break;
                    case "2":
                        DbManager.OverviewAllStaff();
                        UI.ReturnToPreviousMenu();
                        break;
                    case "3":
                        SaveInfoAddStaff();
                        UI.ReturnToPreviousMenu();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        Console.WriteLine("\nTryck Enter för att fortsätta...");//vill att detta ska försvinna efter jag tryckt enter.
                        Console.ReadLine();
                        break;
                }
            }
        }

        internal void StudentMenu()
        {
            bool keepRunning = true;
            DbManager dbManager = new DbManager();
          
            while (keepRunning)
            {
                UI.Printed_StudentMenu();
                string? input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        dbManager.GetInformationAllStudents();
                        UI.ReturnToHeadMenu();
                        keepRunning = false;

                        break;
                    case "2":
                        GetIdForStudent();
                        UI.ReturnToHeadMenu();
                        keepRunning = false;
                        break;
                    case "3":
                        GetIdForGrades();
                        UI.ReturnToHeadMenu();
                        keepRunning = false;
                        break;
                    case "4":
                        GradeStudent();
                        UI.ReturnToPreviousMenu();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        Console.WriteLine("\nTryck Enter för att fortsätta...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        internal void EconomyMenu()
        {
            bool keepRunning = true;
        
            while (keepRunning)
            {
                UI.Printed_EconomyMenu();
                string? input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        DbManager.SalaryEveryMonth();
                        UI.ReturnToPreviousMenu();
                        break;
                    case "2":
                        DbManager.AverageSalary();
                        UI.ReturnToPreviousMenu();
                        break;
                    case "3":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        Console.WriteLine("\nTryck Enter för att fortsätta...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        internal void SaveInfoAddStaff()
        {//just nu kan alla departments väljas och efter det bör bara den positionen kopplad till den avdelning komma upp för att inte kunna blanda avdelning och position fritt, som man just nu kan.

            DbManager.AllDepartments();
            Console.WriteLine();
            Console.Write("Vilken avdelning ska personalen läggas in i? Ange ID: ");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Ogiltigt ID. Tryck Enter för att fortsätta...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            DbManager.PositonsByDepartment(departmentId);
            Console.WriteLine();
            Console.Write("Vilken position ska personalen ha? Ange ID: ");
            if (!int.TryParse(Console.ReadLine(), out int positionsId))
            {
                Console.WriteLine("Ogiltigt ID. Tryck Enter för att fortsätta...");
                Console.ReadLine();
                return;
            }

            Console.Write("Ange förnamn: ");
            string firstname = Console.ReadLine();

            Console.Write("Ange efternamn: ");
            string lastname = Console.ReadLine();

            Console.Write("Ange personnummer (ÅÅÅÅMMDD): ");
            string socialSecurityNumber = Console.ReadLine();

            Console.Write("Ange e-post: ");
            string email = Console.ReadLine();

            Console.Write("Ange anställningsdatum (ÅÅÅÅ-MM-DD): ");
            string? dateInput = Console.ReadLine();
            if(!DateTime.TryParse(dateInput, out DateTime employmentDate))
            {
                Console.WriteLine("Ogiltigt datum. (ÅÅÅÅ-MM-DD). Tryck Enter för att fortsätta...");
                return;
            }

            Console.Write("Ange lön: ");
            if (!int.TryParse(Console.ReadLine(), out int salary))
            {
                Console.WriteLine("Felaktig inmatning. Tryck Enter för att fortsätta...");
                Console.ReadLine();
                return;
            }

            DbManager.AddStaff(firstname, lastname, socialSecurityNumber, email, employmentDate, salary, positionsId, departmentId);
            Console.WriteLine("Personalen tillagd. Du lyckades!");
        }

        internal void GetIdForGrades()
        {
            Console.WriteLine("VISAR ALLA ELEVER – VÄLJ ELEVID FÖR INFORMATION");
            Console.WriteLine(new string('═', 50));

            DbManager.GetAllStudents();

            Console.WriteLine();
            Console.Write("Vilken elev vill du betyginformation om? Ange ID: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Ogiltigt ID. Tryck Enter för att fortsätta...");
                Console.ReadLine();
                return;
            }

            DbManager.GetGradesForStudent(studentId);
        }

        internal void GetIdForStudent()
        {
            Console.WriteLine("📘 VISAR ALLA ELEVER – VÄLJ ELEVID FÖR INFORMATION");
            Console.WriteLine(new string('═', 55));

            DbManager.GetAllStudents();

            Console.WriteLine();
            Console.Write("Vilken elev vill du ha information om? Ange ID: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Ogiltigt ID. Tryck Enter för att fortsätta...");
                Console.ReadLine();
                return;
            }

            DbManager.GetInfoAboutStudent(studentId);
        }

        internal void GradeStudent()
        {
            Console.Clear();

            DbManager dbManager = new DbManager();

            // Visa och välj elev
            DbManager.GetAllStudents();
            Console.WriteLine();
            Console.Write("Välj elev - Ange ID: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Ogiltigt ID. Tryck Enter för att fortsätta...");
                Console.ReadLine();
                return;
            }

            Console.Clear();

            DbManager.GetAllSubjects();
            Console.WriteLine();
            Console.Write("Välj ämne - Ange ID: ");
            if (!int.TryParse(Console.ReadLine(), out int subjectId))
            {
                Console.WriteLine("Ogiltigt ID. Tryck Enter för att fortsätta...");
                Console.ReadLine();
                return;
            }

            Console.Clear();

            DbManager.GetStaffBySubject(subjectId);
            Console.WriteLine();
            Console.Write("Välj lärare - Ange ID: ");
            if (!int.TryParse(Console.ReadLine(), out int staffId))
            {
                Console.WriteLine("Ogiltigt ID. Tryck Enter för att fortsätta...");
                Console.ReadLine();
                return;
            }

            // Ange betyg
            Console.Write("Ange betyg (A-F): ");
            string? grade = Console.ReadLine()?.ToUpper();
            if (string.IsNullOrEmpty(grade) || grade.Length != 1)
            {
                Console.WriteLine("Ogiltigt betyg. Tryck Enter för att fortsätta...");
                Console.ReadLine();
                return;
            }

            // Ange datum
            Console.Write("Ange datum (ÅÅÅÅ-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime gradeDate))
            {
                Console.WriteLine("Ogiltigt datum. Tryck Enter för att fortsätta...");
                Console.ReadLine();
                return;
            }

            // Sätt betyget
            DbManager.GradeAStudent(studentId, subjectId, staffId, grade, gradeDate);
            Console.WriteLine("\nBetyget har satts!");
        }
    }
}
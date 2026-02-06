using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        Console.WriteLine("\nTryck Enter för att återgå till föregående meny...");
                        Console.ReadLine();
                        Console.Clear();
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
                        Console.WriteLine("\nTryck Enter för att återgå till föregående meny...");
                        Console.ReadLine();
                        break;
                    case "2":
                        DbManager.OverviewAllStaff();
                        Console.WriteLine("\nTryck Enter för att återgå till föregående meny...");
                        Console.ReadLine();
                        break;
                    case "3":
                        UI.Printed_AddNewStaff();//Ska ev bort om den ej ska användas. Behöver ju spara med readline, kanske bättre att lägga den som en stöd metod under alla switchmenyer.
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
          
            while (keepRunning)
            {
                UI.Printed_StudentMenu();
                string? input = Console.ReadLine();
                Console.Clear();

                DbManager dbManager = new DbManager();

                switch (input)
                {
                    case "1":
                        dbManager.GetInformationAllStudents();
                        Console.WriteLine("\nTryck Enter för att återgå till föregående meny...");
                        Console.ReadLine();
                        break;
                    case "2":
                        
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

        internal void EconomyMenu()
        {
            bool keepRunning = true;
        

            while (keepRunning)
            {
                UI.Printed_EconomyMenu();
                string? input = Console.ReadLine();


                //här ska nog vara en using...ELLER?

                switch (input)
                {
                    case "1":
                        Console.WriteLine("1. Översikt elever");
                        break;
                    case "2":
                        Console.WriteLine("2. Översikt betyg");
                        break;
                    case "3":
                        Console.WriteLine("Tillbaka till huvudmenyn.");//Ska denna ligga här?
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
    }
}
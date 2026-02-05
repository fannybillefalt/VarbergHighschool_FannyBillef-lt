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
                
                switch (input)
                {
                    case "1":
                        Console.WriteLine("1. Information om personalen");
                        //Här ska dbmanager metod ligga för val 1 i printedWelcomeMenu.
                        break;
                    case "2":
                        Console.WriteLine("2. Information om elever");
                        //Här ska dbmanager metod ligga för val 2 i printedWelcomeMenu.
                        break;
                    case "3":
                        Console.WriteLine("3. Ekonomi");
                        //Här ska dbmanager metod ligga för val 3 i printedWelcomeMenu.
                        break;
                    case "4":
                        Console.WriteLine("4. Kurser");
                        //Här ska dbmanager metod ligga för val 4 i printedWelcomeMenu.
                        break;
                    case "5":
                        Console.WriteLine("5. Avsluta");
                        Console.WriteLine("Hej då! Tack för denna gången.");
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

        internal void StaffMenu()//gör alla menyer som denna.
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                UI.Printed_StaffMenu();
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("1. Antal lärare per avdelning");
                        break;
                    case "2":
                        Console.WriteLine("2. Översikt all personal");
                        break;
                    case "3":
                        Console.WriteLine("3. Addera ny personal");
                        UI.Printed_AddNewStaff();//Ska ev bort om den ej ska användas. Behöver ju spara med readline, kanske bättre att lägga den som en stöd metod under alla switchmenyer.
                        break;
                    case "4":
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

        internal void StudentMenu()
        {
            bool keepRunning = true;
          
            while (keepRunning)
            {
                //här ska nog vara en using...ELLER?
                UI.Printed_StudentMenu();
                string? input = Console.ReadLine();
                //Console.Clear();

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
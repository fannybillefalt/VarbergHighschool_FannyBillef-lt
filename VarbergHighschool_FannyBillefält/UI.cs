using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarbergHighschool_FannyBillefält
{
    internal class UI
    {
        internal static void PrintedWelcomeMenu()
        {
            Console.WriteLine("Välkommen till Varberg-Highschool!");
            Console.WriteLine("__________________________________");
            Console.WriteLine();
            Console.WriteLine("1. Information om personalen");
            Console.WriteLine("2. Information om elever");
            Console.WriteLine("3. Ekonomi");
            Console.WriteLine("4. Kurser");
            Console.WriteLine("5. Avsluta");
            Console.Write("Ditt val: ");
        }

        internal static void Printed_StaffMenu()
        {
            Console.WriteLine("Personal vyn");
            Console.WriteLine("__________________________________");
            Console.WriteLine();
            Console.WriteLine("1. Antal lärare per avdelning");
            Console.WriteLine("2. Översikt all personal");
            Console.WriteLine("3. Addera ny personal");
            Console.WriteLine("4. Återgå till huvudmenyn");
            Console.Write("Ditt val: ");
        }

        internal static void Printed_StudentMenu()
        {
            Console.WriteLine("Elev vyn");
            Console.WriteLine("__________________________________");
            Console.WriteLine();
            Console.WriteLine("1. Översikt alla elever");
            Console.WriteLine("2. Information om enskild elev");
            Console.WriteLine("3. Översikt betyg");
            Console.WriteLine("4. Återgå till huvudmenyn");
            Console.Write("Ditt val: ");
        }

        internal static void Printed_EconomyMenu()
        {
            Console.WriteLine("Ekonomi vyn");
            Console.WriteLine("__________________________________");
            Console.WriteLine();
            Console.WriteLine("1. Lön per avdelning");
            Console.WriteLine("2. Medellön");
            Console.WriteLine("3. Återgå till huvudmenyn");
            Console.WriteLine("Ditt val: ");
        }

        internal static void ReturnToPreviousMenu()
        {
            Console.WriteLine("\nTryck Enter för att återgå till föregående meny...");
            Console.ReadLine();
            Console.Clear();
        }

    }
}

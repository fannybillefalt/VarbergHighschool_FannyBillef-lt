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
            Console.WriteLine("1. Antal lärare per avdelning");
            Console.WriteLine("2. Översikt all personal");
            Console.WriteLine("3. Addera ny personal");
            Console.Write("Ditt val: ");
        }

        internal static void Printed_StudentMenu()
        {
            Console.WriteLine("1. Översikt elever");
            Console.WriteLine("2. Översikt betyg");
            Console.Write("Ditt val: ");
        }

        internal static void Printed_EconomyMenu()
        {
            Console.WriteLine("Medellön");
            Console.WriteLine("Lön per avdelning");
        }

        internal static void Printed_AddNewStaff()
        {
            Console.WriteLine("Fyll i alla information om den nya personalen: ");
            Console.WriteLine("Förnamn: ");
            Console.WriteLine("Efternamn: ");
            Console.WriteLine("Personnummer: ");
            Console.WriteLine("Mejladress: ");
            Console.WriteLine("Anställningsdatum: ");
            Console.WriteLine("Lön: ");

        }

    }
}

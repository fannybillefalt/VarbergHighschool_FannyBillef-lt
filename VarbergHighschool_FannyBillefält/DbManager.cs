using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarbergHighschool_FannyBillefält.Models;

namespace VarbergHighschool_FannyBillefält
{
    internal class DbManager
    {
        private static readonly string _connectionString = @"Server = localhost; Database = VarbergHighschool;Integrated Security=true;Trust Server Certificate = true;";
        
        //Hur många lärare jobbar på de olika avdelningarna? (EF)
        internal void TeachersPerDepartment()
        {
            using (var context = new VarbergHighschoolContext())
            {
                var teachersPerDepartment = context.Staff
                    .Where(s => s.Position.Position1 == "Lärare")
                    .GroupBy(s => s.Department.DepartmentName)
                    .Select(x => new
                    {
                        Department = x.Key,
                        TeacherCount = x.Count()
                    })
                    .ToList();

                foreach (var department in teachersPerDepartment)
                {
                    Console.WriteLine($"{department.Department} ");
                    Console.WriteLine(new string('═', 20));
                    Console.WriteLine($"{department.TeacherCount} lärare");
                    Console.WriteLine();
                }
            }
        }

        //Visa information om alla elever(t.ex namn, klass och annat som är intressant/relevant i din databas) (EF)

        internal void GetInformationAllStudents()
        {
            using (var context = new VarbergHighschoolContext())
            {
                var studentsByClass = context.Students
                    .Join(
                    context.Classes,
                    s => s.ClassId,
                    c => c.Id,
                    (s, c) => new
                    {
                        c.Classname,
                        Namn = s.Firstname + " " + s.Lastname,
                        s.SocialSecurityNumber

                    })
                    .GroupBy(x => x.Classname)
                    .ToList();


                foreach (var classGroup in studentsByClass)
                {
                    Console.WriteLine($"\nKlass: {classGroup.Key}");
                    Console.WriteLine(new string('═', 70));

                    // Kolumnen
                    Console.WriteLine($"{"Namn",-35} | {"Personnummer",-15}");
                    Console.WriteLine(new string('─', 70));

                    // Eleverna
                    foreach (var student in classGroup)
                    {
                        Console.WriteLine($"{student.Namn,-35} | {student.SocialSecurityNumber,-15}");
                    }
                }
            }
        }

        //Visa en lista på alla aktiva kurser (EF)
        internal void AllCourses()
        {
            using (var context = new VarbergHighschoolContext())
            {
                var allCourses = context.Subjects
                    .GroupBy(x => x.IsActive)
                    .ToList();

                foreach (var course in allCourses)
                {
                    Console.WriteLine($"\n{(course.Key ? "Aktiva" : "Inaktiva")}");
                    Console.WriteLine(new string('═', 10));

                    foreach (var c in course)
                    {
                        Console.WriteLine($"{c.SubjectName,-35} ");
                    }
                }
            }
        }

        //Skolan vill kunna ta fram en översikt över all personal där det framgår namn
        //och vilka befattningar de har samt hur många år dehar arbetat på skolan.


    }
}

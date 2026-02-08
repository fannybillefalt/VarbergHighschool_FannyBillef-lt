using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using VarbergHighschool_FannyBillefält.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace VarbergHighschool_FannyBillefält
{
    internal class DbManager
    {
        private static readonly string _connectionString = @"Server = localhost; Database = VarbergHighschool;Integrated Security=true;Trust Server Certificate = true;";

        //Hur många lärare jobbar på de olika avdelningarna?
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
                    Console.WriteLine(new string('═', 50));

                    // Kolumnen
                    Console.WriteLine($"{"Namn",-25} | {"Personnummer",-15}");
                    Console.WriteLine(new string('─', 50));

                    // Eleverna
                    foreach (var student in classGroup)
                    {
                        Console.WriteLine($"{student.Namn,-25} | {student.SocialSecurityNumber,-15}");
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

        internal static void GetAllStudents()
        {
            string query = "EXEC GetAllStudents";
            ADO_Execute(query);
        }

        internal static void GetAllSubjects()
        {
            string query = "EXEC GetAllSubjects";
            ADO_Execute(query);
        }

        //Sätt betyg på en elev genom att använda Transactions ifall något går fel. 
        internal static void GradeAStudent(int studentId, int subjectId, int staffId, string grade, DateTime gradeDate)
        {
            var parameters = new List<SqlParameter>
    {
                new SqlParameter("@StudentId", studentId),
                new SqlParameter("@SubjectId", subjectId),
                new SqlParameter("@StaffId", staffId),
                new SqlParameter("@Grade", grade),
                new SqlParameter("@GradeDate", gradeDate)
    };
            ADO_ExecuteSP("GradeAStudent", parameters);
        }

        internal static void GetStaffBySubject(int subjectId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@SubjectId", subjectId)
            };

            ADO_ExecuteSP("GetStaffBySubject", parameters);
        }
        internal static void GetInfoAboutStudent(int studentId)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter ("@StudentId", studentId)
            };

            ADO_ExecuteSP("GetInfoAboutStudent", parameter);
        }
        internal static void SalaryEveryMonth()
        {
            string query = "EXEC SalaryEveryMonth";
            ADO_Execute(query);
        }

        internal static void AverageSalary()
        {
            string query = "EXEC AverageSalary";
            ADO_Execute(query);
        }

        //ej fullkomlig
        // Vi vill kunna ta fram alla betyg för en elev i varje kurs/ämne de läst och
        //vi vill kunna se vilken lärare som satt betygen,
        //vi vill också se vilka datum betygen satts. (SQL via ADO.Net)
       //stilen utskriften ej färdig.
        internal static void GetGradesForStudent(int studentId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@StudentId", studentId)
            };

            ADO_ExecuteSP("GetGradesForStudent", parameters);
        }

        //Skolan vill kunna ta fram en översikt över all personal där det framgår namn
        //och vilka befattningar de har samt hur många år dehar arbetat på skolan.
        internal static void OverviewAllStaff()
        {
            string query = "EXEC OverviewAllStaff";
            ADO_Execute(query);
        }

        internal static void AllDepartments()
        {
            string query = "SELECT Id, DepartmentName AS Avdelning " +
                            "FROM Departments";

            ADO_Execute(query);
        }

        //får bara fram positioner kopplat till avdelningen som är vald.
        //dock kan man lägga till personal på avdelning som ej finns, och positon som ej finns :(
        internal static void PositonsByDepartment(int departmentId)
        {
            string query = "SELECT Id, Position FROM Positions " +
                "WHERE DepartmentId = @DepartmentId";

            using (var connection = new SqlConnection(_connectionString))
            {

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DepartmentId", departmentId);

                    try
                    {
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    ADO_Reader(command);
                }
            }
        }

        internal static void AddStaff(string firstname, string lastname,
                                        string socialSecurityNumber, string email,
                                        DateTime employmentDate, int salary,
                                        int positionId, int departmentId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Firstname", firstname),
                new SqlParameter("@Lastname", lastname),
                new SqlParameter("@SocialSecurityNumber", socialSecurityNumber),
                new SqlParameter("@Email", email),
                new SqlParameter("@EmploymentDate", employmentDate),
                new SqlParameter("@Salary", salary),
                new SqlParameter("@PositionId", positionId),
                new SqlParameter("@DepartmentId", departmentId)
            };

            ADO_ExecuteSP("AddNewStaff", parameters);
        }



        public static void ADO_ExecuteSP(string query, List<SqlParameter> parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;//denna behövs för att den ska kunna läsa en SP
                    try
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {

                                command.Parameters.Add(param);

                            }
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader.GetName(i) + "\t");
                            }

                            Console.WriteLine();

                            while(reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader.GetValue(i)}\t");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                connection.Close();
            }
        }

        public static void ADO_Execute(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);

                ADO_Reader(command);
                connection.Close();
            }
        }

                    
        public static void ADO_Reader(SqlCommand command)
        {
            try
            {
                using (var reader = command.ExecuteReader())
                {   //SKRIVER UT KOLUMNER
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader.GetName(i),-20}");
                    }

                    Console.WriteLine();

                    while (reader.Read())
                    {   //SKRIVER UT VALUE
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader.GetValue(i),-20}");
                        }

                        Console.WriteLine();
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

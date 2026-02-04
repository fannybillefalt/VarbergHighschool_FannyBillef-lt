using System;
using System.Collections.Generic;

namespace VarbergHighschool_FannyBillefält.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string SocialSecurityNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly EmploymentDate { get; set; }

    public int Salary { get; set; }

    public int? PositionId { get; set; }

    public int? DepartmentId { get; set; }

    public virtual ICollection<ClassTeacher> ClassTeachers { get; set; } = new List<ClassTeacher>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Position? Position { get; set; }
}

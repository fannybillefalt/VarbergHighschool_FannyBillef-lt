using System;
using System.Collections.Generic;

namespace VarbergHighschool_FannyBillefält.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string SocialSecurityNumber { get; set; } = null!;

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}

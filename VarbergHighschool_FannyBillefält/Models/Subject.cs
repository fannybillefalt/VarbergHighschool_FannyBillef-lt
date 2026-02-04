using System;
using System.Collections.Generic;

namespace VarbergHighschool_FannyBillefält.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string SubjectName { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<ClassTeacher> ClassTeachers { get; set; } = new List<ClassTeacher>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}

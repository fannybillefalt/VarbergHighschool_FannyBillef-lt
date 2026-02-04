using System;
using System.Collections.Generic;

namespace VarbergHighschool_FannyBillefält.Models;

public partial class Class
{
    public int Id { get; set; }

    public string Classname { get; set; } = null!;

    public virtual ICollection<ClassTeacher> ClassTeachers { get; set; } = new List<ClassTeacher>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

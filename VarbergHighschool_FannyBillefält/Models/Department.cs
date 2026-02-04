using System;
using System.Collections.Generic;

namespace VarbergHighschool_FannyBillefält.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}

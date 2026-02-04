using System;
using System.Collections.Generic;

namespace VarbergHighschool_FannyBillefält.Models;

public partial class Grade
{
    public int Id { get; set; }

    public string Grade1 { get; set; } = null!;

    public DateOnly? GradeDate { get; set; }

    public int? SubjectId { get; set; }

    public int? StudentId { get; set; }

    public int? StaffId { get; set; }

    public virtual Staff? Staff { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }
}

using System;
using System.Collections.Generic;

namespace VarbergHighschool_FannyBillefält.Models;

public partial class ClassTeacher
{
    public int Id { get; set; }

    public int? ClassId { get; set; }

    public int? StaffId { get; set; }

    public int? SubjectId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Staff? Staff { get; set; }

    public virtual Subject? Subject { get; set; }
}

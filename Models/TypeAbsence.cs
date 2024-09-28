using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class TypeAbsence
{
    public int IdTypeAbsence { get; set; }

    public string TypeAbsence1 { get; set; } = null!;

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();
}

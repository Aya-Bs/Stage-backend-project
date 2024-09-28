using System;
using System.Collections.Generic;
using ProjetStage;

namespace StageApp.Models;

public partial class Absence
{
    public int IdAbsence { get; set; }

    public DateOnly DateFin { get; set; }

    public DateOnly DateDebut { get; set; }

    public string MomentDebut { get; set; } = null!;

    public string MomentFin { get; set; } = null!;

    public int IdSalarie { get; set; }

    public int IdTypeAbsence { get; set; }

    public string Commentaire { get; set; } = null!;

    public virtual Salarie IdSalarieNavigation { get; set; } = null!;

    public virtual TypeAbsence IdTypeAbsenceNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Affectation
{
    public int IdAffectation { get; set; }

    public int IdPhaseAffectation { get; set; }

    public int IdSalarie { get; set; }

    public DateOnly DateAff { get; set; }

    public int NbrHeures { get; set; }

    public string Description { get; set; } = null!;

    public virtual PhaseAffectation IdPhaseAffectationNavigation { get; set; } = null!;

    public virtual Salarie IdSalarieNavigation { get; set; } = null!;

    public virtual ICollection<PhaseAffectation> PhaseAffectations { get; set; } = new List<PhaseAffectation>();
}

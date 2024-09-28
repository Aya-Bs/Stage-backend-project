using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Faisabilite
{
    public int IdFaisabilite { get; set; }

    public int IdPrestation { get; set; }

    public int IdStatut { get; set; }

    public DateOnly DateRendu { get; set; }

    public int IdArchitecture { get; set; }

    public virtual Architecte IdArchitectureNavigation { get; set; } = null!;

    public virtual Prestation IdPrestationNavigation { get; set; } = null!;

    public virtual Statut IdStatutNavigation { get; set; } = null!;
}

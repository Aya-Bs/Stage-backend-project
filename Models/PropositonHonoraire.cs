using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class PropositonHonoraire
{
    public int IdProposition { get; set; }

    public int IdPhaseAffectation { get; set; }

    public int IdStatut { get; set; }

    public DateOnly Date { get; set; }

    public int IdPrestation { get; set; }

    public string? Commentaire { get; set; }

    public virtual PhaseAffectation IdPhaseAffectationNavigation { get; set; } = null!;

    public virtual Prestation IdPrestationNavigation { get; set; } = null!;

    public virtual Statut IdStatutNavigation { get; set; } = null!;
}

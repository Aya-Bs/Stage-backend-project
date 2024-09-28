using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class EvolutionHonoraire
{
    public int IdEvolution { get; set; }

    public int IdPhaseAffectation { get; set; }

    public DateOnly Date { get; set; }

    public double Montant { get; set; }

    public string Commentaire { get; set; } = null!;

    public virtual PhaseAffectation IdPhaseAffectationNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class PhaseAffectation
{
    public int IdPhaseAffectation { get; set; }

    public int IdPhase { get; set; }

    public int IdAffectation { get; set; }

    public int IdStatut { get; set; }

    public DateOnly DateRendu { get; set; }

    public string TypePrestation { get; set; } = null!;

    public int IdPrestation { get; set; }

    public virtual ICollection<Affectation> Affectations { get; set; } = new List<Affectation>();

    public virtual ICollection<EvolutionHonoraire> EvolutionHonoraires { get; set; } = new List<EvolutionHonoraire>();

    public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();

    public virtual Affectation IdAffectationNavigation { get; set; } = null!;

    public virtual Phase IdPhaseNavigation { get; set; } = null!;

    public virtual Prestation IdPrestationNavigation { get; set; } = null!;

    public virtual Statut IdStatutNavigation { get; set; } = null!;

    public virtual ICollection<PropositonHonoraire> PropositonHonoraires { get; set; } = new List<PropositonHonoraire>();
}

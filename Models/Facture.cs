using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Facture
{
    public int IdFacture { get; set; }

    public int IdPhaseAffectation { get; set; }

    public string Libelle { get; set; } = null!;

    public int NumeroFacture { get; set; }

    public DateOnly DateEmission { get; set; }

    public virtual ICollection<FactureDetail> FactureDetails { get; set; } = new List<FactureDetail>();

    public virtual PhaseAffectation IdPhaseAffectationNavigation { get; set; } = null!;

    public virtual ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
}

using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Paiement
{
    public int IdPaiement { get; set; }

    public int IdFacture { get; set; }

    public string Libelle { get; set; } = null!;

    public double Montant { get; set; }

    public DateOnly DatePaiement { get; set; }

    public virtual Facture IdFactureNavigation { get; set; } = null!;
}

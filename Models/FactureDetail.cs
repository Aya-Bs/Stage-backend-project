using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class FactureDetail
{
    public int IdFactureDetails { get; set; }

    public int IdFacture { get; set; }

    public int Quantite { get; set; }

    public float PrixUnitaireHt { get; set; }

    public float TauxTva { get; set; }

    public virtual Facture IdFactureNavigation { get; set; } = null!;
}

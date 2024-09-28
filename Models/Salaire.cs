using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Salaire
{
    public int IdSalaire { get; set; }

    public DateOnly DatePaiement { get; set; }

    public int IdSalarie { get; set; }

    public double MtBrutAnnuel { get; set; }

    public int NbrHeuresContrat { get; set; }

    public int IdFonction { get; set; }

    public int IdService { get; set; }

    public string Commentaires { get; set; } = null!;

    public virtual Fonction IdFonctionNavigation { get; set; } = null!;

    public virtual Salarie IdSalarieNavigation { get; set; } = null!;

    public virtual Service IdServiceNavigation { get; set; } = null!;
}

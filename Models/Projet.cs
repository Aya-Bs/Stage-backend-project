using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Projet
{
    public int IdProjet { get; set; }

    public DateOnly DateRendu { get; set; }

    public int IdStatut { get; set; }

    public int IdAvantProjet { get; set; }

    public int IdSalarie { get; set; }

    public int IdPrestation { get; set; }

    public double MtHtTravaux { get; set; }

    public int NumProjet { get; set; }

    public virtual AvantProjet IdAvantProjetNavigation { get; set; } = null!;

    public virtual Prestation IdPrestationNavigation { get; set; } = null!;

    public virtual Salarie IdSalarieNavigation { get; set; } = null!;

    public virtual Statut IdStatutNavigation { get; set; } = null!;
}

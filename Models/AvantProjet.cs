using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class AvantProjet
{
    public int IdAvantProjet { get; set; }

    public DateOnly DateRendu { get; set; }

    public int IdSalarie { get; set; }

    public double MtHtTravaux { get; set; }

    public int NumAvantProjet { get; set; }

    public int IdPrestation { get; set; }

    public int IdStatut { get; set; }

    public virtual Prestation IdPrestationNavigation { get; set; } = null!;

    public virtual Salarie IdSalarieNavigation { get; set; } = null!;

    public virtual Statut IdStatutNavigation { get; set; } = null!;

    public virtual ICollection<Projet> Projets { get; set; } = new List<Projet>();
}

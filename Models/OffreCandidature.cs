using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class OffreCandidature
{
    public int IdOffreCandidature { get; set; }

    public DateOnly DateRendu { get; set; }

    public int IdStatut { get; set; }

    public int IdSalarie { get; set; }

    public int IdStatutExclusivite { get; set; }

    public int IdPrestation { get; set; }

    public int IdOffre { get; set; }

    public int IdCandidature { get; set; }

    public double MtHtTravaux { get; set; }

    public bool Offres { get; set; }

    public bool Dpi { get; set; }

    public bool Stream { get; set; }

    public string Commentaire { get; set; } = null!;

    public virtual Candidature IdCandidatureNavigation { get; set; } = null!;

    public virtual Offre IdOffreNavigation { get; set; } = null!;

    public virtual Prestation IdPrestationNavigation { get; set; } = null!;

    public virtual Salarie IdSalarieNavigation { get; set; } = null!;

    public virtual StatutExclusivite IdStatutExclusiviteNavigation { get; set; } = null!;

    public virtual Statut IdStatutNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Offre
{
    public int IdOffre { get; set; }

    public int IdStatut { get; set; }

    public DateOnly DateRendu { get; set; }

    public int IdArchitecte { get; set; }

    public int IdPrestation { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual Architecte IdArchitecteNavigation { get; set; } = null!;

    public virtual Prestation IdPrestationNavigation { get; set; } = null!;

    public virtual Statut IdStatutNavigation { get; set; } = null!;

    public virtual ICollection<OffreCandidature> OffreCandidatures { get; set; } = new List<OffreCandidature>();
}

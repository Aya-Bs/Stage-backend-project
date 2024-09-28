using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class StatutExclusivite
{
    public int IdStatutExclusivite { get; set; }

    public string StatutExclusivite1 { get; set; } = null!;

    public virtual ICollection<Candidature> Candidatures { get; set; } = new List<Candidature>();

    public virtual ICollection<OffreCandidature> OffreCandidatures { get; set; } = new List<OffreCandidature>();
}

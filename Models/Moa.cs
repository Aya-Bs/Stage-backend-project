using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Moa
{
    public int IdMoa { get; set; }

    public string RaisonSocial { get; set; } = null!;

    public string FormeJuridique { get; set; } = null!;

    public string SirenMoa { get; set; } = null!;

    public string NomMoa { get; set; } = null!;

    public string PrenomMoa { get; set; } = null!;

    public int IdContact { get; set; }

    public int IdAdresse { get; set; }

    public string Commentaires { get; set; } = null!;

    public virtual Adresse IdAdresseNavigation { get; set; } = null!;

    public virtual Contact IdContactNavigation { get; set; } = null!;

    public virtual ICollection<Prestation> Prestations { get; set; } = new List<Prestation>();
}

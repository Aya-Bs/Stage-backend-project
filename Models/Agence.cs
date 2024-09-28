using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Agence
{
    public int IdAgence { get; set; }

    public string NomAgence { get; set; } = null!;

    public string Siren { get; set; } = null!;

    public int TvaIntraComm { get; set; }

    public int IdAdresse { get; set; }

    public virtual Adresse IdAdresseNavigation { get; set; } = null!;

    public virtual ICollection<Salarie> Salaries { get; set; } = new List<Salarie>();
}

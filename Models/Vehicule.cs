using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Vehicule
{
    public int IdVehicule { get; set; }

    public int IdSalarie { get; set; }

    public string NumeroImmatriculation { get; set; } = null!;

    public string Assureur { get; set; } = null!;

    public string NumeroContratAssureur { get; set; } = null!;

    public virtual Salarie IdSalarieNavigation { get; set; } = null!;
}

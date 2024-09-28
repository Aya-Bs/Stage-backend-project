using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Enfant
{
    public int IdEnfant { get; set; }

    public int IdSalarie { get; set; }

    public string Prenom { get; set; } = null!;

    public DateOnly DateNaissance { get; set; }

    public virtual Salarie IdSalarieNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Adresse
{
    public int IdAdresse { get; set; }

    public string Adresse1 { get; set; } = null!;

    public string CodePostal { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public virtual ICollection<Agence> Agences { get; set; } = new List<Agence>();

    public virtual ICollection<Architecte> Architectes { get; set; } = new List<Architecte>();

    public virtual ICollection<Moa> Moas { get; set; } = new List<Moa>();

    public virtual ICollection<Salarie> Salaries { get; set; } = new List<Salarie>();
    public Adresse(){}

    //generer le constructeur sans les listes
    public Adresse(int idAdresse, string adresse1, string codePostal, string ville)
    {
        IdAdresse = idAdresse;
        Adresse1 = adresse1;
        CodePostal = codePostal;
        Ville = ville;
    }

   
}

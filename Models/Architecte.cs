using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Architecte
{
    public int IdArchitecte { get; set; }

    public string RasionSocial { get; set; } = null!;

    public string NomArchitecte { get; set; } = null!;

    public string PrenomArchitecte { get; set; } = null!;

    public int IdAdresse { get; set; }

    public string SirenArchitecte { get; set; } = null!;

    public int IdContact { get; set; }

    public virtual ICollection<Candidature> Candidatures { get; set; } = new List<Candidature>();

    public virtual ICollection<Faisabilite> Faisabilites { get; set; } = new List<Faisabilite>();

    public virtual Adresse IdAdresseNavigation { get; set; } = null!;

    public virtual Contact IdContactNavigation { get; set; } = null!;

    public virtual ICollection<Offre> Offres { get; set; } = new List<Offre>();

    //constructeur par défaut
    public Architecte() { }
    //constructeur avec paramètres
    public Architecte(int idArchitecte, string rasionSocial, string nomArchitecte, string prenomArchitecte, int idAdresse, string sirenArchitecte, int idContact)
    {
        IdArchitecte = idArchitecte;
        RasionSocial = rasionSocial;
        NomArchitecte = nomArchitecte;
        PrenomArchitecte = prenomArchitecte;
        IdAdresse = idAdresse;
        SirenArchitecte = sirenArchitecte;
        IdContact = idContact;
    }
}

using System;
using System.Collections.Generic;
using StageApp.DTO;

namespace StageApp.Models;

public partial class Candidature
{
    public int IdCandidature { get; set; }

    public DateTime DateRendu { get; set; }

    public double MtIndemnite { get; set; }

    public double MtHtTravaux { get; set; }

    public bool Stream { get; set; }

    public bool Offre { get; set; }

    public bool Dpi { get; set; }

    public int IdStatut { get; set; }

    public int IdSalarie { get; set; }

    public int IdPrestation { get; set; }

    public int IdArchitecte { get; set; }

    public int IdStatutExclusivite { get; set; }

    public string Commentaire { get; set; } = null!;

    public virtual Architecte IdArchitecteNavigation { get; set; } = null!;

    public virtual Prestation IdPrestationNavigation { get; set; } = null!;

    public virtual Salarie IdSalarieNavigation { get; set; } = null!;

    public virtual StatutExclusivite IdStatutExclusiviteNavigation { get; set; } = null!;

    public virtual Statut IdStatutNavigation { get; set; } = null!;

    public virtual ICollection<OffreCandidature> OffreCandidatures { get; set; } = new List<OffreCandidature>();
    
    //constructeur par défaut
    public Candidature() { }
    //constructeur avec paramètres
    public Candidature(int idCandidature, DateTime dateRendu, double mtIndemnite, double mtHtTravaux, bool stream, bool offre, bool dpi, int idStatut, int idSalarie, int idPrestation, int idArchitecte, int idStatutExclusivite, string commentaire)
    {
        IdCandidature = idCandidature;
        DateRendu = dateRendu;
        MtIndemnite = mtIndemnite;
        MtHtTravaux = mtHtTravaux;
        Stream = stream;
        Offre = offre;
        Dpi = dpi;
        IdStatut = idStatut;
        IdSalarie = idSalarie;
        IdPrestation = idPrestation;
        IdArchitecte = idArchitecte;
        IdStatutExclusivite = idStatutExclusivite;
        Commentaire = commentaire;
    }

}

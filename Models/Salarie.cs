using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Salarie
{
    public int IdSalarie { get; set; }

    public string NomSalarie { get; set; } = null!;

    public string PrenomSalarie { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int IdAgence { get; set; }

    public string Statut { get; set; } = null!;

    public DateOnly DateNaissance { get; set; }

    public string TelephoneFixe { get; set; } = null!;

    public string TelephonePortable { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public int IdAdresse { get; set; }

    public string NumSecuriteSociale { get; set; } = null!;

    public string Permis { get; set; } = null!;

    public string Commentaires { get; set; } = null!;

    public int IdContact { get; set; }

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();

    public virtual ICollection<Affectation> Affectations { get; set; } = new List<Affectation>();

    public virtual ICollection<AvantProjet> AvantProjets { get; set; } = new List<AvantProjet>();

    public virtual ICollection<Candidature> Candidatures { get; set; } = new List<Candidature>();

    public virtual ICollection<Enfant> Enfants { get; set; } = new List<Enfant>();

    public virtual Adresse IdAdresseNavigation { get; set; } = null!;

    public virtual Agence IdAgenceNavigation { get; set; } = null!;

    public virtual Contact IdContactNavigation { get; set; } = null!;

    public virtual ICollection<OffreCandidature> OffreCandidatures { get; set; } = new List<OffreCandidature>();

    public virtual ICollection<Projet> Projets { get; set; } = new List<Projet>();

    public virtual ICollection<Vehicule> Vehicules { get; set; } = new List<Vehicule>();
}

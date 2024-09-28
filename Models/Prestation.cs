using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Prestation
{
    public int IdPrestation { get; set; }

    public int IdMoa { get; set; }

    public string Intitule { get; set; } = null!;

    public double SuperficieChantier { get; set; }

    public string SousTraitance { get; set; } = null!;

    public string TypeAffaire { get; set; } = null!;

    public string Typologie { get; set; } = null!;

    public virtual ICollection<AvantProjet> AvantProjets { get; set; } = new List<AvantProjet>();

    public virtual ICollection<Candidature> Candidatures { get; set; } = new List<Candidature>();

    public virtual ICollection<Faisabilite> Faisabilites { get; set; } = new List<Faisabilite>();

    public virtual Moa IdMoaNavigation { get; set; } = null!;

    public virtual ICollection<OffreCandidature> OffreCandidatures { get; set; } = new List<OffreCandidature>();

    public virtual ICollection<Offre> Offres { get; set; } = new List<Offre>();

    public virtual ICollection<PhaseAffectation> PhaseAffectations { get; set; } = new List<PhaseAffectation>();

    public virtual ICollection<Projet> Projets { get; set; } = new List<Projet>();

    public virtual ICollection<PropositonHonoraire> PropositonHonoraires { get; set; } = new List<PropositonHonoraire>();
}

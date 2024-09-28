using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Statut
{
    public int IdStatut { get; set; }

    public string Statut1 { get; set; } = null!;

    public virtual ICollection<AvantProjet> AvantProjets { get; set; } = new List<AvantProjet>();

    public virtual ICollection<Candidature> Candidatures { get; set; } = new List<Candidature>();

    public virtual ICollection<Faisabilite> Faisabilites { get; set; } = new List<Faisabilite>();

    public virtual ICollection<OffreCandidature> OffreCandidatures { get; set; } = new List<OffreCandidature>();

    public virtual ICollection<Offre> Offres { get; set; } = new List<Offre>();

    public virtual ICollection<PhaseAffectation> PhaseAffectations { get; set; } = new List<PhaseAffectation>();

    public virtual ICollection<Projet> Projets { get; set; } = new List<Projet>();

    public virtual ICollection<PropositonHonoraire> PropositonHonoraires { get; set; } = new List<PropositonHonoraire>();
}

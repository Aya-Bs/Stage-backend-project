using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using StageApp.Models;

namespace StageApp.DAO;

public partial class BdStageContext : DbContext
{
    private readonly string _connectionString;
    public BdStageContext()
    {

    }

    public BdStageContext(DbContextOptions<BdStageContext> options, IConfiguration configuration)
        : base(options)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public virtual DbSet<Absence> Absences { get; set; }

    public virtual DbSet<Adresse> Adresses { get; set; }

    public virtual DbSet<Affectation> Affectations { get; set; }

    public virtual DbSet<Agence> Agences { get; set; }

    public virtual DbSet<Architecte> Architectes { get; set; }

    public virtual DbSet<AvantProjet> AvantProjets { get; set; }

    public virtual DbSet<Candidature> Candidatures { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Enfant> Enfants { get; set; }

    public virtual DbSet<EvolutionHonoraire> EvolutionHonoraires { get; set; }

    public virtual DbSet<Facture> Factures { get; set; }

    public virtual DbSet<FactureDetail> FactureDetails { get; set; }

    public virtual DbSet<Faisabilite> Faisabilites { get; set; }

    public virtual DbSet<Fonction> Fonctions { get; set; }

    public virtual DbSet<Moa> Moas { get; set; }

    public virtual DbSet<Offre> Offres { get; set; }

    public virtual DbSet<OffreCandidature> OffreCandidatures { get; set; }

    public virtual DbSet<Paiement> Paiements { get; set; }

    public virtual DbSet<Phase> Phases { get; set; }

    public virtual DbSet<PhaseAffectation> PhaseAffectations { get; set; }

    public virtual DbSet<Prestation> Prestations { get; set; }

    public virtual DbSet<Projet> Projets { get; set; }

    public virtual DbSet<PropositonHonoraire> PropositonHonoraires { get; set; }

    public virtual DbSet<Salaire> Salaires { get; set; }

    public virtual DbSet<Salarie> Salaries { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Statut> Statuts { get; set; }

    public virtual DbSet<StatutExclusivite> StatutExclusivites { get; set; }

    public virtual DbSet<TypeAbsence> TypeAbsences { get; set; }

    public virtual DbSet<Vehicule> Vehicules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(_connectionString, ServerVersion.Parse("10.4.24-mariadb"));
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Absence>(entity =>
        {
            entity.HasKey(e => e.IdAbsence).HasName("PRIMARY");

            entity.ToTable("absence");

            entity.HasIndex(e => e.IdSalarie, "ID_salarie");

            entity.HasIndex(e => e.IdTypeAbsence, "ID_type_absence");

            entity.Property(e => e.IdAbsence)
                .HasColumnType("int(11)")
                .HasColumnName("ID_absence");
            entity.Property(e => e.Commentaire)
                .HasMaxLength(255)
                .HasColumnName("commentaire");
            entity.Property(e => e.DateDebut).HasColumnName("date_debut");
            entity.Property(e => e.DateFin).HasColumnName("date_fin");
            entity.Property(e => e.IdSalarie)
                .HasColumnType("int(11)")
                .HasColumnName("ID_salarie");
            entity.Property(e => e.IdTypeAbsence)
                .HasColumnType("int(11)")
                .HasColumnName("ID_type_absence");
            entity.Property(e => e.MomentDebut)
                .HasMaxLength(255)
                .HasColumnName("moment_debut");
            entity.Property(e => e.MomentFin)
                .HasMaxLength(255)
                .HasColumnName("moment_fin");

            entity.HasOne(d => d.IdSalarieNavigation).WithMany(p => p.Absences)
                .HasForeignKey(d => d.IdSalarie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("absence_ibfk_1");

            entity.HasOne(d => d.IdTypeAbsenceNavigation).WithMany(p => p.Absences)
                .HasForeignKey(d => d.IdTypeAbsence)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("absence_ibfk_2");
        });

        modelBuilder.Entity<Adresse>(entity =>
        {
            entity.HasKey(e => e.IdAdresse).HasName("PRIMARY");

            entity.ToTable("adresse");

            entity.Property(e => e.IdAdresse)
                .HasColumnType("int(11)")
                .HasColumnName("ID_adresse");
            entity.Property(e => e.Adresse1)
                .HasMaxLength(255)
                .HasColumnName("adresse");
            entity.Property(e => e.CodePostal)
                .HasMaxLength(255)
                .HasColumnName("code_postal");
            entity.Property(e => e.Ville)
                .HasMaxLength(255)
                .HasColumnName("ville");
        });

        modelBuilder.Entity<Affectation>(entity =>
        {
            entity.HasKey(e => e.IdAffectation).HasName("PRIMARY");

            entity.ToTable("affectation");

            entity.HasIndex(e => e.IdSalarie, "ID_salarie");

            entity.HasIndex(e => e.IdPhaseAffectation, "t_affectation_ibfk_1");

            entity.Property(e => e.IdAffectation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_affectation");
            entity.Property(e => e.DateAff).HasColumnName("date_aff");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.IdPhaseAffectation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_phase_affectation");
            entity.Property(e => e.IdSalarie)
                .HasColumnType("int(11)")
                .HasColumnName("ID_salarie");
            entity.Property(e => e.NbrHeures)
                .HasColumnType("int(11)")
                .HasColumnName("nbr_heures");

            entity.HasOne(d => d.IdPhaseAffectationNavigation).WithMany(p => p.Affectations)
                .HasForeignKey(d => d.IdPhaseAffectation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("affectation_ibfk_1");

            entity.HasOne(d => d.IdSalarieNavigation).WithMany(p => p.Affectations)
                .HasForeignKey(d => d.IdSalarie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("affectation_ibfk_2");
        });

        modelBuilder.Entity<Agence>(entity =>
        {
            entity.HasKey(e => e.IdAgence).HasName("PRIMARY");

            entity.ToTable("agence");

            entity.HasIndex(e => e.IdAdresse, "ID_adresse");

            entity.Property(e => e.IdAgence)
                .HasColumnType("int(11)")
                .HasColumnName("ID_agence");
            entity.Property(e => e.IdAdresse)
                .HasColumnType("int(11)")
                .HasColumnName("ID_adresse");
            entity.Property(e => e.NomAgence)
                .HasMaxLength(255)
                .HasColumnName("NOM_agence");
            entity.Property(e => e.Siren)
                .HasMaxLength(255)
                .HasColumnName("SIREN");
            entity.Property(e => e.TvaIntraComm)
                .HasColumnType("int(11)")
                .HasColumnName("TVA_intra_comm");

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.Agences)
                .HasForeignKey(d => d.IdAdresse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("agence_ibfk_1");
        });

        modelBuilder.Entity<Architecte>(entity =>
        {
            entity.HasKey(e => e.IdArchitecte).HasName("PRIMARY");

            entity.ToTable("architecte");

            entity.HasIndex(e => e.IdAdresse, "ID_adresse");

            entity.HasIndex(e => e.IdContact, "ID_contact");

            entity.Property(e => e.IdArchitecte)
                .HasColumnType("int(11)")
                .HasColumnName("ID_architecte");
            entity.Property(e => e.IdAdresse)
                .HasColumnType("int(11)")
                .HasColumnName("ID_adresse");
            entity.Property(e => e.IdContact)
                .HasColumnType("int(11)")
                .HasColumnName("ID_contact");
            entity.Property(e => e.NomArchitecte)
                .HasMaxLength(255)
                .HasColumnName("nom_architecte");
            entity.Property(e => e.PrenomArchitecte)
                .HasMaxLength(255)
                .HasColumnName("prenom_architecte");
            entity.Property(e => e.RasionSocial)
                .HasMaxLength(255)
                .HasColumnName("rasion_social");
            entity.Property(e => e.SirenArchitecte)
                .HasMaxLength(255)
                .HasColumnName("SIREN_architecte");

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.Architectes)
                .HasForeignKey(d => d.IdAdresse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("architecte_ibfk_1");

            entity.HasOne(d => d.IdContactNavigation).WithMany(p => p.Architectes)
                .HasForeignKey(d => d.IdContact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("architecte_ibfk_2");
        });

        modelBuilder.Entity<AvantProjet>(entity =>
        {
            entity.HasKey(e => e.IdAvantProjet).HasName("PRIMARY");

            entity.ToTable("avant_projet");

            entity.HasIndex(e => e.IdPrestation, "ID_prestation");

            entity.HasIndex(e => e.IdSalarie, "ID_salarie");

            entity.HasIndex(e => e.IdStatut, "ID_statut");

            entity.Property(e => e.IdAvantProjet)
                .HasColumnType("int(11)")
                .HasColumnName("ID_avant_projet");
            entity.Property(e => e.DateRendu).HasColumnName("date_rendu");
            entity.Property(e => e.IdPrestation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_prestation");
            entity.Property(e => e.IdSalarie)
                .HasColumnType("int(11)")
                .HasColumnName("ID_salarie");
            entity.Property(e => e.IdStatut)
                .HasColumnType("int(11)")
                .HasColumnName("ID_statut");
            entity.Property(e => e.MtHtTravaux).HasColumnName("mt_HT_travaux");
            entity.Property(e => e.NumAvantProjet)
                .HasColumnType("int(11)")
                .HasColumnName("num_avant_projet");

            entity.HasOne(d => d.IdPrestationNavigation).WithMany(p => p.AvantProjets)
                .HasForeignKey(d => d.IdPrestation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("avant_projet_ibfk_2");

            entity.HasOne(d => d.IdSalarieNavigation).WithMany(p => p.AvantProjets)
                .HasForeignKey(d => d.IdSalarie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("avant_projet_ibfk_1");

            entity.HasOne(d => d.IdStatutNavigation).WithMany(p => p.AvantProjets)
                .HasForeignKey(d => d.IdStatut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("avant_projet_ibfk_3");
        });

        modelBuilder.Entity<Candidature>(entity =>
        {
            entity.HasKey(e => e.IdCandidature).HasName("PRIMARY");

            entity.ToTable("candidature");

            entity.HasIndex(e => e.IdArchitecte, "ID_architecte");

            entity.HasIndex(e => e.IdPrestation, "ID_prestation");

            entity.HasIndex(e => e.IdSalarie, "ID_salarie");

            entity.HasIndex(e => e.IdStatut, "ID_statut");

            entity.HasIndex(e => e.IdStatutExclusivite, "ID_statut_exclusivite");

            entity.Property(e => e.IdCandidature)
                .HasColumnType("int(11)")
                .HasColumnName("ID_candidature");
            entity.Property(e => e.Commentaire)
                .HasMaxLength(255)
                .HasColumnName("commentaire");
            entity.Property(e => e.DateRendu).HasColumnName("date_rendu");
            entity.Property(e => e.Dpi).HasColumnName("DPI");
            entity.Property(e => e.IdArchitecte)
                .HasColumnType("int(11)")
                .HasColumnName("ID_architecte");
            entity.Property(e => e.IdPrestation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_prestation");
            entity.Property(e => e.IdSalarie)
                .HasColumnType("int(11)")
                .HasColumnName("ID_salarie");
            entity.Property(e => e.IdStatut)
                .HasColumnType("int(11)")
                .HasColumnName("ID_statut");
            entity.Property(e => e.IdStatutExclusivite)
                .HasColumnType("int(11)")
                .HasColumnName("ID_statut_exclusivite");
            entity.Property(e => e.MtHtTravaux).HasColumnName("mt_HT_travaux");
            entity.Property(e => e.MtIndemnite).HasColumnName("mt_indemnite");
            entity.Property(e => e.Offre).HasColumnName("offre");
            entity.Property(e => e.Stream).HasColumnName("stream");

            entity.HasOne(d => d.IdArchitecteNavigation).WithMany(p => p.Candidatures)
                .HasForeignKey(d => d.IdArchitecte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("candidature_ibfk_1");

            entity.HasOne(d => d.IdPrestationNavigation).WithMany(p => p.Candidatures)
                .HasForeignKey(d => d.IdPrestation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("candidature_ibfk_2");

            entity.HasOne(d => d.IdSalarieNavigation).WithMany(p => p.Candidatures)
                .HasForeignKey(d => d.IdSalarie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("candidature_ibfk_3");

            entity.HasOne(d => d.IdStatutNavigation).WithMany(p => p.Candidatures)
                .HasForeignKey(d => d.IdStatut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("candidature_ibfk_4");

            entity.HasOne(d => d.IdStatutExclusiviteNavigation).WithMany(p => p.Candidatures)
                .HasForeignKey(d => d.IdStatutExclusivite)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("candidature_ibfk_5");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.IdContact).HasName("PRIMARY");

            entity.ToTable("contact");

            entity.Property(e => e.IdContact)
                .HasColumnType("int(11)")
                .HasColumnName("ID_contact");
            entity.Property(e => e.Commentaires)
                .HasMaxLength(255)
                .HasColumnName("commentaires");
            entity.Property(e => e.ContactType)
                .HasMaxLength(255)
                .HasColumnName("contact_type");
            entity.Property(e => e.Fonction)
                .HasMaxLength(255)
                .HasColumnName("fonction");
            entity.Property(e => e.Mail)
                .HasMaxLength(255)
                .HasColumnName("mail");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(255)
                .HasColumnName("prenom");
            entity.Property(e => e.SalariePrioriteContact)
                .HasMaxLength(255)
                .HasColumnName("salarie_priorite_contact");
            entity.Property(e => e.Tel1)
                .HasMaxLength(255)
                .HasColumnName("tel1");
            entity.Property(e => e.Tel2)
                .HasMaxLength(255)
                .HasColumnName("tel2");
        });

        modelBuilder.Entity<Enfant>(entity =>
        {
            entity.HasKey(e => e.IdEnfant).HasName("PRIMARY");

            entity.ToTable("enfant");

            entity.HasIndex(e => e.IdSalarie, "ID_salarie");

            entity.Property(e => e.IdEnfant)
                .HasColumnType("int(11)")
                .HasColumnName("ID_enfant");
            entity.Property(e => e.DateNaissance).HasColumnName("date_naissance");
            entity.Property(e => e.IdSalarie)
                .HasColumnType("int(11)")
                .HasColumnName("ID_salarie");
            entity.Property(e => e.Prenom)
                .HasMaxLength(255)
                .HasColumnName("prenom");

            entity.HasOne(d => d.IdSalarieNavigation).WithMany(p => p.Enfants)
                .HasForeignKey(d => d.IdSalarie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("enfant_ibfk_1");
        });

        modelBuilder.Entity<EvolutionHonoraire>(entity =>
        {
            entity.HasKey(e => e.IdEvolution).HasName("PRIMARY");

            entity.ToTable("evolution_honoraire");

            entity.HasIndex(e => e.IdPhaseAffectation, "ID_phase_affectation");

            entity.Property(e => e.IdEvolution)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("ID_evolution");
            entity.Property(e => e.Commentaire)
                .HasMaxLength(255)
                .HasColumnName("commentaire");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdPhaseAffectation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_phase_affectation");
            entity.Property(e => e.Montant).HasColumnName("montant");

            entity.HasOne(d => d.IdPhaseAffectationNavigation).WithMany(p => p.EvolutionHonoraires)
                .HasForeignKey(d => d.IdPhaseAffectation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("evolution_honoraire_ibfk_1");
        });

        modelBuilder.Entity<Facture>(entity =>
        {
            entity.HasKey(e => e.IdFacture).HasName("PRIMARY");

            entity.ToTable("facture");

            entity.HasIndex(e => e.IdPhaseAffectation, "ID_phase_affectation");

            entity.Property(e => e.IdFacture)
                .HasColumnType("int(11)")
                .HasColumnName("ID_facture");
            entity.Property(e => e.DateEmission).HasColumnName("date_emission");
            entity.Property(e => e.IdPhaseAffectation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_phase_affectation");
            entity.Property(e => e.Libelle)
                .HasMaxLength(255)
                .HasColumnName("libelle");
            entity.Property(e => e.NumeroFacture)
                .HasColumnType("int(11)")
                .HasColumnName("numero_facture");

            entity.HasOne(d => d.IdPhaseAffectationNavigation).WithMany(p => p.Factures)
                .HasForeignKey(d => d.IdPhaseAffectation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("facture_ibfk_1");
        });

        modelBuilder.Entity<FactureDetail>(entity =>
        {
            entity.HasKey(e => e.IdFactureDetails).HasName("PRIMARY");

            entity.ToTable("facture_details");

            entity.HasIndex(e => e.IdFacture, "ID_facture");

            entity.Property(e => e.IdFactureDetails)
                .HasColumnType("int(11)")
                .HasColumnName("ID_facture_details");
            entity.Property(e => e.IdFacture)
                .HasColumnType("int(11)")
                .HasColumnName("ID_facture");
            entity.Property(e => e.PrixUnitaireHt).HasColumnName("prix_unitaire_HT");
            entity.Property(e => e.Quantite)
                .HasColumnType("int(11)")
                .HasColumnName("quantite");
            entity.Property(e => e.TauxTva).HasColumnName("taux_TVA");

            entity.HasOne(d => d.IdFactureNavigation).WithMany(p => p.FactureDetails)
                .HasForeignKey(d => d.IdFacture)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("facture_details_ibfk_1");
        });

        modelBuilder.Entity<Faisabilite>(entity =>
        {
            entity.HasKey(e => e.IdFaisabilite).HasName("PRIMARY");

            entity.ToTable("faisabilite");

            entity.HasIndex(e => e.IdArchitecture, "ID_architecture");

            entity.HasIndex(e => e.IdPrestation, "ID_prestation");

            entity.HasIndex(e => e.IdStatut, "ID_statut");

            entity.Property(e => e.IdFaisabilite)
                .HasColumnType("int(11)")
                .HasColumnName("ID_faisabilite");
            entity.Property(e => e.DateRendu).HasColumnName("date_rendu");
            entity.Property(e => e.IdArchitecture)
                .HasColumnType("int(11)")
                .HasColumnName("ID_architecture");
            entity.Property(e => e.IdPrestation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_prestation");
            entity.Property(e => e.IdStatut)
                .HasColumnType("int(11)")
                .HasColumnName("ID_statut");

            entity.HasOne(d => d.IdArchitectureNavigation).WithMany(p => p.Faisabilites)
                .HasForeignKey(d => d.IdArchitecture)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("faisabilite_ibfk_3");

            entity.HasOne(d => d.IdPrestationNavigation).WithMany(p => p.Faisabilites)
                .HasForeignKey(d => d.IdPrestation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("faisabilite_ibfk_1");

            entity.HasOne(d => d.IdStatutNavigation).WithMany(p => p.Faisabilites)
                .HasForeignKey(d => d.IdStatut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("faisabilite_ibfk_2");
        });

        modelBuilder.Entity<Fonction>(entity =>
        {
            entity.HasKey(e => e.IdFonction).HasName("PRIMARY");

            entity.ToTable("fonction");

            entity.Property(e => e.IdFonction)
                .HasColumnType("int(11)")
                .HasColumnName("ID_fonction");
            entity.Property(e => e.NomFonction)
                .HasMaxLength(255)
                .HasColumnName("NOM_fonction");
        });

        modelBuilder.Entity<Moa>(entity =>
        {
            entity.HasKey(e => e.IdMoa).HasName("PRIMARY");

            entity.ToTable("moa");

            entity.HasIndex(e => e.IdAdresse, "ID_adresse");

            entity.HasIndex(e => e.IdContact, "ID_contact");

            entity.Property(e => e.IdMoa)
                .HasColumnType("int(11)")
                .HasColumnName("ID_MOA");
            entity.Property(e => e.Commentaires)
                .HasMaxLength(255)
                .HasColumnName("commentaires");
            entity.Property(e => e.FormeJuridique)
                .HasMaxLength(255)
                .HasColumnName("forme_juridique");
            entity.Property(e => e.IdAdresse)
                .HasColumnType("int(11)")
                .HasColumnName("ID_adresse");
            entity.Property(e => e.IdContact)
                .HasColumnType("int(11)")
                .HasColumnName("ID_contact");
            entity.Property(e => e.NomMoa)
                .HasMaxLength(255)
                .HasColumnName("nom_moa");
            entity.Property(e => e.PrenomMoa)
                .HasMaxLength(255)
                .HasColumnName("prenom_moa");
            entity.Property(e => e.RaisonSocial)
                .HasMaxLength(255)
                .HasColumnName("raison_social");
            entity.Property(e => e.SirenMoa)
                .HasMaxLength(255)
                .HasColumnName("SIREN_MOA");

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.Moas)
                .HasForeignKey(d => d.IdAdresse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("moa_ibfk_1");

            entity.HasOne(d => d.IdContactNavigation).WithMany(p => p.Moas)
                .HasForeignKey(d => d.IdContact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("moa_ibfk_2");
        });

        modelBuilder.Entity<Offre>(entity =>
        {
            entity.HasKey(e => e.IdOffre).HasName("PRIMARY");

            entity.ToTable("offre");

            entity.HasIndex(e => e.IdArchitecte, "ID_architecte");

            entity.HasIndex(e => e.IdPrestation, "ID_prestation");

            entity.HasIndex(e => e.IdStatut, "ID_statut");

            entity.Property(e => e.IdOffre)
                .HasColumnType("int(11)")
                .HasColumnName("ID_offre");
            entity.Property(e => e.DateRendu).HasColumnName("date_rendu");
            entity.Property(e => e.IdArchitecte)
                .HasColumnType("int(11)")
                .HasColumnName("ID_architecte");
            entity.Property(e => e.IdPrestation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_prestation");
            entity.Property(e => e.IdStatut)
                .HasColumnType("int(11)")
                .HasColumnName("ID_statut");
            entity.Property(e => e.Libelle)
                .HasMaxLength(255)
                .HasColumnName("libelle");

            entity.HasOne(d => d.IdArchitecteNavigation).WithMany(p => p.Offres)
                .HasForeignKey(d => d.IdArchitecte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offre_ibfk_1");

            entity.HasOne(d => d.IdPrestationNavigation).WithMany(p => p.Offres)
                .HasForeignKey(d => d.IdPrestation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offre_ibfk_2");

            entity.HasOne(d => d.IdStatutNavigation).WithMany(p => p.Offres)
                .HasForeignKey(d => d.IdStatut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offre_ibfk_3");
        });

        modelBuilder.Entity<OffreCandidature>(entity =>
        {
            entity.HasKey(e => e.IdOffreCandidature).HasName("PRIMARY");

            entity.ToTable("offre_candidature");

            entity.HasIndex(e => e.IdCandidature, "ID_candidature");

            entity.HasIndex(e => e.IdOffre, "ID_offre");

            entity.HasIndex(e => e.IdPrestation, "ID_prestation");

            entity.HasIndex(e => e.IdSalarie, "ID_salarie");

            entity.HasIndex(e => e.IdStatut, "ID_statut");

            entity.HasIndex(e => e.IdStatutExclusivite, "ID_statut_exclusivite");

            entity.Property(e => e.IdOffreCandidature)
                .HasColumnType("int(11)")
                .HasColumnName("ID_offre_candidature");
            entity.Property(e => e.Commentaire)
                .HasMaxLength(255)
                .HasColumnName("commentaire");
            entity.Property(e => e.DateRendu).HasColumnName("date_rendu");
            entity.Property(e => e.Dpi).HasColumnName("DPI");
            entity.Property(e => e.IdCandidature)
                .HasColumnType("int(11)")
                .HasColumnName("ID_candidature");
            entity.Property(e => e.IdOffre)
                .HasColumnType("int(11)")
                .HasColumnName("ID_offre");
            entity.Property(e => e.IdPrestation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_prestation");
            entity.Property(e => e.IdSalarie)
                .HasColumnType("int(11)")
                .HasColumnName("ID_salarie");
            entity.Property(e => e.IdStatut)
                .HasColumnType("int(11)")
                .HasColumnName("ID_statut");
            entity.Property(e => e.IdStatutExclusivite)
                .HasColumnType("int(11)")
                .HasColumnName("ID_statut_exclusivite");
            entity.Property(e => e.MtHtTravaux).HasColumnName("mt_HT_travaux");
            entity.Property(e => e.Offres).HasColumnName("offres");
            entity.Property(e => e.Stream).HasColumnName("stream");

            entity.HasOne(d => d.IdCandidatureNavigation).WithMany(p => p.OffreCandidatures)
                .HasForeignKey(d => d.IdCandidature)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offre_candidature_ibfk_1");

            entity.HasOne(d => d.IdOffreNavigation).WithMany(p => p.OffreCandidatures)
                .HasForeignKey(d => d.IdOffre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offre_candidature_ibfk_2");

            entity.HasOne(d => d.IdPrestationNavigation).WithMany(p => p.OffreCandidatures)
                .HasForeignKey(d => d.IdPrestation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offre_candidature_ibfk_3");

            entity.HasOne(d => d.IdSalarieNavigation).WithMany(p => p.OffreCandidatures)
                .HasForeignKey(d => d.IdSalarie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offre_candidature_ibfk_6");

            entity.HasOne(d => d.IdStatutNavigation).WithMany(p => p.OffreCandidatures)
                .HasForeignKey(d => d.IdStatut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offre_candidature_ibfk_5");

            entity.HasOne(d => d.IdStatutExclusiviteNavigation).WithMany(p => p.OffreCandidatures)
                .HasForeignKey(d => d.IdStatutExclusivite)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offre_candidature_ibfk_4");
        });

        modelBuilder.Entity<Paiement>(entity =>
        {
            entity.HasKey(e => e.IdPaiement).HasName("PRIMARY");

            entity.ToTable("paiement");

            entity.HasIndex(e => e.IdFacture, "ID_facture");

            entity.Property(e => e.IdPaiement)
                .HasColumnType("int(11)")
                .HasColumnName("ID_paiement");
            entity.Property(e => e.DatePaiement).HasColumnName("date_paiement");
            entity.Property(e => e.IdFacture)
                .HasColumnType("int(11)")
                .HasColumnName("ID_facture");
            entity.Property(e => e.Libelle)
                .HasMaxLength(255)
                .HasColumnName("libelle");
            entity.Property(e => e.Montant).HasColumnName("montant");

            entity.HasOne(d => d.IdFactureNavigation).WithMany(p => p.Paiements)
                .HasForeignKey(d => d.IdFacture)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paiement_ibfk_1");
        });

        modelBuilder.Entity<Phase>(entity =>
        {
            entity.HasKey(e => e.IdPhase).HasName("PRIMARY");

            entity.ToTable("phase");

            entity.Property(e => e.IdPhase)
                .HasColumnType("int(11)")
                .HasColumnName("ID_phase");
            entity.Property(e => e.Phase1)
                .HasMaxLength(255)
                .HasColumnName("phase");
        });

        modelBuilder.Entity<PhaseAffectation>(entity =>
        {
            entity.HasKey(e => e.IdPhaseAffectation).HasName("PRIMARY");

            entity.ToTable("phase_affectation");

            entity.HasIndex(e => e.IdAffectation, "ID_affectation");

            entity.HasIndex(e => e.IdPhase, "ID_phase");

            entity.HasIndex(e => e.IdPrestation, "ID_prestation");

            entity.HasIndex(e => e.IdStatut, "ID_statut");

            entity.Property(e => e.IdPhaseAffectation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_phase_affectation");
            entity.Property(e => e.DateRendu).HasColumnName("date_rendu");
            entity.Property(e => e.IdAffectation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_affectation");
            entity.Property(e => e.IdPhase)
                .HasColumnType("int(11)")
                .HasColumnName("ID_phase");
            entity.Property(e => e.IdPrestation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_prestation");
            entity.Property(e => e.IdStatut)
                .HasColumnType("int(11)")
                .HasColumnName("ID_statut");
            entity.Property(e => e.TypePrestation)
                .HasMaxLength(255)
                .HasColumnName("type_prestation");

            entity.HasOne(d => d.IdAffectationNavigation).WithMany(p => p.PhaseAffectations)
                .HasForeignKey(d => d.IdAffectation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("phase_affectation_ibfk_2");

            entity.HasOne(d => d.IdPhaseNavigation).WithMany(p => p.PhaseAffectations)
                .HasForeignKey(d => d.IdPhase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("phase_affectation_ibfk_1");

            entity.HasOne(d => d.IdPrestationNavigation).WithMany(p => p.PhaseAffectations)
                .HasForeignKey(d => d.IdPrestation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("phase_affectation_ibfk_3");

            entity.HasOne(d => d.IdStatutNavigation).WithMany(p => p.PhaseAffectations)
                .HasForeignKey(d => d.IdStatut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("phase_affectation_ibfk_4");
        });

        modelBuilder.Entity<Prestation>(entity =>
        {
            entity.HasKey(e => e.IdPrestation).HasName("PRIMARY");

            entity.ToTable("prestation");

            entity.HasIndex(e => e.IdMoa, "ID_moa");

            entity.Property(e => e.IdPrestation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_prestation");
            entity.Property(e => e.IdMoa)
                .HasColumnType("int(11)")
                .HasColumnName("ID_moa");
            entity.Property(e => e.Intitule)
                .HasMaxLength(255)
                .HasColumnName("intitule");
            entity.Property(e => e.SousTraitance)
                .HasMaxLength(255)
                .HasColumnName("sous_traitance");
            entity.Property(e => e.SuperficieChantier).HasColumnName("superficie_chantier");
            entity.Property(e => e.TypeAffaire)
                .HasMaxLength(255)
                .HasColumnName("type_affaire");
            entity.Property(e => e.Typologie)
                .HasMaxLength(255)
                .HasColumnName("typologie");

            entity.HasOne(d => d.IdMoaNavigation).WithMany(p => p.Prestations)
                .HasForeignKey(d => d.IdMoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prestation_ibfk_1");
        });

        modelBuilder.Entity<Projet>(entity =>
        {
            entity.HasKey(e => e.IdProjet).HasName("PRIMARY");

            entity.ToTable("projet");

            entity.HasIndex(e => e.IdAvantProjet, "ID_avant_projet");

            entity.HasIndex(e => e.IdPrestation, "ID_prestation");

            entity.HasIndex(e => e.IdSalarie, "ID_salarie");

            entity.HasIndex(e => e.IdStatut, "ID_statut");

            entity.Property(e => e.IdProjet)
                .HasColumnType("int(11)")
                .HasColumnName("ID_projet");
            entity.Property(e => e.DateRendu).HasColumnName("date_rendu");
            entity.Property(e => e.IdAvantProjet)
                .HasColumnType("int(11)")
                .HasColumnName("ID_avant_projet");
            entity.Property(e => e.IdPrestation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_prestation");
            entity.Property(e => e.IdSalarie)
                .HasColumnType("int(11)")
                .HasColumnName("ID_salarie");
            entity.Property(e => e.IdStatut)
                .HasColumnType("int(11)")
                .HasColumnName("ID_statut");
            entity.Property(e => e.MtHtTravaux).HasColumnName("mt_HT_travaux");
            entity.Property(e => e.NumProjet)
                .HasColumnType("int(11)")
                .HasColumnName("num_projet");

            entity.HasOne(d => d.IdAvantProjetNavigation).WithMany(p => p.Projets)
                .HasForeignKey(d => d.IdAvantProjet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projet_ibfk_3");

            entity.HasOne(d => d.IdPrestationNavigation).WithMany(p => p.Projets)
                .HasForeignKey(d => d.IdPrestation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projet_ibfk_2");

            entity.HasOne(d => d.IdSalarieNavigation).WithMany(p => p.Projets)
                .HasForeignKey(d => d.IdSalarie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projet_ibfk_4");

            entity.HasOne(d => d.IdStatutNavigation).WithMany(p => p.Projets)
                .HasForeignKey(d => d.IdStatut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projet_ibfk_1");
        });

        modelBuilder.Entity<PropositonHonoraire>(entity =>
        {
            entity.HasKey(e => e.IdProposition).HasName("PRIMARY");

            entity.ToTable("propositon_honoraire");

            entity.HasIndex(e => e.IdPhaseAffectation, "ID_phase_affectation");

            entity.HasIndex(e => e.IdPrestation, "ID_prestation");

            entity.HasIndex(e => e.IdStatut, "ID_statut");

            entity.Property(e => e.IdProposition)
                .HasColumnType("int(11)")
                .HasColumnName("ID_proposition");
            entity.Property(e => e.Commentaire)
                .HasMaxLength(255)
                .HasColumnName("commentaire");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdPhaseAffectation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_phase_affectation");
            entity.Property(e => e.IdPrestation)
                .HasColumnType("int(11)")
                .HasColumnName("ID_prestation");
            entity.Property(e => e.IdStatut)
                .HasColumnType("int(11)")
                .HasColumnName("ID_statut");

            entity.HasOne(d => d.IdPhaseAffectationNavigation).WithMany(p => p.PropositonHonoraires)
                .HasForeignKey(d => d.IdPhaseAffectation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("propositon_honoraire_ibfk_1");

            entity.HasOne(d => d.IdPrestationNavigation).WithMany(p => p.PropositonHonoraires)
                .HasForeignKey(d => d.IdPrestation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("propositon_honoraire_ibfk_2");

            entity.HasOne(d => d.IdStatutNavigation).WithMany(p => p.PropositonHonoraires)
                .HasForeignKey(d => d.IdStatut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("propositon_honoraire_ibfk_3");
        });

        modelBuilder.Entity<Salaire>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("salaire");

            entity.HasIndex(e => e.IdFonction, "ID_fonction");

            entity.HasIndex(e => e.IdSalarie, "ID_salarie");

            entity.HasIndex(e => e.IdService, "ID_service");

            entity.Property(e => e.Commentaires)
                .HasMaxLength(255)
                .HasColumnName("commentaires");
            entity.Property(e => e.DatePaiement).HasColumnName("date_paiement");
            entity.Property(e => e.IdFonction)
                .HasColumnType("int(11)")
                .HasColumnName("ID_fonction");
            entity.Property(e => e.IdSalaire)
                .HasColumnType("int(11)")
                .HasColumnName("ID_salaire");
            entity.Property(e => e.IdSalarie)
                .HasColumnType("int(11)")
                .HasColumnName("ID_salarie");
            entity.Property(e => e.IdService)
                .HasColumnType("int(11)")
                .HasColumnName("ID_service");
            entity.Property(e => e.MtBrutAnnuel).HasColumnName("mt_brut_annuel");
            entity.Property(e => e.NbrHeuresContrat)
                .HasColumnType("int(11)")
                .HasColumnName("nbr_heures_contrat");

            entity.HasOne(d => d.IdFonctionNavigation).WithMany()
                .HasForeignKey(d => d.IdFonction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("salaire_ibfk_2");

            entity.HasOne(d => d.IdSalarieNavigation).WithMany()
                .HasForeignKey(d => d.IdSalarie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("salaire_ibfk_1");

            entity.HasOne(d => d.IdServiceNavigation).WithMany()
                .HasForeignKey(d => d.IdService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("salaire_ibfk_3");
        });

        modelBuilder.Entity<Salarie>(entity =>
        {
            entity.HasKey(e => e.IdSalarie).HasName("PRIMARY");

            entity.ToTable("salarie");

            entity.HasIndex(e => e.IdAdresse, "ID_adresse");

            entity.HasIndex(e => e.IdAgence, "ID_agence");

            entity.HasIndex(e => e.IdContact, "ID_contact");

            entity.Property(e => e.IdSalarie)
                .HasColumnType("int(11)")
                .HasColumnName("ID_salarie");
            entity.Property(e => e.Commentaires)
                .HasMaxLength(255)
                .HasColumnName("commentaires");
            entity.Property(e => e.DateNaissance).HasColumnName("Date_naissance");
            entity.Property(e => e.Genre)
                .HasMaxLength(255)
                .HasColumnName("genre");
            entity.Property(e => e.IdAdresse)
                .HasColumnType("int(11)")
                .HasColumnName("ID_adresse");
            entity.Property(e => e.IdAgence)
                .HasColumnType("int(11)")
                .HasColumnName("ID_agence");
            entity.Property(e => e.IdContact)
                .HasColumnType("int(11)")
                .HasColumnName("ID_contact");
            entity.Property(e => e.Mail)
                .HasMaxLength(255)
                .HasColumnName("mail");
            entity.Property(e => e.NomSalarie)
                .HasMaxLength(255)
                .HasColumnName("nom_salarie");
            entity.Property(e => e.NumSecuriteSociale)
                .HasMaxLength(255)
                .HasColumnName("Num_securite_sociale");
            entity.Property(e => e.Permis).HasMaxLength(255);
            entity.Property(e => e.PrenomSalarie)
                .HasMaxLength(255)
                .HasColumnName("prenom_salarie");
            entity.Property(e => e.Statut)
                .HasMaxLength(255)
                .HasColumnName("statut");
            entity.Property(e => e.TelephoneFixe)
                .HasMaxLength(255)
                .HasColumnName("telephone_fixe");
            entity.Property(e => e.TelephonePortable)
                .HasMaxLength(255)
                .HasColumnName("telephone_portable");

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.IdAdresse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("salarie_ibfk_2");

            entity.HasOne(d => d.IdAgenceNavigation).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.IdAgence)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("salarie_ibfk_1");

            entity.HasOne(d => d.IdContactNavigation).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.IdContact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("salarie_ibfk_3");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdService).HasName("PRIMARY");

            entity.ToTable("service");

            entity.Property(e => e.IdService)
                .HasColumnType("int(11)")
                .HasColumnName("ID_service");
            entity.Property(e => e.NomService)
                .HasMaxLength(255)
                .HasColumnName("NOM_service");
        });

        modelBuilder.Entity<Statut>(entity =>
        {
            entity.HasKey(e => e.IdStatut).HasName("PRIMARY");

            entity.ToTable("statut");

            entity.Property(e => e.IdStatut)
                .HasColumnType("int(11)")
                .HasColumnName("ID_statut");
            entity.Property(e => e.Statut1)
                .HasMaxLength(255)
                .HasColumnName("statut");
        });

        modelBuilder.Entity<StatutExclusivite>(entity =>
        {
            entity.HasKey(e => e.IdStatutExclusivite).HasName("PRIMARY");

            entity.ToTable("statut_exclusivite");

            entity.Property(e => e.IdStatutExclusivite)
                .HasColumnType("int(11)")
                .HasColumnName("ID_statut_exclusivite");
            entity.Property(e => e.StatutExclusivite1)
                .HasMaxLength(255)
                .HasColumnName("statut_exclusivite");
        });

        modelBuilder.Entity<TypeAbsence>(entity =>
        {
            entity.HasKey(e => e.IdTypeAbsence).HasName("PRIMARY");

            entity.ToTable("type_absence");

            entity.Property(e => e.IdTypeAbsence)
                .HasColumnType("int(11)")
                .HasColumnName("ID_type_absence");
            entity.Property(e => e.TypeAbsence1)
                .HasMaxLength(255)
                .HasColumnName("type_absence");
        });

        modelBuilder.Entity<Vehicule>(entity =>
        {
            entity.HasKey(e => e.IdVehicule).HasName("PRIMARY");

            entity.ToTable("vehicule");

            entity.HasIndex(e => e.IdSalarie, "ID_salarie");

            entity.Property(e => e.IdVehicule)
                .HasColumnType("int(11)")
                .HasColumnName("ID_vehicule");
            entity.Property(e => e.Assureur)
                .HasMaxLength(255)
                .HasColumnName("assureur");
            entity.Property(e => e.IdSalarie)
                .HasColumnType("int(11)")
                .HasColumnName("ID_salarie");
            entity.Property(e => e.NumeroContratAssureur)
                .HasMaxLength(255)
                .HasColumnName("numero_contrat_assureur");
            entity.Property(e => e.NumeroImmatriculation)
                .HasMaxLength(255)
                .HasColumnName("numero_immatriculation");

            entity.HasOne(d => d.IdSalarieNavigation).WithMany(p => p.Vehicules)
                .HasForeignKey(d => d.IdSalarie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vehicule_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

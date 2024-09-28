using StageApp.Models;

namespace StageApp.DTO
{
    public class CandidatureDto
    {
        public int IdCandidature { get; set; }
        public string DateRendu { get; set; }
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

        public CandidatureDto() { }
        public CandidatureDto(int idCandidature, string dateRendu, double mtIndemnite, double mtHtTravaux, bool stream, bool offre, bool dpi, int idStatut, int idSalarie, int idPrestation, int idArchitecte, int idStatutExclusivite, string commentaire)
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
    

}
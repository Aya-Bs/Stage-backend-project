namespace StageApp.DTO
{
    public class ArchitecteDto
    {
       // public int IdArchitecte { get; set; }
        public string RaisonSocial { get; set; } = null!;
        public string NomArchitecte { get; set; } = null!;
        public string PrenomArchitecte { get; set; } = null!;
        public int IdAdresse { get; set; }
        public string SirenArchitecte { get; set; } = null!;
        public int IdContact { get; set; }
        public ArchitecteDto() { }
        public ArchitecteDto( string raisonSocial, string nomArchitecte, string prenomArchitecte, int idAdresse, string sirenArchitecte, int idContact)
        {
            
            RaisonSocial = raisonSocial;
            NomArchitecte = nomArchitecte;
            PrenomArchitecte = prenomArchitecte;
            IdAdresse = idAdresse;
            SirenArchitecte = sirenArchitecte;
            IdContact = idContact;
        }
    }
}

namespace StageApp.DTO
{
    public class AdresseDto
    {
        //adresse dto
        //public int Id { get; set; }
        public string Adresse1 { get; set; } = null!;
        public string CodePostal { get; set; } = null!;
        public string Ville { get; set; } = null!;
        public AdresseDto() { }
        public AdresseDto( string adresse1, string codePostal, string ville)
        {
           // Id = id;
            Adresse1 = adresse1;
            CodePostal = codePostal;
            Ville = ville;
        }
    }
}

namespace StageApp.DTO
{
    public class ContactDto
    {
        //public int IdContact { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Mail { get; set; }
        public string ContactType { get; set; }
        public string? Fonction { get; set; }
        public string? SalariePrioriteContact { get; set; }
        public string? Commentaires { get; set; }
        //constructor
        public ContactDto() { }
        public ContactDto( string nom, string prenom, string tel1, string tel2, string mail, string contactType, string? fonction, string? salariePrioriteContact, string? commentaires)
        {
            //IdContact = idContact;
            Nom = nom;
            Prenom = prenom;
            Tel1 = tel1;
            Tel2 = tel2;
            Mail = mail;
            ContactType = contactType;
            Fonction = fonction;
            SalariePrioriteContact = salariePrioriteContact;
            Commentaires = commentaires;
        }
    }
}

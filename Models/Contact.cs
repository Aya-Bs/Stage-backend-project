using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Contact
{
    public int IdContact { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Tel1 { get; set; } = null!;

    public string Tel2 { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string ContactType { get; set; } = null!;

    public string? Fonction { get; set; }

    public string? SalariePrioriteContact { get; set; }

    public string? Commentaires { get; set; }

    public virtual ICollection<Architecte> Architectes { get; set; } = new List<Architecte>();

    public virtual ICollection<Moa> Moas { get; set; } = new List<Moa>();

    public virtual ICollection<Salarie> Salaries { get; set; } = new List<Salarie>();
    //constructeur par défaut
    public Contact() { }
    //constructeur avec paramètres
       public Contact(int idContact, string nom, string prenom, string tel1, string tel2, string mail, string contactType, string? fonction, string? salariePrioriteContact, string? commentaires)
    {
        IdContact = idContact;
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

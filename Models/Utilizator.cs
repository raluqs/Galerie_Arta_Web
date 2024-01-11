using System.ComponentModel.DataAnnotations;

namespace Galerie_Arta_Web.Models
{
    public class Utilizator
    {
        public int Id { get; set; }

  
        public string? Name { get; set; }


        public string? Prenume { get; set; }


        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "Numărul de telefon trebuie să conțină doar cifre.")]
        [MaxLength(11, ErrorMessage = "Numărul de telefon trebuie să aibă maximum 10 cifre.")]
        public string? Nr_telefon { get; set; }

        public string Email { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return Name + " " + Prenume;
            }
        }
        public ICollection<Programare>? Programari { get; set; } //navigation property
    }
}


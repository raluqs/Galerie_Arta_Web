using System.ComponentModel.DataAnnotations;

namespace Galerie_Arta_Web.Models
{
    public class Utilizator
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z][a-z]*\s?[A-Z]?[a-z]*$", ErrorMessage =
            "Numele trebuie să înceapă cu majusculă (ex. Popescu sau Popescu Micu)")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]*\s?[A-Z]?[a-z]*$", ErrorMessage =
            "Prenumele trebuie să înceapă cu majusculă (ex. Ana sau Ana Maria)")]
        [StringLength(50, MinimumLength = 3)]
        public string Prenume { get; set; }


        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "Numărul de telefon trebuie să conțină doar cifre.")]
        [MaxLength(11, ErrorMessage = "Numărul de telefon trebuie să aibă maximum 10 cifre.")]
        public string Nr_telefon { get; set; }

        public string Email { get; set; }
        public Utilizator()
        {
            Email = "";
        }

        public ICollection<Programare>? Programari { get; set; } //navigation property
    }
}


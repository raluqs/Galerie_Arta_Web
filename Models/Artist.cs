using System.ComponentModel.DataAnnotations;

namespace Galerie_Arta_Web.Models
{
    public class Artist
    {

        public int ID { get; set; }

        [RegularExpression(@"^[A-Z][a-z]*\s?[A-Z]?[a-z]*$", ErrorMessage =
            "Numele trebuie să înceapă cu majusculă (ex. Popescu sau Popescu Micu)")]
        [StringLength(50, MinimumLength = 3)]
        public string Nume { get; set; }

        [RegularExpression(@"^[A-Z][a-z]*\s?[A-Z]?[a-z]*$", ErrorMessage =
            "Prenumele trebuie să înceapă cu majusculă (ex. Ana sau Ana Maria)")]
        [StringLength(50, MinimumLength = 3)]
        public string Prenume { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNasterii { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataDeces { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string Nationalitate { get; set; }

        public ICollection<Tablou>? Tablouri { get; set; }//navigation property
        [Display(Name = "Nume")]

        public string? Nume_Complet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Galerie_Arta_Web.Models
{
    public class Tablou
    {
        public int ID { get; set; }
        public string Denumire { get; set; }

        [Display(Name = "Data la care a fost finalizat")]
        public DateTime Data_realizare { get; set; }

        [NotMapped]
        public string DataRealizareFormatata
        {
            get
            {
                return Data_realizare.ToString("MMMM yyyy", new CultureInfo("ro-RO"));
            }
        }
        [RegularExpression(@"^\d{1,4}x\d{1,4}$",
            ErrorMessage = "Formatul dimensiunii trebuie să fie de forma 'Lungime x Lățime' (de exemplu, 50x50).")]
        public string Dimensiune { get; set; }

        [Display(Name = "Pret(EUR)")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        public string Descriere { get; set; }

        [RegularExpression(@"^.*\.(png|jpg)$", ErrorMessage =
            "Imaginea trebuie să fie de tipul '.png' sau '.jpg'.")]
        public string Imagine { get; set; }

        public int? ArtistID { get; set; } //cheie straina

        public Artist? Artist { get; set; }//navigation propperty

    

        public ICollection<Programare>? Programari { get; set; }//navigation property

    }
}
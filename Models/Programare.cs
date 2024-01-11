using System.Security.Policy;

namespace Galerie_Arta_Web.Models
{
    public class Programare
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }


        public int? TablouID { get; set; } //cheie straina
        public Tablou? Tablou { get; set; } //navigation property

        public int? UtilizatorID { get; set; }
        public Utilizator? Utilizator { get; set; } //navigation property

    }
}

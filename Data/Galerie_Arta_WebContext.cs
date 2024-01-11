using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Galerie_Arta_Web.Models;

namespace Galerie_Arta_Web.Data
{
    public class Galerie_Arta_WebContext : DbContext
    {
        public Galerie_Arta_WebContext (DbContextOptions<Galerie_Arta_WebContext> options)
            : base(options)
        {
        }

        public DbSet<Galerie_Arta_Web.Models.Artist> Artist { get; set; } = default!;

        public DbSet<Galerie_Arta_Web.Models.Programare>? Programare { get; set; }

        public DbSet<Galerie_Arta_Web.Models.Tablou>? Tablou { get; set; }

        public DbSet<Galerie_Arta_Web.Models.Utilizator>? Utilizator { get; set; }
    }
}

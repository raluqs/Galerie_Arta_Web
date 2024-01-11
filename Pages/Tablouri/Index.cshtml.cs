using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Galerie_Arta_Web.Data;
using Galerie_Arta_Web.Models;

namespace Galerie_Arta_Web.Pages.Tablouri
{
    public class IndexModel : PageModel
    {
        private readonly Galerie_Arta_Web.Data.Galerie_Arta_WebContext _context;

        public IndexModel(Galerie_Arta_Web.Data.Galerie_Arta_WebContext context)
        {
            _context = context;
        }

        public IList<Tablou> Tablou { get;set; } = default!;
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            IQueryable<Tablou> tablouriQuery = from t in _context.Tablou
                                               .Include(t => t.Artist)
                                               select t;

            switch (sortOrder)
            {
                case "price_desc":
                    tablouriQuery = tablouriQuery.OrderByDescending(t => t.Pret);
                    break;
                case "price_asc":
                default:
                    tablouriQuery = tablouriQuery.OrderBy(t => t.Pret);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                tablouriQuery = tablouriQuery.Where(t => t.Denumire.Contains(searchString)
                                           || (t.Artist.Nume + " " + t.Artist.Prenume).Contains(searchString));
            }

            Tablou = await tablouriQuery.ToListAsync();
        }
    }
}

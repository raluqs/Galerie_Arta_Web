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

        public async Task OnGetAsync()
        {
            if (_context.Tablou != null)
            {
                Tablou = await _context.Tablou
                .Include(t => t.Artist).ToListAsync();
            }
        }
    }
}

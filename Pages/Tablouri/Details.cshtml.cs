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
    public class DetailsModel : PageModel
    {
        private readonly Galerie_Arta_Web.Data.Galerie_Arta_WebContext _context;

        public DetailsModel(Galerie_Arta_Web.Data.Galerie_Arta_WebContext context)
        {
            _context = context;
        }

      public Tablou Tablou { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tablou == null)
            {
                return NotFound();
            }

            var tablou = await _context.Tablou.FirstOrDefaultAsync(m => m.ID == id);
            if (tablou == null)
            {
                return NotFound();
            }
            else 
            {
                Tablou = tablou;
            }
            return Page();
        }
    }
}

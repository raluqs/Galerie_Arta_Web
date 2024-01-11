using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Galerie_Arta_Web.Data;
using Galerie_Arta_Web.Models;

namespace Galerie_Arta_Web.Pages.Utilizatori
{
    public class DeleteModel : PageModel
    {
        private readonly Galerie_Arta_Web.Data.Galerie_Arta_WebContext _context;

        public DeleteModel(Galerie_Arta_Web.Data.Galerie_Arta_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Utilizator Utilizator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Utilizator == null)
            {
                return NotFound();
            }

            var utilizator = await _context.Utilizator.FirstOrDefaultAsync(m => m.Id == id);

            if (utilizator == null)
            {
                return NotFound();
            }
            else 
            {
                Utilizator = utilizator;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Utilizator == null)
            {
                return NotFound();
            }
            var utilizator = await _context.Utilizator.FindAsync(id);

            if (utilizator != null)
            {
                Utilizator = utilizator;
                _context.Utilizator.Remove(Utilizator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

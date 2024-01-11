using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Galerie_Arta_Web.Data;
using Galerie_Arta_Web.Models;

namespace Galerie_Arta_Web.Pages.Tablouri
{
    public class EditModel : PageModel
    {
        private readonly Galerie_Arta_Web.Data.Galerie_Arta_WebContext _context;

        public EditModel(Galerie_Arta_Web.Data.Galerie_Arta_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tablou Tablou { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tablou == null)
            {
                return NotFound();
            }

            var tablou =  await _context.Tablou.FirstOrDefaultAsync(m => m.ID == id);
            if (tablou == null)
            {
                return NotFound();
            }
            Tablou = tablou;
            ViewData["ArtistID"] = new SelectList(_context.Artist, "ID", "Nume_Complet");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tablou).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TablouExists(Tablou.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TablouExists(int id)
        {
          return (_context.Tablou?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

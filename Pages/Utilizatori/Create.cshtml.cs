using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Galerie_Arta_Web.Data;
using Galerie_Arta_Web.Models;

namespace Galerie_Arta_Web.Pages.Utilizatori
{
    public class CreateModel : PageModel
    {
        private readonly Galerie_Arta_Web.Data.Galerie_Arta_WebContext _context;

        public CreateModel(Galerie_Arta_Web.Data.Galerie_Arta_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Utilizator Utilizator { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Utilizator == null || Utilizator == null)
            {
                return Page();
            }

            _context.Utilizator.Add(Utilizator);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

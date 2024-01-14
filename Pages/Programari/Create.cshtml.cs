using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Galerie_Arta_Web.Data;
using Galerie_Arta_Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Galerie_Arta_Web.Pages.Programari
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Galerie_Arta_Web.Data.Galerie_Arta_WebContext _context;

        public CreateModel(Galerie_Arta_Web.Data.Galerie_Arta_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TablouID"] = new SelectList(_context.Tablou, "ID", "Denumire");
            ViewData["UtilizatorID"] = new SelectList(_context.Utilizator, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; } = default!;

        private DateTime RoundToNearestHalfHour(DateTime dt)
        {
            int minute = dt.Minute;
            int minuteRounded = minute < 30 ? 0 : 30;
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, minuteRounded, 0);
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Programare == null || Programare == null)
            {
                return Page();
            }
            // Rotunjește timpul programării la cea mai apropiată jumătate de oră
            Programare.Data = RoundToNearestHalfHour(Programare.Data);

            // Verifică dacă există deja o programare la aceeași dată și oră
            if (_context.Programare.Any(p => p.Data == Programare.Data))
            {
                ModelState.AddModelError("Programare.Data", "Există deja o programare la această dată și oră.");
                return Page();
            }


            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
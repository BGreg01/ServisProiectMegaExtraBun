using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Servis.Data;
using Servis.Models;

namespace Servis.Pages.Cars.Origines
{
    public class DeleteModel : PageModel
    {
        private readonly Servis.Data.ServisContext _context;

        public DeleteModel(Servis.Data.ServisContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Origine Origine { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origine = await _context.Origine.FirstOrDefaultAsync(m => m.ID == id);

            if (origine == null)
            {
                return NotFound();
            }
            else
            {
                Origine = origine;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origine = await _context.Origine.FindAsync(id);
            if (origine != null)
            {
                Origine = origine;
                _context.Origine.Remove(Origine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

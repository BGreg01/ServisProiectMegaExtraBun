using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Servis.Data;
using Servis.Models;

namespace Servis.Pages.Mecanics
{
    public class DeleteModel : PageModel
    {
        private readonly Servis.Data.ServisContext _context;

        public DeleteModel(Servis.Data.ServisContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mecanic Mecanic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mecanic = await _context.Mecanic.FirstOrDefaultAsync(m => m.ID == id);

            if (mecanic == null)
            {
                return NotFound();
            }
            else
            {
                Mecanic = mecanic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mecanic = await _context.Mecanic.FindAsync(id);
            if (mecanic != null)
            {
                Mecanic = mecanic;
                _context.Mecanic.Remove(Mecanic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

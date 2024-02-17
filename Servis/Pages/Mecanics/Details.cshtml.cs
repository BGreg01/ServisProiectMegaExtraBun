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
    public class DetailsModel : PageModel
    {
        private readonly Servis.Data.ServisContext _context;

        public DetailsModel(Servis.Data.ServisContext context)
        {
            _context = context;
        }

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
    }
}

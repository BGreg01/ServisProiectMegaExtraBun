using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servis.Data;
using Servis.Models;

namespace Servis.Pages.Mecanics
{
    public class CreateModel : PageModel
    {
        private readonly Servis.Data.ServisContext _context;

        public CreateModel(Servis.Data.ServisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Mecanic Mecanic { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mecanic.Add(Mecanic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

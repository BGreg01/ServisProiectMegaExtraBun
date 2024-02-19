using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servis.Data;
using Servis.Models;

namespace Servis.Pages.Cars
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
            ViewData["MecanicID"] = new SelectList(_context.Set<Mecanic>(), "ID",
 "MecanicName");


            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Servis.Data;
using Servis.Models;

namespace Servis.Pages.Cars.Origines
{
    public class EditModel : CarsOriginesPageModel
    {
        private readonly Servis.Data.ServisContext _context;

        public EditModel(Servis.Data.ServisContext context)
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

            var origine =  await _context.Origine.FirstOrDefaultAsync(m => m.ID == id);
            if (origine == null)
            {
                return NotFound();
            }
            Origine = origine;
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

            _context.Attach(Origine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrigineExists(Origine.ID))
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

        private bool OrigineExists(int id)
        {
            return _context.Origine.Any(e => e.ID == id);
        }
    }
}

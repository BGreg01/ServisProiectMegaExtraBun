using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Servis.Data;
using Servis.Models;


namespace Servis.Pages.Cars
{
    public class EditModel :CarsOriginesPageModel
    {
        private readonly Servis.Data.ServisContext _context;

        public EditModel(Servis.Data.ServisContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Car = await _context.Car

.Include(b => b.Mecanic)
 .Include(b => b.CarOrigines).ThenInclude(b => b.Origine)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            var car =  await _context.Car.FirstOrDefaultAsync(m => m.ID == id);
            if (car == null)
            {
                return NotFound();
            }
            Car = car;
            PopulateAssignedOrigineData(_context, Car);
            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedOrigines)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _context.Attach(Car).State = EntityState.Modified;

         
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            ViewData["MecanicID"] = new SelectList(_context.Set<Mecanic>(), "ID",
"MecanicName");

            return RedirectToPage("./Index");
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.ID == id);
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly Servis.Data.ServisContext _context;

        public IndexModel(Servis.Data.ServisContext context)
        {
            _context = context;
        }

        public IList<Origine> Origine { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Origine = await _context.Origine.ToListAsync();
        }
    }
}

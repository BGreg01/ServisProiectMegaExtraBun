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
    public class IndexModel : PageModel
    {
        private readonly Servis.Data.ServisContext _context;

        public IndexModel(Servis.Data.ServisContext context)
        {
            _context = context;
        }

        public IList<Mecanic> Mecanic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Mecanic = await _context.Mecanic.ToListAsync();
        }
    }
}

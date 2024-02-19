using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Servis.Models;

namespace Servis.Data
{
    public class ServisContext : DbContext
    {
        public ServisContext (DbContextOptions<ServisContext> options)
            : base(options)
        {
        }

        public DbSet<Servis.Models.Car> Car { get; set; } = default!;
        public DbSet<Servis.Models.Origine> Origine { get; set; } = default!;
        public DbSet<Servis.Models.Mecanic> Mecanic { get; set; } = default!;

    }
}

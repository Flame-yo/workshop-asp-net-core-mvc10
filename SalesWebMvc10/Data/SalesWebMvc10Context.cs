using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc10.Models;

namespace SalesWebMvc10.Data
{
    public class SalesWebMvc10Context : DbContext
    {
        public SalesWebMvc10Context (DbContextOptions<SalesWebMvc10Context> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}

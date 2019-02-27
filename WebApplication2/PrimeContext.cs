using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class PrimeContext : DbContext
    {
        public PrimeContext(DbContextOptions<PrimeContext> options)
            : base(options)
        { }

        public DbSet<Prime> Primes { get; set; }
    }

    public class Prime
    {
        [Key]
        public int Id { get; set; }
        public int Index { get; set; }
        public int Value { get; set; }
    }
}

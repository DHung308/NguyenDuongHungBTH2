using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NguyenDuongHungBTH2.Models;

    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext (DbContextOptions<ApplicationDbcontext> options)
            : base(options)
        {
        }

        public DbSet<NguyenDuongHungBTH2.Models.Student> Student { get; set; } = default!;

        public DbSet<NguyenDuongHungBTH2.Models.Person>? Person { get; set; }

        public DbSet<NguyenDuongHungBTH2.Models.Employee>? Employee { get; set; }

        public DbSet<NguyenDuongHungBTH2.Models.Customer>? Customer { get; set; }
    }

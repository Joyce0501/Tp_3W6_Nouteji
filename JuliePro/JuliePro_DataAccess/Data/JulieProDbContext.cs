using JuliePro_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Data
{
    public class JulieProDbContext: DbContext
    {
        public JulieProDbContext(DbContextOptions<JulieProDbContext> options) : base(options)
        {

        }

        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Objective> Objective { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Trainer: clé composée (composite key)
            modelBuilder.Entity<Trainer>().HasKey(tr => new { tr.Customer_Id, tr.Objective_Id });

        }


    }
}

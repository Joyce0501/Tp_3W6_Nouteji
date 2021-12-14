using JuliePro_Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Data
{
    public class JulieProDbContext : IdentityDbContext
    {
        public JulieProDbContext(DbContextOptions<JulieProDbContext> options) : base(options) { }

        public DbSet<Trainer> Trainer { get; set; }

        public DbSet<Speciality> Speciality { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Objective> Objective { get; set; }

        public DbSet<ScheduledSession> ScheduledSession { get; set; }

        public DbSet<Training> Training { get; set; }

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<TrainingEquipment> TrainingEquipment { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<CalendarEvent> Event { get; set; }

        public DbSet<Certification> Certification { get; set; }

        public DbSet<TrainerCertification> TrainerCertification { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Corriger Erreur lors de la migration: IdentityUserLogin
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrainingEquipment>().HasKey(te => new { te.Training_Id, te.Equipment_Id });
            modelBuilder.Entity<TrainerCertification>().HasKey(tc => new { tc.Trainer_Id, tc.Certification_Id });


            //Générer des données de départ
            modelBuilder.GenerateData();
    }
  }
}

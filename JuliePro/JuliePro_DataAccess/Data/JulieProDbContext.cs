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

        public DbSet<ScheduledSession> ScheduledSession { get; set; }

        public DbSet<Training> Training{ get; set; }

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<TrainingEquipment> TrainingEquipment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TrainingEquipment : clé composée (composite key)
            modelBuilder.Entity<TrainingEquipment>().HasKey(te => new { te.Training_Id, te.Equipment_Id });

            //Générer des données de départ
            modelBuilder.GenerateData();

        }


    }
}

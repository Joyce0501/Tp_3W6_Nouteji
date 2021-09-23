﻿using JuliePro_Models.Models;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration fluent API

            //composite key

          //  modelBuilder.Entity<AuthorBook>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });
        }
    }
}

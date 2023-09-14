using Data.Mapping;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<PatientsEntity> Patients { get; set; }
        public MyContext(DbContextOptions<MyContext> options): base(options) {  }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<PatientsEntity>(new PatientsMapping().Configure);
        }
    }
}

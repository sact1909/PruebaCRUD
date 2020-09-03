using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDExam.Data.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-1QDB0MI\\PCSQLSERVER;Database=TestPermissions;Trusted_Connection=True;");
            }
        }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionType>().HasData(
                new PermissionType
                {
                    ID = 1,
                    Description = "Enfermedad"
                },
                new PermissionType
                {
                    ID = 2,
                    Description = "Diligencias"
                },
                new PermissionType
                {
                    ID = 3,
                    Description = "Descanso"
                }
           );
        }
    }
}

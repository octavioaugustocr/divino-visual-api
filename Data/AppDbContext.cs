using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using divino_visual_api.Models;
using Microsoft.EntityFrameworkCore;

namespace divino_visual_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<ServiceProfessional> ServicesProfessional { get; set; }
        public DbSet<ProfessionalAgenda> ProfessionalAgenda { get; set; }
        public DbSet<Scheduling> Scheduling { get; set; }
        public DbSet<SchedulingService> SchedulingServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salon>().OwnsOne(s => s.Address);

            modelBuilder.Entity<Salon>(builder =>
            {
                builder.OwnsOne(s => s.Address, sa =>
                {
                    sa.Property(a => a.Cep).HasColumnName("CEP");
                    sa.Property(a => a.Street).HasColumnName("Street");
                    sa.Property(a => a.Number).HasColumnName("Number");
                    sa.Property(a => a.Neighborhood).HasColumnName("Neighborhood");
                    sa.Property(a => a.City).HasColumnName("City");
                    sa.Property(a => a.State).HasColumnName("State");
                    sa.Property(a => a.UF).HasColumnName("UF");
                });
            });

            modelBuilder.Entity<Service>(entity => entity.Property(s => s.Price).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<Scheduling>(entity => entity.Property(s => s.TotalValue).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<SchedulingService>(entity => entity.Property(s => s.ServicePrice).HasColumnType("decimal(18,2)"));
        }
    }
}
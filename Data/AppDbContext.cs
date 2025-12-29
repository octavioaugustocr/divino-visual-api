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

        public DbSet<UserModel> Users { get; set; }
        public DbSet<SalonModel> Salons { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<ProfessionalModel> Professionals { get; set; }
        public DbSet<ServiceProfessionalModel> ServicesProfessional { get; set; }
        public DbSet<ProfessionalAgendaModel> ProfessionalAgenda { get; set; }
        public DbSet<SchedulingModel> Scheduling { get; set; }
        public DbSet<SchedulingServiceModel> SchedulingServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalonModel>().OwnsOne(s => s.Address);

            modelBuilder.Entity<SalonModel>(builder =>
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

            modelBuilder.Entity<ServiceModel>(entity => entity.Property(s => s.Price)
                .HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<SchedulingModel>(entity => entity.Property(s => s.TotalValue)
                .HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<SchedulingServiceModel>(entity => entity.Property(s => s.ServicePrice)
                .HasColumnType("decimal(18,2)"));
        }
    }
}
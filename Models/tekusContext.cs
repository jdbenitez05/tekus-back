using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tekus.Models
{
    public partial class tekusContext : DbContext
    {
        public tekusContext()
        {
        }

        public tekusContext(DbContextOptions<tekusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CountriesService> CountriesService { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<ServicesClient> ServicesClient { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=LAPTOP-KA38BCKN\\SQLEXPRESS;Database=tekus;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");

                entity.Property(e => e.TimeUpdated).HasColumnType("datetime");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CountriesService>(entity =>
            {
                entity.HasKey(e => e.CountryServiceId);

                entity.ToTable("Countries_Service");

                entity.Property(e => e.CountryServiceId).ValueGeneratedNever();

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");

                entity.Property(e => e.TimeUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountriesService)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Countries_Service_Countries1");

                entity.HasOne(d => d.ServiceClient)
                    .WithMany(p => p.CountriesService)
                    .HasForeignKey(d => d.ServiceClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Countries_Service_Services_Client1");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");

                entity.Property(e => e.TimeUpdated).HasColumnType("datetime");
            });

            modelBuilder.Entity<ServicesClient>(entity =>
            {
                entity.HasKey(e => e.ServiceClientId);

                entity.ToTable("Services_Client");

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");

                entity.Property(e => e.TimeUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ServicesClient)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Services_Client_Clients");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServicesClient)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Services_Client_Services1");
            });
        }
    }
}

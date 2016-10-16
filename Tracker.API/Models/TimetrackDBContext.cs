using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tracker.API.Models
{
    public partial class TimetrackDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-15P1AJU\MSSQLSERVER2014;Database=TimetrackDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computer>(entity =>
            {
                entity.ToTable("computer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Macaddress)
                    .IsRequired()
                    .HasColumnName("macaddress")
                    .HasColumnType("binary(8)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Software>(entity =>
            {
                entity.ToTable("software");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(511);

                entity.Property(e => e.ProductivityLevel)
                    .HasColumnName("productivity_level")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Usage>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SoftwareId, e.Date, e.ComputerId })
                    .HasName("PK_usage");

                entity.ToTable("usage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SoftwareId).HasColumnName("software_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.ComputerId).HasColumnName("computer_id");

                entity.Property(e => e.SecondsSpent).HasColumnName("seconds_spent");
            });

            modelBuilder.Entity<UsageBuffer>(entity =>
            {
                entity.HasKey(e => new { e.ComputerId, e.Timestamp })
                    .HasName("PK_usage_buffer");

                entity.ToTable("usage_buffer");

                entity.Property(e => e.ComputerId).HasColumnName("computer_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsedProgram)
                    .IsRequired()
                    .HasColumnName("used_program")
                    .HasMaxLength(511);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserUid)
                    .HasName("PK_user");

                entity.ToTable("user");

                entity.Property(e => e.UserUid)
                    .HasColumnName("user_uid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("binary(64)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(127);
            });
        }

        public virtual DbSet<Computer> Computer { get; set; }
        public virtual DbSet<Software> Software { get; set; }
        public virtual DbSet<Usage> Usage { get; set; }
        public virtual DbSet<UsageBuffer> UsageBuffer { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
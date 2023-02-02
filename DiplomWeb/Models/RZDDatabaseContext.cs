using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiplomWeb.Models
{
    public partial class RZDDatabaseContext : DbContext
    {
        public RZDDatabaseContext()
        {
        }

        public RZDDatabaseContext(DbContextOptions<RZDDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cost> Costs { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<JobName> JobNames { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<SystemAdministrator> SystemAdministrators { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

/*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=RZDDatabase;Username=postgres;Password=123");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cost>(entity =>
            {
                entity.ToTable("cost");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("history");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.IdWorker).HasColumnName("Id_Worker");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.IdWorkerNavigation)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.IdWorker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_history_worker");
            });

            modelBuilder.Entity<JobName>(entity =>
            {
                entity.ToTable("jobName");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("report");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Costs).HasColumnType("money");

                entity.Property(e => e.Period).HasColumnType("character varying");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("request");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.IdStatus).HasColumnName("Id_Status");

                entity.Property(e => e.IdType).HasColumnName("Id_Type");

                entity.Property(e => e.IdWorker).HasColumnName("Id_Worker");

                entity.Property(e => e.Post).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_request_status");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_request_type");

                entity.HasOne(d => d.IdWorkerNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.IdWorker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_request_worker");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<SystemAdministrator>(entity =>
            {
                entity.HasKey(e => e.IdJobName)
                    .HasName("SystemAdministrator_pkey");

                entity.ToTable("systemAdministrator");

                entity.Property(e => e.IdJobName)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_JobName");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Login).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.HasOne(d => d.IdJobNameNavigation)
                    .WithOne(p => p.SystemAdministrator)
                    .HasForeignKey<SystemAdministrator>(d => d.IdJobName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_systemAdministrator_jobName");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("type");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("worker");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Cabinet).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Patronymic).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(100);

                entity.Property(e => e.Surname).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

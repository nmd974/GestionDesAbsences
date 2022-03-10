using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GestionDesAbsences.Models;

#nullable disable

namespace GestionDesAbsences.DataAccess
{
    public partial class bdd_absenceContext : DbContext
    {
        public bdd_absenceContext()
        {
        }

        public bdd_absenceContext(DbContextOptions<bdd_absenceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appartenir> Appartenirs { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Classroom> Classrooms { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Proof> Proofs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Seance> Seances { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=Data/bdd_absence.db;foreign keys=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appartenir>(entity =>
            {
                entity.ToTable("appartenirs");

                entity.HasIndex(e => e.Id, "IX_appartenirs_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Archived)
                    .HasColumnName("archived")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.Appartenirs)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Appartenirs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("attendances");

                entity.HasIndex(e => e.Id, "IX_attendances_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Late).HasColumnName("late");

                entity.Property(e => e.MissingType).HasColumnName("missing_type");

                entity.Property(e => e.ProofId).HasColumnName("proof_id");

                entity.Property(e => e.SeanceId).HasColumnName("seance_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Proof)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.ProofId);

                entity.HasOne(d => d.Seance)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.SeanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.ToTable("classrooms");

                entity.HasIndex(e => e.Id, "IX_classrooms_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("promotions");

                entity.HasIndex(e => e.Id, "IX_promotions_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Label).HasColumnName("label");
            });

            modelBuilder.Entity<Proof>(entity =>
            {
                entity.ToTable("proofs");

                entity.HasIndex(e => e.Id, "IX_proofs_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Justify)
                    .HasColumnName("justify")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Motive)
                    .IsRequired()
                    .HasColumnName("motive");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.Id, "IX_roles_id")
                    .IsUnique();

                entity.HasIndex(e => e.Label, "IX_roles_label")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label");
            });

            modelBuilder.Entity<Seance>(entity =>
            {
                entity.ToTable("seances");

                entity.HasIndex(e => e.Id, "IX_seances_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");

                entity.Property(e => e.Datetime)
                    .IsRequired()
                    .HasColumnName("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label");

                entity.HasOne(d => d.Classroom)
                    .WithMany(p => p.Seances)
                    .HasForeignKey(d => d.ClassroomId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Id, "IX_users_id")
                    .IsUnique();

                entity.HasIndex(e => e.Mail, "IX_users_mail")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

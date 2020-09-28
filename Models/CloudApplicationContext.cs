using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BobbyPinApp.Models
{
    public partial class CloudApplicationContext : DbContext
    {
        public CloudApplicationContext()
        {
        }

        public CloudApplicationContext(DbContextOptions<CloudApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Condition> Condition { get; set; }
        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-166EQ2O;Database=CloudApplication;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__Category__6A1C8AFA774E48E3");

                entity.Property(e => e.CatDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.Property(e => e.Cond).HasMaxLength(20);
            });

            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__LoginInf__1788CC4C573316E5");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.UserPassword).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.CatId).HasColumnName("catID");

                entity.Property(e => e.ConditionId).HasColumnName("conditionID");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK__Post__catID__44FF419A");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.ConditionId)
                    .HasConstraintName("FK__Post__conditionI__440B1D61");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Post__UserId__4316F928");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Rating1).HasColumnName("Rating");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4CE96D6BFD");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.DateJoin).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(30);

                entity.Property(e => e.UsaState).HasMaxLength(100);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.UserInfo)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__UserInfo__LoginI__3C69FB99");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.UserInfo)
                    .HasForeignKey(d => d.RatingId)
                    .HasConstraintName("FK__UserInfo__Rating__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

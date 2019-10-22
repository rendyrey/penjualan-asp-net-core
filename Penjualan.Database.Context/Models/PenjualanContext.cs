using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Penjualan.Database.Context.Models
{
    public partial class PenjualanContext : DbContext
    {
        public PenjualanContext()
        {
        }

        public PenjualanContext(DbContextOptions<PenjualanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Tipe> Tipe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=RENDY\\SQLEXPRESS01;Database=Penjualan;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.NamaBrand)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Harga).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NamaProduct)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.TipeId).HasColumnName("TipeID");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Brands");

                entity.HasOne(d => d.Tipe)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Tipe");
            });

            modelBuilder.Entity<Tipe>(entity =>
            {
                entity.Property(e => e.TipeId)
                    .HasColumnName("TipeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.NamaTipe)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}

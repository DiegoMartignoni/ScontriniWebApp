using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ScontriniWebApp.Models.Entities;

namespace ScontriniWebApp.Models.Services.Infrastructure
{
    public partial class ScontriniWebAppDbContext : DbContext
    {
        public ScontriniWebAppDbContext(DbContextOptions<ScontriniWebAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EReceiptTemplate> ReceiptTemplates { get; set; }
        public virtual DbSet<EReceipt> Receipts { get; set; }
        public virtual DbSet<EStoreItem> StoreItems { get; set; }
        public virtual DbSet<ETransMethod> TransMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EReceiptTemplate>(entity =>
            {
                entity.HasKey(e => e.IdReceiptTemplate);

                entity.ToTable("RECEIPT_TEMPLATES");

                entity.HasIndex(e => e.IdReceiptTemplate)
                    .IsUnique();

                entity.Property(e => e.IdReceiptTemplate)
                    .HasConversion<long>()
                    .HasColumnName("idReceiptTemplate")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.TemplateImagePath)
                    .HasColumnName("templateImagePath")
                    .HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<EReceipt>(entity =>
            {
                entity.HasKey(e => e.IdReceipt);

                entity.ToTable("RECEIPTS");

                entity.HasIndex(e => e.IdReceipt)
                    .IsUnique();

                entity.Property(e => e.IdReceipt)
                    .HasConversion<long>()
                    .HasColumnName("idReceipt")
                    .ValueGeneratedNever();

                entity.OwnsOne(e => e.Price, builder =>
                {
                    builder.Property(money => money.Amount)
                        .HasColumnName("amount");
                    builder.Property(money => money.Currency)
                        .HasConversion<string>()
                        .HasColumnName("currency");
                });

                entity.Property(e => e.ElabImagePath)
                    .HasColumnName("elabImagePath")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.FullDate)
                    .HasConversion<byte[]>()
                    .HasColumnName("fullDate")
                    .HasColumnType("DATE");

                entity.Property(e => e.IdReceiptTemplate)
                    .HasColumnName("idReceiptTemplate")
                    .HasColumnType("INT");

                entity.Property(e => e.IdTransactionMethod)
                    .HasColumnName("idTransactionMethod")
                    .HasColumnType("INT");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.OrigImagePath)
                    .HasColumnName("origImagePath")
                    .HasColumnType("VARCHAR(50)");

                entity.HasOne(d => d.IdReceiptTemplateNavigation)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.IdReceiptTemplate);

                entity.HasOne(d => d.IdTransactionMethodNavigation)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.IdTransactionMethod);
            });

            modelBuilder.Entity<EStoreItem>(entity =>
            {
                entity.HasKey(e => e.IdStoreItem);

                entity.ToTable("STORE_ITEMS");

                entity.HasIndex(e => e.IdStoreItem)
                    .IsUnique();

                entity.Property(e => e.IdStoreItem)
                    .HasConversion<long>()
                    .HasColumnName("idStoreItem")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("DECIMAL(5 , 2)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Currency)
                    .HasConversion<string>()
                    .HasColumnName("currency")
                    .HasColumnType("VARCHAR(50)")
                    .HasDefaultValueSql("'EUR'");

                entity.Property(e => e.IdReceipt)
                    .HasColumnName("idReceipt")
                    .HasColumnType("INT");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(50)");

                entity.HasOne(d => d.IdReceiptNavigation)
                    .WithMany(p => p.StoreItems)
                    .HasForeignKey(d => d.IdReceipt);
            });

            modelBuilder.Entity<ETransMethod>(entity =>
            {
                entity.HasKey(e => e.IdTransMethod);

                entity.ToTable("TRANS_METHODS");

                entity.Property(e => e.IdTransMethod)
                    .HasConversion<long>()
                    .HasColumnName("idTransMethod")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.PaymentMethod)
                    .HasColumnName("paymentMethod")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.TransImagePath)
                    .HasColumnName("transImagePath")
                    .HasColumnType("VARCHAR(50)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

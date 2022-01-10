using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Negosud_RichClient.Models;

#nullable disable

namespace Negosud_RichClient.Data
{
    public partial class NegosudDbContext : DbContext
    {
        public NegosudDbContext()
        {
        }

        public NegosudDbContext(DbContextOptions<NegosudDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressUser> AddressUsers { get; set; }
        public virtual DbSet<Alcohol> Alcohols { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<GrapeRate> GrapeRates { get; set; }
        public virtual DbSet<GrapeVariety> GrapeVarieties { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOrdered> ProductOrdereds { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NegosudDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["NegosudDbConStr"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StreetNumber).HasMaxLength(255);

                entity.Property(e => e.WayType).HasMaxLength(255);
            });

            modelBuilder.Entity<AddressUser>(entity =>
            {
                entity.HasKey(e => new { e.AddressId, e.UsersId });

                entity.HasIndex(e => e.UsersId, "IX_AddressUsers_Users_Id");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.AddressUsers)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_AddressUsers_Address_Id");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.AddressUsers)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK_AddressUsers_Users_Id");
            });

            modelBuilder.Entity<Alcohol>(entity =>
            {
                entity.ToTable("Alcohol");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Range)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__Client__EB68292D266D1814");

                entity.ToTable("Client");

                entity.HasIndex(e => e.AddressId, "IX_Client_Address_Id");

                entity.Property(e => e.UsersId)
                    .ValueGeneratedNever()
                    .HasColumnName("Users_Id");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Address_Id");

                entity.HasOne(d => d.Users)
                    .WithOne(p => p.Client)
                    .HasForeignKey<Client>(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_User_Id");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__Employee__EB68292DFF14A48E");

                entity.ToTable("Employee");

                entity.Property(e => e.UsersId)
                    .ValueGeneratedNever()
                    .HasColumnName("Users_Id");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Users)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_User_Id");
            });

            modelBuilder.Entity<GrapeRate>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.GrapeVarietyId });

                entity.ToTable("GrapeRate");

                entity.HasIndex(e => e.GrapeVarietyId, "IX_GrapeRate_GrapeVariety_Id");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.GrapeVarietyId).HasColumnName("GrapeVariety_Id");

                entity.HasOne(d => d.GrapeVariety)
                    .WithMany(p => p.GrapeRates)
                    .HasForeignKey(d => d.GrapeVarietyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrapeRate_GraepVariety_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.GrapeRates)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrapeRate_Product_Id");
            });

            modelBuilder.Entity<GrapeVariety>(entity =>
            {
                entity.ToTable("GrapeVariety");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.GrapeName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.ProductId, "IX_Order_Product_Id");

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Product_Id");
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.HasKey(e => new { e.UsersId, e.OrderId });

                entity.ToTable("OrderHistory");

                entity.HasIndex(e => e.OrderId, "IX_OrderHistory_Order_Id");

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_OrderHistory_Order_Id");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_OrderHistory_Users_Id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.AlcoholId, "IX_Product_Alcohol_Id");

                entity.HasIndex(e => e.SupplierId, "IX_Product_Supplier_Id");

                entity.Property(e => e.AlcoholId).HasColumnName("Alcohol_Id");

                entity.Property(e => e.Cubitainer).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Medal).HasMaxLength(1);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Stock).HasDefaultValueSql("((0))");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");

                entity.HasOne(d => d.Alcohol)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.AlcoholId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Alcohol_Id");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Supplier_Id");
            });

            modelBuilder.Entity<ProductOrdered>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderId })
                    .HasName("PK_ProductOrder");

                entity.ToTable("ProductOrdered");

                entity.HasIndex(e => e.OrderId, "IX_ProductOrdered_Order_Id");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductOrdereds)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdOrd_Order_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductOrdereds)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdOrd_Product_Id");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.HasIndex(e => e.AddressId, "IX_Supplier_Address_Id");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.ApeNaf)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("APE_NAF");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Legal)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Manager)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Siret)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("SIRET");

                entity.Property(e => e.SocialReason)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Tva)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("TVA");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supplier_AddressId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.HashPassword).IsRequired();

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

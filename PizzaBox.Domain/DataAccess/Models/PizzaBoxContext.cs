using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Client.Models
{
    public partial class PizzaBoxContext : DbContext
    {
        public PizzaBoxContext()
        {
        }

        public PizzaBoxContext(DbContextOptions<PizzaBoxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Toppings> Toppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=PizzaBox;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust", "Pizza");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Crust1)
                    .HasColumnName("crust")
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Customerid)
                    .HasName("PK__Customer__B61ED7F5ACBFFD19");

                entity.ToTable("Customers", "Pizza");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .IsUnicode(false);

                entity.Property(e => e.Lastorder)
                    .HasColumnName("lastorder")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Orderuid)
                    .HasName("PK__Orders__A69E34B48D441910");

                entity.ToTable("Orders", "Pizza");

                entity.Property(e => e.Orderuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Crust).HasColumnName("crust");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Dateordered)
                    .HasColumnName("dateordered")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ordercost)
                    .HasColumnName("ordercost")
                    .HasColumnType("money");

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.HasOne(d => d.CrustNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Crust)
                    .HasConstraintName("FK__Orders__crust__4D5F7D71");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK__Orders__customer__14270015");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Storeid)
                    .HasConstraintName("FK_Orders_Store");
            });

            modelBuilder.Entity<Pizzas>(entity =>
            {
                entity.ToTable("Pizzas", "Pizza");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("FK__Pizzas__Orderid__634EBE90");

                entity.HasOne(d => d.ToppingNavigation)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.Topping)
                    .HasConstraintName("FK__Pizzas__Topping__625A9A57");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "Pizza");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Loc)
                    .HasColumnName("loc")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Toppings>(entity =>
            {
                entity.ToTable("Toppings", "Pizza");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Topping)
                    .HasColumnName("topping")
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

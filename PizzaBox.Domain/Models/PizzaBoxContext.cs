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
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersPizza> OrdersPizza { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Toppings> Toppings { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
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
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders", "Pizza");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__customer__5AEE82B9");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Orders__store_id__6E01572D");
            });

            modelBuilder.Entity<OrdersPizza>(entity =>
            {
                entity.ToTable("Orders_Pizza", "Pizza");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.PizzaId).HasColumnName("Pizza_Id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersPizza)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Orders_Pi__Order__59FA5E80");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.OrdersPizza)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK__Orders_Pi__Pizza__59063A47");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizza");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Isdefault)
                    .HasColumnName("isdefault")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.HasOne(d => d.Topping1Navigation)
                    .WithMany(p => p.PizzaTopping1Navigation)
                    .HasForeignKey(d => d.Topping1)
                    .HasConstraintName("FK__Pizza__Topping1__5165187F");

                entity.HasOne(d => d.Topping2Navigation)
                    .WithMany(p => p.PizzaTopping2Navigation)
                    .HasForeignKey(d => d.Topping2)
                    .HasConstraintName("FK__Pizza__Topping2__52593CB8");

                entity.HasOne(d => d.Topping3Navigation)
                    .WithMany(p => p.PizzaTopping3Navigation)
                    .HasForeignKey(d => d.Topping3)
                    .HasConstraintName("FK__Pizza__Topping3__534D60F1");

                entity.HasOne(d => d.Topping4Navigation)
                    .WithMany(p => p.PizzaTopping4Navigation)
                    .HasForeignKey(d => d.Topping4)
                    .HasConstraintName("FK__Pizza__Topping4__5441852A");

                entity.HasOne(d => d.Topping5Navigation)
                    .WithMany(p => p.PizzaTopping5Navigation)
                    .HasForeignKey(d => d.Topping5)
                    .HasConstraintName("FK__Pizza__Topping5__5535A963");
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

                entity.Property(e => e.Topping)
                    .HasColumnName("topping")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("USERS", "Pizza");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

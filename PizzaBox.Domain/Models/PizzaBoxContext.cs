using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Models
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

        public virtual DbSet<Addressing> Addressing { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaIngredients> PizzaIngredients { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addressing>(entity =>
            {
                entity.ToTable("Addressing", "Pizza");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Pizza");

                entity.Property(e => e.Address).HasColumnName("_Address");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassWord)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AddressNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Address)
                    .HasConstraintName("FK__Customer___Addre__267ABA7A");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "Pizza");

                entity.Property(e => e.EmployeePassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.ToTable("Ingredients", "Pizza");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Topping)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders", "Pizza");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PlaceDate).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__300424B4");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Orders__Employee__2F10007B");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Orders__StoreId__2E1BDC42");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizza");

                entity.Property(e => e.Amount).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizza__OrderId__32E0915F");
            });

            modelBuilder.Entity<PizzaIngredients>(entity =>
            {
                entity.ToTable("Pizza_Ingredients", "Pizza");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.PizzaIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizza_Ing__Ingre__3B75D760");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaIngredients)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizza_Ing__Pizza__3A81B327");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "Pizza");

                entity.Property(e => e.Address).HasColumnName("_Address");

                entity.Property(e => e.Name)
                    .HasColumnName("_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AddressNavigation)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.Address)
                    .HasConstraintName("FK__Store___Address__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

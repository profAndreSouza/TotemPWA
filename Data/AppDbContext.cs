using Microsoft.EntityFrameworkCore;
using TotemPWA.Models;

namespace TotemPWA.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Additional> Additionals { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cupom> Cupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customize> Customizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Category auto-relacionamento
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Combo com duas FKs para Product
            modelBuilder.Entity<Combo>()
                .HasOne(c => c.ProductCombo)
                .WithMany(p => p.CombosAsCombo)
                .HasForeignKey(c => c.ProductComboId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Combo>()
                .HasOne(c => c.Product)
                .WithMany(p => p.CombosAsItem)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Additional (N:N entre Product e Ingredient)
            modelBuilder.Entity<Additional>()
                .HasKey(a => new { a.ProductId, a.IngredientId });

            modelBuilder.Entity<Additional>()
                .HasOne(a => a.Product)
                .WithMany(p => p.Additionals)
                .HasForeignKey(a => a.ProductId);

            modelBuilder.Entity<Additional>()
                .HasOne(a => a.Ingredient)
                .WithMany(i => i.Additionals)
                .HasForeignKey(a => a.IngredientId);

            // Customize (N:N entre OrderItem e Ingredient com ID próprio)
            modelBuilder.Entity<Customize>()
                .HasOne(c => c.OrderItem)
                .WithMany(o => o.Customizations)
                .HasForeignKey(c => c.OrderItemId);

            modelBuilder.Entity<Customize>()
                .HasOne(c => c.Ingredient)
                .WithMany(i => i.Customizations)
                .HasForeignKey(c => c.IngredientId);

            // Employee com chave primária compartilhada com Client (1:1)
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.ClientId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Client)
                .WithOne(c => c.Employee)
                .HasForeignKey<Employee>(e => e.ClientId);

            // Order - Cupom (FK opcional)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Cupom)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CupomId)
                .OnDelete(DeleteBehavior.SetNull);

            // OrderItem com FK composta (OrderId + ProductId)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            // Payment → Order
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Payments)
                .HasForeignKey(p => p.OrderId);
        }
    }

}

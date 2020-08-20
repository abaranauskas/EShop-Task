using EShop.BL;
using Microsoft.EntityFrameworkCore;

namespace EShop.Persistent
{
    public class EShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EShopDB;Trusted_Connection=true;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(x =>
            {
                x.ToTable("Orders").HasKey(o => o.Id);
                x.Property(o => o.Id).HasColumnName("OrderID");
                x.HasOne(o => o.Customer).WithMany(c => c.Orders);
                x.HasMany(o => o.OrderItems).WithOne();
            });

            modelBuilder.Entity<OrderItem>(x =>
            {
                x.ToTable("OrderItems").HasKey(oi => oi.Id);
                x.Property(oi => oi.Id).HasColumnName("OrderItemID");
                x.Property(oi => oi.Quantity);                
                x.HasOne(oi => oi.Product).WithOne().HasForeignKey<Product>(p => p.Id);
            });

            modelBuilder.Entity<Product>(x =>
            {
                x.ToTable("Products").HasKey(p => p.Id);
                x.Property(p => p.Id).HasColumnName("ProductID");
                x.Property(p => p.StockQuantity);
                x.Property(p => p.Name);
                x.Property(p => p.Price);
                x.HasMany(p => p.PrciceStamps).WithOne();
                x.HasMany(p => p.ProductSuppliers).WithOne(ps => ps.Product);
                x.HasMany(p => p.ProductDiscountCoupons).WithOne(ps => ps.Product);               
            });

            modelBuilder.Entity<ProductSupplier>(x =>
            {
                x.ToTable("ProductSuppliers").HasKey(ps => ps.Id);
                x.Property(ps => ps.Id).HasColumnName("ProductSupplierID");
                x.HasOne(ps => ps.Product).WithMany(p => p.ProductSuppliers);
                x.HasOne(ps => ps.Suppier).WithMany();
            });

            modelBuilder.Entity<Supplier>(x =>
            {
                x.ToTable("Suppliers").HasKey(s => s.Id);
                x.Property(s => s.Id).HasColumnName("SupplierID");
                x.Property(s => s.Name);
            });

            modelBuilder.Entity<ProductDiscountCoupon>(x =>
            {
                x.ToTable("ProductDiscountCoupons").HasKey(pdc => pdc.Id);
                x.Property(pdc => pdc.Id).HasColumnName("ProductDiscountCouponID");
                x.HasOne(pdc => pdc.Product).WithMany(p => p.ProductDiscountCoupons);
                x.HasOne(pdc => pdc.DiscountCoupon).WithMany();
            });

            modelBuilder.Entity<DiscountCoupon>(x =>
            {
                x.ToTable("DiscountCoupons").HasKey(d => d.Id);
                x.Property(d => d.Id).HasColumnName("DiscountCouponID");
                x.Property(d => d.Name);
                x.Property(d => d.Percentage);
            });

            modelBuilder.Entity<PriceStamp>(x =>
            {
                x.ToTable("PriceStamps").HasKey(ps => ps.Id);
                x.Property(ps => ps.Id).HasColumnName("PriceStampID");
                x.Property(ps => ps.ValidFrom);
                x.Property(ps => ps.ValidTo);
                x.Property(ps => ps.Price);
            });

            modelBuilder.Entity<User>(x =>
            {
                x.ToTable("Users").HasKey(u => u.Id);
                x.Property(u => u.Id).HasColumnName("UserID");
                x.Property(u => u.FirstName);
                x.Property(u => u.LastName);
                x.Property(u => u.Email);
                x.HasMany(u => u.Orders).WithOne(o => o.Customer);
                x.HasMany(u => u.UserRoles).WithOne(uo => uo.User);
            });

            modelBuilder.Entity<UserRole>(x =>
            {
                x.ToTable("UserRoles").HasKey(ur => ur.Id);
                x.Property(ur => ur.Id).HasColumnName("UserRoleID");
                x.HasOne(ur => ur.User).WithMany(u => u.UserRoles);
                x.HasOne(ur => ur.Role).WithMany(r => r.UserRoles);
            });

            modelBuilder.Entity<Role>(x =>
            {
                x.ToTable("Roles").HasKey(r => r.Id);
                x.Property(r => r.Id).HasColumnName("RoleID");
                x.HasMany(r => r.UserRoles).WithOne(ur => ur.Role);
                x.Property(r => r.Name);
            });
        }
    }
}

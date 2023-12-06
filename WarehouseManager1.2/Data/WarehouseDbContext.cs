using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Oracle.ManagedDataAccess.Client;

namespace WarehouseManager1._2.Data
{
    public class WarehouseDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Numerator> Numerators { get; set; }
        public DbSet<NumeratorAllocation> NumeratorAllocations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }


        public WarehouseDbContext() : base("name=OracleDbContext") 
        {
            // Configuration options if needed
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<WarehouseDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
           .Property(u => u.Username)
           .HasMaxLength(255);

            base.OnModelCreating(modelBuilder);

        }
    }
}

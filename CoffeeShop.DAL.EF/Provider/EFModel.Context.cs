namespace CoffeeShop.DAL.EF.Provider
{
    using Microsoft.EntityFrameworkCore;
    using CoffeeShop.Domain.Entities;

    public partial class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
            modelBuilder.Entity<ClientCoffee>().ToTable("ClientCoffee");
            modelBuilder.Entity<CoffeePointWorth>().ToTable("CoffeePointWorth");
            modelBuilder.Entity<Point>().ToTable("Point");
            modelBuilder.Entity<PointConvert>().ToTable("PointConvert");
            modelBuilder.Entity<PointWorth>().ToTable("PointWorth");
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<ClientCoffee> ClientCoffees { get; set; }
        public virtual DbSet<CoffeePointWorth> CoffeePointWorths { get; set; }
        public virtual DbSet<Point> Points { get; set; }
        public virtual DbSet<PointConvert> PointConverts { get; set; }
        public virtual DbSet<PointWorth> PointWorths { get; set; }
    }
}

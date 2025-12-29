using Microsoft.EntityFrameworkCore;

namespace E_Com.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductRAM> productRAMs { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductWeight > ProductWeights { get; set; }
        public DbSet<HomeBanner> homeBanners { get; set; }
        public DbSet<HomeSideBanner> homeSideBanners { get;set; }
        public DbSet<SubCategory > SubCategories { get; set; }


      

    }

}

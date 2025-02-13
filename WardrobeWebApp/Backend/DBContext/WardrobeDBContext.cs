using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.Extensions.Configuration;
using Backend.Models.Enums;

namespace Backend
{
    public class WardrobeDBContext: DbContext
    {
        private readonly IConfiguration Configuration;
        public WardrobeDBContext(DbContextOptions<WardrobeDBContext> options) : base(options)
        {
        }
        public DbSet<ClothingItem> ClothingItems { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<WearingHistory> WearingHistories { get; set; }
        public DbSet<Outfit> Outfits { get; set; }

        public DbSet<ImageLocation> ImageLocations { get; set; }
        public DbSet<ImageUrl> ImageUrls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ImageUrl>().HasData(
                new ImageUrl() { ImageId = 1, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/BlackJumper.jpg.jpg" },
                new ImageUrl() { ImageId = 2, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/blackSkirt.jpg.jpg" },
                new ImageUrl() { ImageId = 3, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/BlueJacket.jpg.jpg" },
                new ImageUrl() { ImageId = 4, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/BrownSkirt.jpg.jpg" },
                new ImageUrl() { ImageId = 5, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DarkGreyJeans.jpg.jpg" },
                new ImageUrl() { ImageId = 6, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                new ImageUrl() { ImageId = 7, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                new ImageUrl() { ImageId = 8, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                new ImageUrl() { ImageId = 9, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                new ImageUrl() { ImageId = 10, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                new ImageUrl() { ImageId = 11, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                new ImageUrl() { ImageId = 12, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                new ImageUrl() { ImageId = 13, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                new ImageUrl() { ImageId = 14, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                new ImageUrl() { ImageId = 15, Url = "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" }
                );
            modelBuilder.Entity<ClothingItem>().HasData(
                 new Models.ClothingItem()
                 { Id = 15, ImageId = 1, UserId = 1, Name = "Black Oversized Jumper", Brand = "Y/Project", Category = ClothingCategory.Jumper, Colour = "Black", Occasion = Occasion.Home, Season = Season.Autumn, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 1, ImageId = 2, UserId = 1, Name = "Asymmetrical Black Skirt", Brand = "Unknown", Category = ClothingCategory.Skirt, Colour = "Black", Occasion = Occasion.Evening, Season = Season.Summer, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 2, ImageId = 3, UserId = 2, Name = "Blue Faux Leather Jacket", Brand = "Wilfred", Category = ClothingCategory.Jumper, Colour = "Blue", Occasion = Occasion.Party, Season = Season.Spring, Size = ClothingSize.L },
                    new Models.ClothingItem()
                    { Id = 3, ImageId = 4, UserId = 1, Name = "Herringbone Bias-Cut Skirt", Brand = "M&S", Category = ClothingCategory.Skirt, Colour = "Brown", Occasion = Occasion.Party, Season = Season.Winter, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 4, ImageId = 5, UserId = 1, Name = "Straight-Leg Grey Jeans", Brand = "& Other Stories", Category = ClothingCategory.Trousers, Colour = "Dark Grey", Occasion = Occasion.Home, Season = Season.Autumn, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 5, ImageId = 6, UserId = 2, Name = "Denim Corset Top w/ Back Zip", Brand = "Aritzia", Category = ClothingCategory.Blouse, Colour = "Blue", Occasion = Occasion.DIY, Season = Season.Summer, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 6, ImageId = 7, UserId = 2, Name = "Double-Breasted Coat w/ Belt and Button Stand Collar", Brand = "Calvin Klein", Category = ClothingCategory.Coat, Colour = "Grey", Occasion = Occasion.Formal, Season = Season.Winter, Size = ClothingSize.S },
                    new Models.ClothingItem()
                    { Id = 7, ImageId = 8, UserId = 2, Name = "Long-Sleeve Cotton Dungaree", Brand = "COS", Category = ClothingCategory.Dungaree, Colour = "Navy", Occasion = Occasion.Sport, Season = Season.Autumn, Size = ClothingSize.S },
                    new Models.ClothingItem()
                    { Id = 8, ImageId = 9, UserId = 2, Name = "Cashmere V-Neck Cardigan", Brand = "COS", Category = ClothingCategory.Jumper, Colour = "Dark Grey", Occasion = Occasion.DIY, Season = Season.Winter, Size = ClothingSize.L },
                    new Models.ClothingItem()
                    { Id = 9, ImageId = 10, UserId = 2, Name = "Waterproof Coat w/ Removable Down Layer", Brand = "The North Face", Category = ClothingCategory.Coat, Colour = "Black", Occasion = Occasion.Sport, Season = Season.Winter, Size = ClothingSize.XL },
                    new Models.ClothingItem()
                    { Id = 10, ImageId = 11, UserId = 2, Name = "Off-The-Shoulder Crop Top", Brand = "Wilfred", Category = ClothingCategory.Shirt, Colour = "Light Blue", Occasion = Occasion.DIY, Season = Season.Spring, Size = ClothingSize.S },
                    new Models.ClothingItem()
                    { Id = 11, ImageId = 12, UserId = 2, Name = "Stripe Off-The-Shoulder Top", Brand = "Unknown", Category = ClothingCategory.TShirt, Colour = "Black", Occasion = Occasion.Evening, Season = Season.Summer, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 12, ImageId = 13, UserId = 2, Name = "High-Waisted Trousers w/ Matching Belt", Brand = "Topshop", Category = ClothingCategory.Trousers, Colour = "Dark Grey", Occasion = Occasion.Home, Season = Season.Autumn, Size = ClothingSize.L },
                      new Models.ClothingItem()
                      { Id = 13, ImageId = 14, UserId = 2, Name = "Cowl-Neck Slip Dress", Brand = "AllSaints", Category = ClothingCategory.Dress, Colour = "White", Occasion = Occasion.Evening, Season = Season.Summer, Size = ClothingSize.L },
                    new Models.ClothingItem()
                    { Id = 14, ImageId = 15, UserId = 2, Name = "Straight-Leg Knit Trousers w/ Elastic Waistband", Brand = "Uniqlo", Category = ClothingCategory.Trousers, Colour = "White", Occasion = Occasion.Home, Season = Season.Spring, Size = ClothingSize.L }
                );
            modelBuilder.Entity<UserLogin>().HasData(
                new UserLogin() { UserId = 1, UserName = "testuser1@wardrobe.com", Password = "helloworld" },
                new UserLogin() { UserId = 2, UserName = "testuser2@wardrobe.com", Password = "goodbyeworld" },
                new UserLogin() { UserId = 3, UserName = "testuser3@wardrobe.com", Password = "hello" },
                new UserLogin() { UserId = 4, UserName = "testuser4@wardrobe.com", Password = "password" }
                );
            modelBuilder.Entity<ClothingItem>().HasOne(c => c.ImageUrl).WithOne().HasForeignKey<ClothingItem>(c => c.ImageId);

        }

    }
}

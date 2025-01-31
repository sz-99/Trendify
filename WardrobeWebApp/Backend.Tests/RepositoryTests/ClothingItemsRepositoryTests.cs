using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Backend;
using Backend.Models;
using Backend.Models.Enums;

namespace Backend.Tests.RepositoryTests
{
    internal class ClothingItemsRepositoryTests
    {
        WardrobeDBContext _dbContext;
        ClothingItemsRepository _repository;
        ClothingItem _initialClothingItem;
        ClothingItem _testClothingItem;



        [TearDown]
        public void TeardownDb()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        public void InjectInitialTestDataIntoDb(WardrobeDBContext dbContext)
        {

            _initialClothingItem = new ClothingItem() { 
                Id = 0, 
                UserId = 1, 
                ImageId = 1, 
                Name = "White T-shirt", 
                Category = ClothingCategory.TShirt,
                Size = ClothingSize.M,
                Brand = "Fantastic T-shirts",
                Colour = "Blue",
                Occasion = Occasion.Sport,
                Season = Season.Summer
            };

            if (dbContext != null)
            {
                dbContext.ClothingItems.Add(_initialClothingItem);
                dbContext.SaveChanges();
                return;
            }
            throw new NullReferenceException("No database context present");
        }

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WardrobeDBContext>();
            optionsBuilder.UseInMemoryDatabase("WardrobeInMemory");
            _dbContext = new WardrobeDBContext(optionsBuilder.Options);
            InjectInitialTestDataIntoDb(_dbContext);
            _repository = new ClothingItemsRepository(_dbContext);

            _testClothingItem = new ClothingItem()
            {
                Id = 0,
                UserId = 2,
                ImageId = 2,
                Name = "Pink shirt",
                Category = ClothingCategory.Shirt,
                Size = ClothingSize.L,
                Brand = "Amazing Shirts",
                Colour = "Pink",
                Occasion = Occasion.Evening,
                Season = Season.Winter
            };
        }


        [Test]
        public void AddNewClothingItem_Increases_Count_Of_ClothingItems_By_One()
        {
            // Arrange
            var clothingItemsCount = _repository.FindAllClothingItems().Count();

            // Act
            var addedClothingItem = _repository.AddClothingItem(_testClothingItem);

            // Assert
            Assert.That(_repository.FindAllClothingItems().Count() == clothingItemsCount + 1);
        }


        [Test]
        public void DeleteClothingItem_Returns_Null_If_Album_Does_Not_Exist()
        {

            // Arrange
            var initialClothingItem = _repository.FindAllClothingItems().FirstOrDefault();
            var id = initialClothingItem?.Id;

            // Act
             _repository.DeleteClothingItem(_initialClothingItem);

            // Asserta
            if (id is null)
            {
                Assert.That(false);
            }
            else 
            {
                Assert.That(_repository.FindClothingItemById((int)id), Is.Null);
            };
           
        }

        [Test]
        public void FindAllClothingItems_Returns_List_of_Albums_Not_Null()
        {
            // Arrange


            // Act
            var clothingItems = _repository.FindAllClothingItems();

            // Assert
            Assert.That(clothingItems is not null);
            Assert.That(clothingItems.GetType() is List<ClothingItem>);
        }

        [Test]
        public void FindClothingItemById_Returns_Not_Null()
        {
            // Arrange


            // Act
            var album = _repository.FindClothingItemById(1);

            // Assert
            Assert.That(album != null);
        }

        [Test]
        public void UpdateClothingItem_Returns_Not_Null()
        {
            // Arrange
            var id = _repository.FindAllClothingItems().FirstOrDefault()?.Id;
            var clothingItemToDelete = _repository.FindClothingItemById((int)id);

            // Act
            var returnAlbum = _repository.ReplaceClothingItem(clothingItemToDelete);

            // Assert
            Assert.That(returnAlbum != null);
        }

        [Test]
        public void UpdateAlbumById_Returns_Album_With_Correct_Id()
        {
            // Arrange
            var album = new Album() { Title = "Fantastic album", Artist = "Fantastic artist" };
            var id = _model.FindAllAlbums().First().Id;

            // Act
            var returnAlbum = _model.UpdateAlbumById(id, album);

            // Assert
            Assert.That(returnAlbum != null && returnAlbum.Artist == album.Artist);
        }
    }
}

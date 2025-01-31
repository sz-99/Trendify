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

        [TearDown]
        public void TeardownDb()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        public static void InjectInitialTestDataIntoDb(WardrobeDBContext dbContext)
        {
            var tShirt = new ClothingItem() { 
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
                dbContext.ClothingItems.Add(tShirt);
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
        }


        [Test]
        public void AddNewAlbum_Increases_Count_Of_Albums_By_One()
        {
            // Arrange
            var  = new Album() { Title = "Fantastic album", Artist = "Fantastic artist" };
            var albumsCount = _model.FindAllAlbums().Count();

            // Act
            var album_ = _model.AddNewAlbum(album);

            // Assert
            Assert.That(_model.FindAllAlbums().Count() == albumsCount + 1);
        }

        [Test]
        public void AddNewAlbum_Returns_Album_With_Correct_Id()
        {
            // Arrange
            var album = new Album() { Title = "Fantastic album", Artist = "Fantastic artist" };
            var albumsCount = _model.FindAllAlbums().Count();
            var newId = _model.FindFirstUnusedId();

            // Act
            var album_ = _model.AddNewAlbum(album);

            // Assert
            Assert.That(album.Id == newId);
        }

        [Test]
        public void DeleteAlbumById_Returns_Null_If_Album_Does_Not_Exist()
        {

            // Act
            var returnAlbum = _model.DeleteAlbumById(2);

            // Assert
            Assert.That(returnAlbum == null);
        }

        [Test]
        public void DeleteAlbumById_Returns_True_If_Album_Does_Exist_And_Is_Deleted()
        {

            // Act
            var returnAlbum = _model.DeleteAlbumById(1);

            // Assert
            Assert.That(returnAlbum == true);
        }

        [Test]
        public void FindFirstUnusedId_Returns_2()
        {
            Assert.That(_model.FindFirstUnusedId() == 2);
        }

        [Test]
        public void GetAllAlbums_Returns_List_of_Albums_Not_Null()
        {
            // Arrange


            // Act
            var albums = _model.FindAllAlbums();

            // Assert
            Assert.That(albums != null);
        }

        [Test]
        public void GetAlbumById_Returns_Not_Null()
        {
            // Arrange


            // Act
            var album = _model.FindAlbumById(1);

            // Assert
            Assert.That(album != null);
        }

        [Test]
        public void UpdateAlbumById_Returns_Not_Null()
        {
            // Arrange
            var album = new Album() { Title = "Fantastic album", Artist = "Fantastic artist" };
            var id = _model.FindAllAlbums().First().Id;
            // Act
            var returnAlbum = _model.UpdateAlbumById(id, album);

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

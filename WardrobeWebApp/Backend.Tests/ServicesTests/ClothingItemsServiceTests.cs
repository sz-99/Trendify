using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Models.Enums;
using Backend.Tests;

using Moq;

namespace Backend.Tests.ServicesTests
{
    internal class ClothingItemsRepositoryTests
    {

        Mock<IClothingItemsRepository> _mockRepository;
        ClothingItemsService _service;
        ClothingItem _initialClothingItem;
        ClothingItem _testClothingItem;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IClothingItemsRepository>();
            _service = new ClothingItemsService(_mockRepository.Object);

            _initialClothingItem = TestExamples.GetInitialClothingItem();
            _testClothingItem = TestExamples.GetADifferentClothingItem();
        }

        //[Test]
        //public void UpdateClothingItem_Returns_Not_Null()
        //{
        //    // Arrange
        //    var id = _repository.FindAllClothingItems().FirstOrDefault()?.Id;
        //    var clothingItemToDelete = _repository.FindClothingItemById((int)id);

        //    // Act
        //    var returnAlbum = _repository.ReplaceClothingItem(clothingItemToDelete);

        //    // Assert
        //    Assert.That(returnAlbum != null);
        //}

        [Test]
        public void ReplaceClothingItem_Returns_An_Album_with_the_same_Id_but_with_New_Properties()
        {
            // Arrange
            var firstClothingItemInDb = _initialClothingItem;
            var replacementClothingItem = _testClothingItem;
            var id = 1;
            firstClothingItemInDb.Id = id;
            replacementClothingItem.Id = 3;
            var updatedItem = firstClothingItemInDb.UpdateWithValuesFrom
            clothingItemToUpdate.UpdateWithValuesFrom(clothingItem);

            _mockRepository
                .Setup(repo => repo.FindClothingItemById(id))
                .Returns(firstClothingItemInDb);

            _mockRepository
                .Setup(repo => repo.ReplaceClothingItem(_testClothingItem))
                .Returns(_testClothingItem);

            // Act
            var (status, updatedItem) = _service.ReplaceClothingItem(id, _testClothingItem);

            // Assert
            Assert.That(status, Is.EqualTo(ExecutionStatus.SUCCESS));
            Assert.That(updatedItem.HasSameValuesAs(_testClothingItem));
        }
    }
}

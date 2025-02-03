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
            var updatedFirstClothingItem = firstClothingItemInDb.UpdateWithValuesFrom(replacementClothingItem);

            _mockRepository
                .Setup(repo => repo.FindClothingItemById(1))
                .Returns(firstClothingItemInDb);

            _mockRepository
                .Setup(repo => repo.ReplaceClothingItem(updatedFirstClothingItem))
                .Returns(updatedFirstClothingItem);

            // Act
            var (status, returnedReplacedItem) = _service.ReplaceClothingItem(1, replacementClothingItem);

            // Assert
            Assert.That(status, Is.EqualTo(ExecutionStatus.SUCCESS));
            Assert.That(returnedReplacedItem.HasSameValuesAs(replacementClothingItem));
        }
    }
}

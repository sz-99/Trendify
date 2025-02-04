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

        [Test]
        public void DeleteClothingItem_Invokes_FindItemByIdMethod_Once()
        {
            //arrange
            
            //act
            var result = _service.DeleteClothingItem(1);

            //assert
            _mockRepository.Verify(d=>d.FindClothingItemById(1), Times.Once());
        }

        [Test]
        public void DeleteClothing_Returns_NOTFOUND()
        {
            //arrange

            //act
            var result = _service.DeleteClothingItem(100);

            //assert
            Assert.That(result, Is.EqualTo(ExecutionStatus.NOT_FOUND));
        }

        [Test]
        public void FindAllClothing_Returns_Success_And_RevokeMethodOnce()
        {
            //arrange
            _mockRepository.Setup(r=>r.FindAllClothingItems()).Returns(TestExamples.GetListOfClothingItem());

            //act
            var result = _service.FindAllClothingItems();

            //assert
            Assert.That(result.status, Is.EqualTo(ExecutionStatus.SUCCESS));
            _mockRepository.Verify(r=>r.FindAllClothingItems(), Times.Once());
        }
    }
}

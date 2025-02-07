using Backend.Controllers;
using Backend.Models;
using Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;

namespace Backend.Tests.ControllerTests
{
    public class ClothingItemsControllerTests
    {
        private Mock<IClothingItemsService> _mockService;
        private ClothingItemsController _clothingController;
        

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IClothingItemsService>();
            _clothingController = new ClothingItemsController(_mockService.Object);

        }

        [Test]
        public void GetAllClothingItems_Returns_Ok_And_List()
        {
            //arrange
            _mockService.Setup(s => s.FindAllClothingItems()).Returns((ExecutionStatus.SUCCESS, new List<ClothingItem>()));

            //act
            var result = _clothingController.GetAllClothingItems() as IActionResult;

            //assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(new List<ClothingItem>() );
        }

        [Test]
        public void GetAllClothingItems_Returns_NotFound()
        {
            //arrange
            _mockService.Setup(s => s.FindAllClothingItems()).Returns((ExecutionStatus.NOT_FOUND, null));

            //act
            var result = _clothingController.GetAllClothingItems() as IActionResult;

            //assert
            result.Should().BeOfType<NotFoundObjectResult>();
            
        }

        [Test]
        public void AddClothingItem_Returns_Ok()
        {
            //arrange
            _mockService.Setup(s => s.AddClothingItem(TestExamples.GetInitialClothingItem())).Returns((ExecutionStatus.SUCCESS, TestExamples.GetInitialClothingItem()));

            //act
            var result = _clothingController.AddClothingItem(TestExamples.GetInitialClothingItem()) as IActionResult;

            //assert
            result.Should().BeOfType<OkObjectResult>();

        }

        [Test]
        public void DeleteClothingItem_Returns_Ok_Invokes_Service_Method_Once()
        {
            //arrange
            _mockService.Setup(s => s.DeleteClothingItem(1)).Returns(ExecutionStatus.SUCCESS);

            //act
            var result = _clothingController.DeleteClothingItem(1);

            //assert
            result.Should().BeOfType<OkResult>();
            _mockService.Verify(s => s.DeleteClothingItem(1), Times.Once());
        }

        [Test]
        public void DeleteClothingItem_Returns_NotFound()
        {
            //arrange
            _mockService.Setup(s => s.DeleteClothingItem(1)).Returns(ExecutionStatus.NOT_FOUND);

            //act
            var result = _clothingController.DeleteClothingItem(1);

            //assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}

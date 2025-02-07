using Backend.Controllers;
using Backend.Models.Enums;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Backend.Tests.ControllerTests
{
    internal class OutfitControllerTests
    {
        private Mock<IOutfitService> _mockService;
        private OutfitController _outfitController;


        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IOutfitService>();
            _outfitController = new OutfitController(_mockService.Object);
        }

        [Test]
        public void GetOutfit_ValidLocation_ReturnsOk()
        {
            // Arrange
            var outfitItems = new List<ClothingItem>
        {
            new ClothingItem { Id = 1, Name = "Jacket" },
            new ClothingItem { Id = 2, Name = "Jeans" }
        };

            _mockService
                .Setup(s => s.MakeOutfitToList("New York"))
                .ReturnsAsync((ExecutionStatus.SUCCESS, outfitItems));

            // Act
            var result = _outfitController.GetOutfit("New York");

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void GetOutfit_ValidLocation_Returns_List()
        {
            // Arrange
            var outfitItems = new List<ClothingItem>
        {
            new ClothingItem { Id = 1, Name = "Jacket" },
            new ClothingItem { Id = 2, Name = "Jeans" }
        };

            _mockService
                .Setup(s => s.MakeOutfitToList("New York"))
                .ReturnsAsync((ExecutionStatus.SUCCESS, outfitItems));

            // Act
            var result = _outfitController.GetOutfit("New York");

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(outfitItems, okResult.Value);
        }

        [Test]
        public void GetOutfit_InvalidLocation_ReturnsBadRequest()
        {
            // Arrange
            _mockService
                .Setup(s => s.MakeOutfitToList("InvalidCity"))
                .ReturnsAsync((ExecutionStatus.NOT_FOUND, null));

            // Act
            var result = _outfitController.GetOutfit("InvalidCity");

            // Assert
            result.Should().BeOfType<BadRequestResult>();
            var badRequestResult = result as BadRequestResult;
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }
    }
}

using Backend.Models;
using Backend.Models.Enums;
using Backend.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Backend.Tests.ServicesTests
{
    internal class OutfitServiceTests
    {
        private Mock<IClothingItemsRepository> _mockRepository;
        private OutfitService _service;
        private Mock<IWeatherService> _mockWeatherService;
        private WeatherInfo newWeather = new WeatherInfo() 
                                { Id = 1, Location = "City", MinTemp = 5, AvgTemp = 6, MaxTemp = 7, Condition = "cloudy", Precipitation = 0};
        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IClothingItemsRepository>();
            _mockWeatherService = new Mock<IWeatherService>();
            _service = new OutfitService( _mockRepository.Object, _mockWeatherService.Object);
        }

        [Test]
        public void MakeOutfit_InvokesMethodAtLeastOnce()
        {
            //arrange
            _mockRepository.Setup(r=>r.FindAllClothingItems()).Returns(TestExamples.GetListOfClothingItem());

            //act
           _service.MakeOutfit();

            //assert
            _mockRepository.Verify(r => r.FindAllClothingItems(), Times.AtLeastOnce);

        }

        [Test]
        public async Task MakeOutfitBasedOnWeather_ValidWeather_ReturnsSuccess()
        {
            // Arrange
            var weather = new WeatherInfo
            {
                AvgTemp = 15,
                MaxTemp = 18,
                Precipitation = 1.5f
            };

            _mockWeatherService.Setup(s => s.GetWeatherForecast("London"))
                .ReturnsAsync((ExecutionStatus.SUCCESS, weather));

            _mockRepository.Setup(r => r.FindAllClothingItems())
                .Returns(TestExamples.GetListOfClothingItem);

            // Act
            var (status, outfit) = await _service.MakeOutfitBasedOnWeather("London");

            // Assert
            status.Should().Be(ExecutionStatus.SUCCESS);
            outfit.Should().NotBeNull();
            outfit.ClothingItemsIds.Should().NotBeEmpty();
        }

      
        [Test]
        public async Task MakeOutfitBasedOnWeather_WeatherNotAvailable_ReturnsNotFound()
        {
            // Arrange
            _mockWeatherService.Setup(s => s.GetWeatherForecast("UnknownCity"))
                .ReturnsAsync((ExecutionStatus.NOT_FOUND, null));

            // Act
            var (status, outfit) = await _service.MakeOutfitBasedOnWeather("UnknownCity");

            // Assert
            status.Should().Be(ExecutionStatus.NOT_FOUND);
            outfit.Should().BeNull();
        }

    }
}

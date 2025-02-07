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
    internal class WeatherControllerTests
    {
        private Mock<IWeatherService> _mockService;
        private WeatherController _weatherController;


        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IWeatherService>();
            _weatherController = new WeatherController(_mockService.Object);

        }
        [Test]
        public async Task GetWeatherForecast_ValidLocation_ReturnsOk()
        {
            // Arrange
            var weatherInfo = new WeatherInfo
            {
                Location = "New York",
                MinTemp = 10.5f,
                MaxTemp = 20.2f,
                AvgTemp = 15.3f,
                 Precipitation = 5.0f,
                Condition = "Sunny"
            };

            _mockService
                .Setup(s => s.GetWeatherForecast("New York"))
                .ReturnsAsync((ExecutionStatus.SUCCESS, weatherInfo));

            // Act
            var result = await _weatherController.GetWeatherForcast("New York");

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            
        }

        [Test]
        public async Task GetWeatherForecast_ValidLocation_Returns_WeatherInfo()
        {
            // Arrange
            var weatherInfo = new WeatherInfo
            {
                Location = "New York",
                MinTemp = 10.5f,
                MaxTemp = 20.2f,
                AvgTemp = 15.3f,
                Precipitation = 5,
                Condition = "Sunny"
            };

            _mockService
                .Setup(s => s.GetWeatherForecast("New York"))
                .ReturnsAsync((ExecutionStatus.SUCCESS, weatherInfo));

            // Act
            var result = await _weatherController.GetWeatherForcast("New York");

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(weatherInfo, okResult.Value);
        }

        [Test]
        public async Task GetWeatherForecast_InvalidLocation_ReturnsNotFound()
        {
            // Arrange
            _mockService
                .Setup(s => s.GetWeatherForecast("InvalidCity"))
                .ReturnsAsync((ExecutionStatus.NOT_FOUND, null));

            // Act
            var result = await _weatherController.GetWeatherForcast("InvalidCity");

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }
    }
}

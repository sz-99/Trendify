using Backend.Controllers;
using Backend.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void GetWeatherForecast_Returns_Ok()
        {
            //arrange


            //act

            //assert
        }
    }
}

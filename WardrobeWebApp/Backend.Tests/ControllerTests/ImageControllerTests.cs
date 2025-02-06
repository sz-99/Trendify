using Backend.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using FluentAssertions;
namespace Backend.Controllers
{
    public class ImageControllerTests
    {
        private Mock<IImageService> _imageServiceMock;
        private ImageController _imageController;
        [SetUp]
        public void SetUp()
        {
            _imageServiceMock = new Mock<IImageService>();
            _imageController = new ImageController( _imageServiceMock.Object );
        }

        [Test]
        public void PostImage_ValidImage_ReturnsOkWithId()
        {
            var mockFile = new Mock<IFormFile>();
            _imageServiceMock.Setup(s => s.SaveImage(mockFile.Object, null))
                .Returns((ExecutionStatus.SUCCESS, 123));

            var result = _imageController.PostImage(mockFile.Object) as OkObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().Be(123);
        }

        [Test]
        public void GetImageByClothingId_NotFound_ReturnsNotFound()
        {
            _imageServiceMock.Setup(s => s.FindImageByClothingItemId(1))
                .Returns((ExecutionStatus.NOT_FOUND, "", ""));

            var result = _imageController.GetImageByClothingId(1) as NotFoundObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
            result.Value.Should().Be("No image found for 1");
        }

        [Test]
        public void GetImageByImageId_ValidId_ReturnsPhysicalFile()
        {
            _imageServiceMock.Setup(s => s.FindImageByImageId(1))
                .Returns((ExecutionStatus.SUCCESS, "test.jpg", "original.jpg"));

            var result = _imageController.GetImageByImageId(1) as PhysicalFileResult;

            result.Should().NotBeNull();
            result.FileName.Should().Be(Path.Combine(Directory.GetCurrentDirectory(), "test.jpg"));
            result.ContentType.Should().NotBeNull();
            result.FileDownloadName.Should().Be("original.jpg");
        }

        [Test]
        public void GetImageByImageId_NotFound_ReturnsNotFound()
        {
            _imageServiceMock.Setup(s => s.FindImageByImageId(1))
                .Returns((ExecutionStatus.NOT_FOUND, "", ""));

            var result = _imageController.GetImageByImageId(1) as NotFoundObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
            result.Value.Should().Be("No image found for 1");
        }
    }
}

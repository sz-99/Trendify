using Backend.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Tests.ControllersTests
{
    internal class ClothingItemsControllerTests
    {
        Mock<IClothing> _mockRepository;
        ClothingItemsService _service;
        ClothingItem _initialClothingItem;
        ClothingItem _testClothingItem;
    }
}

using Moq;
using Domain;
using Application;
using WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            // Arrange
            var inputBeerName = "Alambra";
            var inputBrandID = 1;

            var outputBeerID = 1;
            var mockBeerRepository = new Mock<IBeerRepository>();
            mockBeerRepository.Setup(repo => repo.InsertAsync(It.IsAny<Beer>())).ReturnsAsync(outputBeerID);
            var beerService = new BeerService(mockBeerRepository.Object);

            // Act
            int result = beerService.CreateAsync(inputBeerName, inputBrandID).Result;

            // Assert
            mockBeerRepository.Verify(repo => repo.InsertAsync(It.IsAny<Beer>()), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(outputBeerID, result);
        }
    }
}
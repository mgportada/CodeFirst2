using Moq;
using Domain;
using Application;
using WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{

    public class FakeBeerRepository : IBeerRepository
    {

        List<Beer> beers = new List<Beer>();

        public Task<Beer?> GetAsync(int id)
        {
            return Task.FromResult(beers.FirstOrDefault(x => x.BeerID == id));
        }

        public Task<int> InsertAsync(Beer beer)
        {
            beers.Add(beer);
            beer.BeerID = beers.Count;
            return Task.FromResult(beer.BeerID);

        }

        public Task UpdateAsync(Beer beer)
        {
            var index = beers.FindIndex(x => x.BeerID == beer.BeerID);
            if (index == -1)
            {
                throw new ArgumentException("Beer not found");
            }
            beers[index] = beer;
            return Task.CompletedTask;
        }
    }


    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var inputBeerName = "Alambra";
            var inputBrandID = 1;

            var outputBeerID = 1;

            var beerRepository = new FakeBeerRepository();
            var beerService = new BeerService(beerRepository);

            // Act
            int result = beerService.CreateAsync(inputBeerName, inputBrandID).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(outputBeerID, result);
        }
    }
}
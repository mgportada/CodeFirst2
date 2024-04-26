using Domain;

namespace Application
{
    public sealed class BeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public async Task<Beer> GetAsync(int beerId)
        {
            var beer = await _beerRepository.GetAsync(beerId);
            if (beer == null)
            {
                throw new ArgumentException("Beer not found");
            }

            return beer;
        }

        public async Task<int> CreateAsync(string name, int brandId)
        {
            var beer = new Beer
            {
                Name = name,
                BrandID = brandId
            };

            var beerId = await _beerRepository.InsertAsync(beer);
            return beerId;
        }

        public async Task PublishAsync(int beerId)
        {
            var beer = await _beerRepository.GetAsync(beerId);
            if (beer == null)
            {
                throw new ArgumentException("Beer not found");
            }

            await _beerRepository.UpdateAsync(beer);
        }



    }
}

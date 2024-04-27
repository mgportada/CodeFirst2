using Application;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public static class BeerEndpoints
    {
        public static void MapBeerEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/beer/{id}", async (int id, BeerService beerService) =>
            {
                var beer = await beerService.GetAsync(id);
                return beer is null ? Results.NotFound() : Results.Ok(beer);
            });
        }
    }
}

using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Database;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private ApplicationContext _context;

        public BeerController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Beer> Get() => _context.Beers.ToList();
    }
}

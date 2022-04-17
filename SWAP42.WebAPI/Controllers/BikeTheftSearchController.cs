namespace SWAP42.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SWAP42.Core.Contracts.Services;

    [ApiController]
    [Route("[controller]")]
    public class BikeTheftSearchController : ControllerBase
    {
        private readonly IBikeService _service;

        public BikeTheftSearchController(IBikeService service)
        {
            this._service = service;
        }

        [HttpGet("{location}")]
        public async Task<IActionResult> Get(string location)
        {
            var result = await this._service.GetBikeTheftCountByLocation(location);

            return this.Ok(result);
        }

        [HttpGet("InOperatedCities")]
        public async Task<IActionResult> InOperatedCities()
        {
            var result = await this._service.GetBikeTheftsInOperatedCities();

            return this.Ok(result);
        }

        [HttpGet("InToExpandCities")]
        public async Task<IActionResult> InToExpandCities()
        {
            var result = await this._service.GetBikeTheftsInToExpandCities();

            return this.Ok(result);
        }
    }
}
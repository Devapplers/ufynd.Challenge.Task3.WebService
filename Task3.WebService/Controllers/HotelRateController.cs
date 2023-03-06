using Microsoft.AspNetCore.Mvc;
using Task3.WebService.Model;
using Task3.WebService.Services;

namespace Task3.WebService.Controllers
{
    [Route("api/hotelrates")]
    [ApiController]
    public class HotelRateController : ControllerBase
    {
        private readonly IHotelRateService HotelrateService;

        public HotelRateController(IHotelRateService hotelRateService)
        {
                this.HotelrateService = hotelRateService;
        }

        [HttpGet]
        [Route("/{hotelId}")]
        public async Task<IActionResult> Filter(int hotelId, DateTime arrivalDate)
        {
            var result = new List<HotelRate>();
            try
            {
                result = HotelrateService.FilterHotelsRates(hotelId, arrivalDate);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            if(result is null)
                return NotFound();  

            return Ok(result);
        }
    }
}

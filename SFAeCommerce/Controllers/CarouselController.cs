using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SFAeCommerce.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFAeCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselController : ControllerBase
    {
        private readonly ICarousel _carouselService;

        public CarouselController(ICarousel carouselService)
        {
            _carouselService = carouselService;
        }

        [HttpGet]
        [Route("carouesl-images")]
        public async Task<IActionResult> getAllCarouselImages()
        {
            try
            {
                var imgs = await _carouselService.getcarouselimages();
                return Ok(imgs);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Internal Server error {e.Message}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SFAeCommerce.services
{
    public interface ICarousel
    {
        Task<List<SFAeCommerce.Models.Carousel>> getcarouselimages();
    }
}

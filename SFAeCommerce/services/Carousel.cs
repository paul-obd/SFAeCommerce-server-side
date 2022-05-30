using Microsoft.EntityFrameworkCore;
using SFAeCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFAeCommerce.services
{
    public class Carousel : ICarousel
    {
        private readonly SFADB_ECOMMERCEContext _dbContext;

        public Carousel(SFADB_ECOMMERCEContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<SFAeCommerce.Models.Carousel>> getcarouselimages()
        {
                var imgs = await _dbContext.Carousels.ToListAsync();
                return imgs;                   
        }
    }
}

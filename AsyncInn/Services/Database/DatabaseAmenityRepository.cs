using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Async_Inn.Data;
using Async_Inn.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Services.Database
{
    public class DatabaseAmenityRepository : IAmenityRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseAmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public Task<List<AmenityDTO>> GetAll()
        {
            return _context.Amenities

                .Select(amenity => new AmenityDTO
                {
                    Id = amenity.Id,
                    Name = amenity.Name
                })

                .ToListAsync();
        }
    }
}

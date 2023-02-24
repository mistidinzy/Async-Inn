using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Async_Inn.Data;
using Async_Inn.Models;
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

    //Create
    public async Task AddAmenity(Amenity amenity)
    {
      _context.Amenities.Add(amenity);
      await _context.SaveChangesAsync();
    }

    //Get All
    public async Task<List<Amenity>> GetAllAmenities()
    {
      var amenities = await _context.Amenities.ToListAsync();
      return amenities;
    }

    //Get One
    public async Task<Amenity> GetAmenityById(int id)
    {
      return await _context.Amenities.FindAsync(id);
    }

    //Update
    public async Task UpdateAmenity(int id, Amenity amenity)
    {
      _context.Entry(amenity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    //Delete
    public async Task TryDeleteAmenity(int id)
    {
      Amenity amenity = await GetAmenityById(id);
      _context.Entry(amenity).State =
        Microsoft.EntityFrameworkCore.EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    private bool AmenityExists(int id)
    {
      return _context.Amenities.Any(e => e.Id == id);
    }
  }
}

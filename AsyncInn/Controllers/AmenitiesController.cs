using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Services.Database;

namespace Async_Inn.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AmenitiesController : ControllerBase
  {
    private readonly IAmenityRepository _amenities;

    public AmenitiesController(IAmenityRepository amenities, AsyncInnDbContext context)
    {
      _amenities = amenities;
    }

    // GET: api/Amenities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
    {
      return await _amenities.GetAllAmenities();
    }

    // GET: api/Amenities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Amenity>> GetAmenity(int id)
    {
      return await _amenities.GetAmenityById(id);
    }

    // PUT: api/Amenities/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
    {
      if (id != amenity.Id)
      {
        return NotFound();
      }

      //_context.Entry(amenity).State = EntityState.Modified;

      try
      {
        await _amenities.UpdateAmenity(id, amenity);
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AmenityExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Amenities
    [HttpPost]
    public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
    {
      await _amenities.AddAmenity(amenity);

      return CreatedAtAction("GetAmenity", new { id = amenity.Id }, amenity);
    }

    // DELETE: api/Amenities/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAmenity(int id)
    {
      if (!AmenityExists(id))
      {
        return NotFound();
      }

      await _amenities.DeleteAmenity(id);

      return NoContent();
    }

    private bool AmenityExists(int id)
    {
      return _amenities.GetAmenityById(id) != null;
    }
  }
}

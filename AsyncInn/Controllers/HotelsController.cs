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
  public class HotelsController : ControllerBase
  {
    private readonly IHotelRepository _hotels;

    public HotelsController(IHotelRepository hotels, AsyncInnDbContext context)
    {
      _hotels = hotels;
    }

    // GET: api/Hotels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
    {
      return await _hotels.GetAllHotels();
    }

    // GET: api/Hotels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Hotel>> GetHotel(int id)
    {
      return await _hotels.GetHotelById(id);
    }

    // PUT: api/Hotels/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHotel(int id, Hotel hotel)
    {
      if (id != hotel.Id)
      {
        return NotFound();
      }

      try
      {
        await _hotels.UpdateHotel(id, hotel);
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!HotelExists(id))
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

    // POST: api/Hotels
    [HttpPost]
    public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
    {
      await _hotels.AddHotel(hotel);
      return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
    }

    // DELETE: api/Hotels/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
      if (!HotelExists(id))
      {
        return NotFound();
      }

      await _hotels.TryDeleteHotel(id);

      return NoContent();
    }

    private bool HotelExists(int id)
    {
      return _hotels.GetHotelById(id) != null;
    }
  }
}
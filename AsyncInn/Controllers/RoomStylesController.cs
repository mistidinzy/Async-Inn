using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomStylesController : ControllerBase
    {
        private readonly AsyncInnDbContext _context;

        public RoomStylesController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: api/RoomStyles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomStyle>>> GetRoomStyles()
        {
            return await _context.RoomStyles.ToListAsync();
        }

        // GET: api/RoomStyles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomStyle>> GetRoomStyle(int id)
        {
            var roomStyle = await _context.RoomStyles.FindAsync(id);

            if (roomStyle == null)
            {
                return NotFound();
            }

            return roomStyle;
        }

        // PUT: api/RoomStyles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomStyle(int id, RoomStyle roomStyle)
        {
            if (id != roomStyle.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomStyle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomStyleExists(id))
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

        // POST: api/RoomStyles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomStyle>> PostRoomStyle(RoomStyle roomStyle)
        {
            _context.RoomStyles.Add(roomStyle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomStyle", new { id = roomStyle.Id }, roomStyle);
        }

        // DELETE: api/RoomStyles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomStyle(int id)
        {
            var roomStyle = await _context.RoomStyles.FindAsync(id);
            if (roomStyle == null)
            {
                return NotFound();
            }

            _context.RoomStyles.Remove(roomStyle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomStyleExists(int id)
        {
            return _context.RoomStyles.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Services.Database
{
    public class DatabaseRoomRepository : IRoomRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetAll()
        {
            return await _context.Rooms.ToListAsync();

            //throw new NotImplementedException();

            //return new List<Room>

            //{
            // don't need to get info from db, can add in 
            //    new Room { Name = "The Hotel Where It Happened" }
            //};
            
        }

        //Task<Room> GetById(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Services.Database
{
    public class DatabaseRoomRepository : IRoomStyleRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoomStyle>> GetAll()
        {
            return await _context.RoomStyles.ToListAsync();  
        }
    }
}

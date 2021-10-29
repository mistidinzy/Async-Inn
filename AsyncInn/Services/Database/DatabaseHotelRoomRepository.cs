﻿using System;
using System.Threading.Tasks;
using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Services.Database
{
    public class DatabaseHotelRoomRepository : IHotelRoomRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseHotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task RemoveRoom(int roomId, int hotelId)
        {
            var hotelRoom = await _context.HotelRooms
                .FirstOrDefaultAsync(e =>
                    e.HotelId == hotelId &&
                    e.RoomId == roomId);

            _context.HotelRooms.Remove(hotelRoom);

            await _context.SaveChangesAsync();
        }

        public async Task AddRoom(int roomId, int hotelId)
        {
            var hotelRoom = new HotelRoom
            {
                RoomId = roomId,
                HotelId = hotelId
            };

            _context.HotelRoom.Add(hotelRoom);

            await _context.SaveChangesAsync();
        }

    }
}

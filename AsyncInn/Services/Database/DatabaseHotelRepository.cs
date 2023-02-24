﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Services.Database
{
  public class DatabaseHotelRepository : IHotelRepository
  {
    private readonly AsyncInnDbContext _context;

    public DatabaseHotelRepository(AsyncInnDbContext context)
    {
      _context = context;
    }

    public async Task AddHotel(Hotel hotel)
    {
      _context.Hotels.Add(hotel);
      await _context.SaveChangesAsync();
    }

    public async Task<List<Hotel>> GetAllHotels()
    {
      var hotels = await _context.Hotels.ToListAsync();
      return hotels;
    }

    public async Task<Hotel> GetHotelById(int id)
    {
      return await _context.Hotels.FindAsync(id);
    }

    public async Task TryDeleteHotel(int id)
    {
      //var hotel = await _context.Hotels.FindAsync(id);
      //_context.Hotels.Remove(hotel);
      //await _context.SaveChangesAsync();

      Hotel hotel = await GetHotelById(id);
      _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task UpdateHotel(int id, Hotel hotel)
    {
      _context.Entry(hotel).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    private bool HotelExists(int id)
    {
      return _context.Hotels.Any(e => e.Id == id);
    }
  }
}

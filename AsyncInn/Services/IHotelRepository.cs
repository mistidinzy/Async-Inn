using System.Collections.Generic;
using System.Threading.Tasks;
using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Services.Database
{
  public interface IHotelRepository
  {
    //Get All
    Task<List<Hotel>> GetAllHotels();

    //Get One by Id
    Task<Hotel> GetHotelById(int id);

    //Post
    Task AddHotel(Hotel hotel);

    //Put
    Task UpdateHotel(int id, Hotel hotel);

    //Delete
    Task TryDeleteHotel(int id);
  }
}
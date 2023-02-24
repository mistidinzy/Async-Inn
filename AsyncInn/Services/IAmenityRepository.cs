using System.Collections.Generic;
using System.Threading.Tasks;
using Async_Inn.Models;
using Async_Inn.Models.DTOs;

namespace Async_Inn.Services.Database
{
  public interface IAmenityRepository
  {
    //Get All
    Task<List<Amenity>> GetAllAmenities();

    //Get One
    Task<Amenity> GetAmenityById(int id);

    //Post (Create)
    Task AddAmenity(Amenity amenity);

    //Put (Update)
    Task UpdateAmenity(int id, Amenity amenity);

    //Delete
    Task DeleteAmenity(int id);
  }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Async_Inn.Models.DTOs;

namespace Async_Inn.Services.Database
{
    public interface IAmenityRepository
    {
        Task<List<AmenityDTO>> GetAll();
    }
}
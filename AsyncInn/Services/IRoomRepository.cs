using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Async_Inn.Models;
using Microsoft.AspNetCore.Mvc;

namespace Async_Inn.Services
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAll();

        

    }
}

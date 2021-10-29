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
        //Promise to return a list of rooms
        // We have to use task because we have an await 
        Task<List<Room>> GetAll();

        

    }
}

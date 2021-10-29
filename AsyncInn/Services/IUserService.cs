using System;
using System.Threading.Tasks;
using Async_Inn.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Async_Inn.Services
{
    public interface IUserService
    {
        public Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDTO> Authenticate(string username, string password);

    }
}

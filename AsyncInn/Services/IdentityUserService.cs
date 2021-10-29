using System;
using System.Threading.Tasks;
using Async_Inn.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Async_Inn.Models.Identity
{
    public class IdentityUserService : IUserService
    {
        private UserManager<ApplicationUser> userManager;

        public IdentityUserService(UserManager<ApplicationUser> manager)
        {
            userManager = manager;
        }

        public async Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            ApplicationUser user = new ApplicationUser
            {
                Email = data.Email,
                UserName = data.Username,
         
            };

            IdentityResult result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                return CreateUserDto(user);
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }

        private UserDTO CreateUserDto(ApplicationUser user)
        {
            return new UserDTO
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.UserName,
            };
        }


        public Task<UserDTO> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

    }
}

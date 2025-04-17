using AuthenticationService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Service
{
    public interface IUserService
    {
        public Task<ActionResult<UserDataResponseDto>> validateUser(UserData login);
    }
}

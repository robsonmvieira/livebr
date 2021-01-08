using System.Threading.Tasks;
using LiveBR.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiveBR.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController: MainController
    {
        public readonly IUserService userService;
            
        [HttpGet("Users")]
        public async Task<ActionResult> ListUser()
        {
            var result = await userService.Users();
            return CustomResponse(result);
        }
    }
}
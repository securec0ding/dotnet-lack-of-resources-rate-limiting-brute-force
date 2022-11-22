using Backend.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("/[controller]")]
    public class IdentityController : ControllerBase
    {
        SignInManager<IdentityUser> _signInManager;

        public IdentityController(
            SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult<LoginResultModel>> Login([FromBody] UserPasswordModel input)
        {
            var result = await _signInManager.PasswordSignInAsync(input.Username, input.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return new LoginResultModel { Success = true, Message = "Welcome admin" };
            }
            else
            {
                return new LoginResultModel { Success = false, Message = "Login failed" };
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace Pratik_Identity.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register(string email, string password)
        {
            if (ModelState.IsValid)
            {
                _userService.RegisterUser(email, password);
                return Ok("User registered successfully");
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (_userService.VerifyUser(email, password))
            {
                return Ok("Login successful");
            }
            return Unauthorized("Invalid credentials");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TicketSystem.API.DTOs;
using TicketSystem.API.DBContext;

namespace TicketSystem.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDBContext _context;
        public AuthController(AppDBContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _context.Users
                            .FirstOrDefault(x => x.Username == dto.Username && x.Password == dto.Password);

            if(user == null)
                return Unauthorized("Invalid Credentials");

            return Ok(user);
        }
    }
}

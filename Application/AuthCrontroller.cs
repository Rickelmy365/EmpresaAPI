using Microsoft.AspNetCore.Mvc;
using EmpresaAPI.Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace EmpresaAPI.Application
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(string email, string senha)
        {
            try
            {
                _authService.Registrar(email, senha);
                return Ok("Usuário criado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string senha)
        {
            try
            {
                var token = _authService.Login(email, senha);

                return Ok(new
                {
                    token = token
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
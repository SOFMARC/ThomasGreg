using Microsoft.AspNetCore.Mvc;
using Auth.Services.Interfaces;
using Auth.Models;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var token = await _authService.AuthenticateAsync(usuario.Nome, usuario.PasswordHash);

            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }

        /// <summary>
        /// Registra um novo usuário.
        /// 
        /// A senha deve:
        /// - Ter pelo menos 8 caracteres de comprimento
        /// - Conter pelo menos uma letra minúscula
        /// - Conter pelo menos uma letra maiúscula
        /// - Conter pelo menos um dígito numérico
        /// - Conter pelo menos um caractere especial (não alfanumérico)
        /// - Conter pelo menos um caractere único
        /// </summary>
        /// <param name="nome">O nome do usuário</param>
        /// <param name="senha">A senha do usuário</param>
        /// <returns>Resultado da operação de registro</returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(string nome, string senha)
        {
            var result = await _authService.RegisterUserAsync(nome, senha);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}

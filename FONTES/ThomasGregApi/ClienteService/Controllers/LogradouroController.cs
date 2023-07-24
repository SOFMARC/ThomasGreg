using AutoMapper;
using ClienteService.DTOs;
using ClienteService.Models;
using ClienteService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClienteService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LogradourosController : ControllerBase
    {
        private readonly ILogradouroService _logradouroService;
        private readonly IMapper _mapper;

        public LogradourosController(ILogradouroService logradouroService, IMapper mapper)
        {
            _logradouroService = logradouroService;
            _mapper = mapper;
        }

        #region OPERAÇÕES DE SAIDA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogradouroDTO>>> GetLogradouros()
        {
            var logradouros = await _logradouroService.GetAllLogradouros();

            if (logradouros == null || logradouros.Count() == 0)
            {
                return NotFound("Nenhum logradouro encontrado. A lista de logradouros está vazia.");
            }

            return _mapper.Map<List<LogradouroDTO>>(logradouros);
        }

        // GET api/Logradouros/
        [HttpGet("{id}")]
        public async Task<ActionResult<LogradouroDTO>> GetLogradouro(int id)
        {
            var logradouro = await _logradouroService.GetLogradouro(id);

            if (logradouro == null)
            {
                return NotFound("Logradouro não encontrado. O ID especificado pode não estar associado a nenhum logradouro.");
            }

            return _mapper.Map<LogradouroDTO>(logradouro);
        }
        #endregion

        #region OPERAÇÕES DE ENTRADA
        [HttpPost]
        public async Task<ActionResult<LogradouroDTO>> PostLogradouro(LogradouroDTO logradouroDto)
        {
            var logradouro = _mapper.Map<Logradouro>(logradouroDto);
            await _logradouroService.CreateLogradouro(logradouro);

            return CreatedAtAction("GetLogradouro", new { id = logradouro.Id }, _mapper.Map<LogradouroDTO>(logradouro));
        }

        // PUT api/Logradouros/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogradouro(int id, LogradouroDTO logradouroDto)
        {
            if (id != logradouroDto.Id)
            {
                return BadRequest();
            }

            var logradouro = await _logradouroService.GetLogradouro(id);
            if (logradouro == null)
            {
                return NotFound(new { message = "Logradouro não encontrado. A atualização não pôde ser concluída." });
            }

            _mapper.Map(logradouroDto, logradouro);
            await _logradouroService.UpdateLogradouro(logradouro);

            return NoContent();
        }


        // DELETE api/Logradouros/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogradouro(int id)
        {
            var logradouro = await _logradouroService.GetLogradouro(id);
            if (logradouro == null)
            {
                return NotFound(new { message = "Logradouro não encontrado" });
            }

            await _logradouroService.DeleteLogradouro(id);

            return Ok(new { message = "Logradouro deletado com sucesso!" });
        }
        #endregion
    }

}

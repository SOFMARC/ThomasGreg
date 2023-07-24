using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClienteService.Data;
using ClienteService.Models;
using ClienteService.Services.Interfaces;
using ClienteService.DTOs;
using AutoMapper;
using ClienteService.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace ClienteService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }
        #region OPERAÇÕES DE SAIDA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteService.GetAllClientes();

            if (clientes == null || !clientes.Any())
            {
                return NotFound(new { message = "Nenhum cliente encontrado" });
            }

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var result = await _clienteService.GetClienteById(id);
            if (!result.Success)
            {
                return NotFound(new { message = result.ErrorMessage });
            }
            return Ok(result.Result);
        }
        #endregion

        #region OPERAÇÕES DE ENTRADA
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> PostCliente(ClienteDTO clienteDto)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDto);

                var createdCliente = await _clienteService.CreateCliente(cliente);

                var createdClienteDto = _mapper.Map<ClienteDTO>(createdCliente);

                return CreatedAtAction(nameof(GetCliente), new { id = createdClienteDto.Id }, createdClienteDto);
            }
            catch (CustomException ex)
            {
                if (ex.ErrorCode == "DUPLICATE_EMAIL")
                {
                    return Conflict(new { message = ex.Message });
                }
                throw;
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDTO clienteDto)
        {

            if (id != clienteDto.Id)
            {
                return BadRequest(new { message = "ID do cliente não corresponde ao ID do corpo da solicitação" });
            }

            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDto);
                await _clienteService.UpdateCliente(cliente);
                return NoContent();
            }
            catch (CustomException ex)
            {
                if (ex.ErrorCode == "DUPLICATE_EMAIL")
                {
                    return Conflict(new { message = ex.Message });
                }
                throw;
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                await _clienteService.DeleteCliente(id);
                return Ok(new { message = "Cliente deletado com sucesso!" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        #endregion 
    }
}

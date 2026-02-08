using Clientes.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Clientes.Api.DTOs;

namespace Clientes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClientesController(IClienteService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var clientes = await _service.GetAllAsync();
            return Ok(clientes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var cliente = await _service.GetByIdAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]ClienteCreateDto clienteDto)
        {
            var criado = await _service.CreateAsync(clienteDto);
            return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClienteUpdateDto clienteDto)
        {
            var atualizado = await _service.UpdateAsync(id, clienteDto);
            if (!atualizado) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletado = await _service.DeleteAsync(id);
            if (!deletado) return NotFound();
            return NoContent();
        }
    }
}
using GerenciadorAluguelCarro.Models;
using GerenciadorAluguelCarro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorAluguelCarro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public IActionResult AdicionarCliente([FromBody] Cliente cliente)
        {
            ClienteRepository.AdicionarCliente(cliente);
            return Ok(cliente);
        }

        [HttpGet]
        public IActionResult ListarClientes()
        {
            var clientes = ClienteRepository.ListarClientes();
            return Ok(clientes);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, [FromBody] Cliente clienteAtualizado)
        {
            var cliente = ClienteRepository.ObterClientePorId(id);
            if (cliente == null) return NotFound("Cliente não encontrado.");

            ClienteRepository.AtualizarCliente(id, clienteAtualizado);
            return Ok(clienteAtualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverCliente(int id)
        {
            var cliente = ClienteRepository.ObterClientePorId(id);
            if (cliente == null) return NotFound("Cliente não encontrado.");

            ClienteRepository.RemoverCliente(id);
            return NoContent();
        }
    }

}

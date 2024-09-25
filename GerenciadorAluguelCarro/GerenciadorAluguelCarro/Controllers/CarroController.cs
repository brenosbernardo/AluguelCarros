using GerenciadorAluguelCarro.Models;
using GerenciadorAluguelCarro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorAluguelCarro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        [HttpPost]
        public IActionResult AdicionarCarro([FromBody] Carro carro)
        {
            CarroRepository.AdicionarCarro(carro);
            return Ok(carro);
        }

        [HttpGet]
        public IActionResult ListarCarros()
        {
            var carros = CarroRepository.ListarCarros();
            return Ok(carros);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCarro(int id, [FromBody] Carro carroAtualizado)
        {
            var carro = CarroRepository.ObterCarroPorId(id);
            if (carro == null) return NotFound("Carro não encontrado.");

            CarroRepository.AtualizarCarro(id, carroAtualizado);
            return Ok(carroAtualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverCarro(int id)
        {
            var carro = CarroRepository.ObterCarroPorId(id);
            if (carro == null) return NotFound("Carro não encontrado.");

            CarroRepository.RemoverCarro(id);
            return NoContent();
        }
    }

}

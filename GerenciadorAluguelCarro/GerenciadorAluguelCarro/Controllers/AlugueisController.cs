using GerenciadorAluguelCarro.DTOs;
using GerenciadorAluguelCarro.Models;
using GerenciadorAluguelCarro.Service;
using GerenciadorAluguelCarro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorAluguelCarro.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AlugueisController : ControllerBase
    {
        private readonly AlugueisService _alugueisService;

        public AlugueisController()
        {
            var clienteService = new ClienteService();
            var carroService = new CarroService();
            _alugueisService = new AlugueisService(clienteService, carroService);
        }

        [HttpPost("carros/{idCarro}/alugueis")]
        public IActionResult CriarAluguelParaCarroEspecifico(int idCarro, [FromBody] AluguelDTO request)
        {
            try
            {
                var aluguel = _alugueisService.CriarAluguel(idCarro, request);
                return Ok(aluguel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("categorias/{nomeCategoria}/alugueis")]
        public IActionResult CriarAluguelParaCategoria(string nomeCategoria, [FromBody] AluguelDTO request)
        {
            try
            {
                var aluguel = _alugueisService.CriarAluguelPorCategoria(nomeCategoria, request);
                return Ok(aluguel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
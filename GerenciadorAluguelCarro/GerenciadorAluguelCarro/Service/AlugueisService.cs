using GerenciadorAluguelCarro.DTOs;
using GerenciadorAluguelCarro.Models;
using GerenciadorAluguelCarro.Repositories;

namespace GerenciadorAluguelCarro.Service
{
    public class AlugueisService
    {
        private readonly ClienteService _clienteService;
        private readonly CarroService _carroService;

        public AlugueisService(ClienteService clienteService, CarroService carroService)
        {
            _clienteService = clienteService;
            _carroService = carroService;
        }

        public Aluguel CriarAluguel(int idCarro, AluguelDTO request)
        {
            var cliente = ClienteRepository.ObterClientePorId(request.ClienteId);
            if (!_clienteService.VerificarClienteAtivo(cliente))
            {
                EmailService.EnviarEmailFalha(cliente, "Cliente inativo ou não encontrado.");
                throw new Exception("Cliente inativo ou não encontrado.");
            }

            var carro = CarroRepository.ObterCarroPorId(idCarro);
            if (!_carroService.VerificarCarroDisponivel(carro))
            {
                EmailService.EnviarEmailFalha(cliente, "Carro não disponível.");
                throw new Exception("Carro não disponível.");
            }

            var aluguel = new Aluguel
            {
                Id = Guid.NewGuid().ToString(),
                Cliente = cliente,
                Carro = carro,
                Data = request.Data,
                Sucesso = true
            };

            _carroService.MarcarCarroComoIndisponivel(carro);

            EmailService.EnviarEmailSucesso(cliente, aluguel);

            return aluguel;
        }

        public Aluguel CriarAluguelPorCategoria(string nomeCategoria, AluguelDTO request)
        {
            var cliente = ClienteRepository.ObterClientePorId(request.ClienteId);
            if (!_clienteService.VerificarClienteAtivo(cliente))
            {
                EmailService.EnviarEmailFalha(cliente, "Cliente inativo ou não encontrado.");
                throw new Exception("Cliente inativo ou não encontrado.");
            }

            var carrosDisponiveis = CarroRepository.ObterCarrosPorCategoria(nomeCategoria).Where(c => c.Disponivel).ToList();
            if (!carrosDisponiveis.Any())
            {
                EmailService.EnviarEmailFalha(cliente, "Nenhum carro disponível na categoria.");
                throw new Exception("Nenhum carro disponível na categoria.");
            }

            var carroAleatorio = carrosDisponiveis[new Random().Next(carrosDisponiveis.Count)];

            var aluguel = new Aluguel
            {
                Id = Guid.NewGuid().ToString(),
                Cliente = cliente,
                Carro = carroAleatorio,
                Data = request.Data,
                Sucesso = true
            };

            _carroService.MarcarCarroComoIndisponivel(carroAleatorio);

            EmailService.EnviarEmailSucesso(cliente, aluguel);

            return aluguel;
        }
    }
}

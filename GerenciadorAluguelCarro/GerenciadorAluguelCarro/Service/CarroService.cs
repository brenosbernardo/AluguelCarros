using GerenciadorAluguelCarro.Models;

namespace GerenciadorAluguelCarro.Service
{
    public class CarroService
    {
        public bool VerificarCarroDisponivel(Carro carro)
        {
            return carro != null && carro.Disponivel;
        }

        public void MarcarCarroComoIndisponivel(Carro carro)
        {
            carro.Disponivel = false;
        }
    }

}

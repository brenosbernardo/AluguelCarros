using GerenciadorAluguelCarro.Models;

namespace GerenciadorAluguelCarro.Service
{
    public class ClienteService
    {
        public bool VerificarClienteAtivo(Cliente cliente)
        {
            return cliente != null && cliente.Ativo;
        }
    }

}

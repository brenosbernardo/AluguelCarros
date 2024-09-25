using GerenciadorAluguelCarro.Models;

namespace GerenciadorAluguelCarro.Repositories
{

    public static class ClienteRepository
    {
        private static List<Cliente> _clientes = new List<Cliente>{
        new Cliente { Id = 1, Nome = "João", Email = "joao@email.com", Ativo = true },
        new Cliente { Id = 2, Nome = "Maria", Email = "maria@email.com", Ativo = false }};

        public static Cliente ObterClientePorId(int id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }

        public static void AdicionarCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public static List<Cliente> ListarClientes()
        {
            return _clientes;
        }

        public static void AtualizarCliente(int id, Cliente clienteAtualizado)
        {
            var cliente = ObterClientePorId(id);
            if (cliente != null)
            {
                cliente.Nome = clienteAtualizado.Nome;
                cliente.Ativo = clienteAtualizado.Ativo;
            }
        }

        public static void RemoverCliente(int id)
        {
            var cliente = ObterClientePorId(id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
        }
    }
}

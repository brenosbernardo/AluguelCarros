using GerenciadorAluguelCarro.Models;

namespace GerenciadorAluguelCarro.Repositories
{
    public static class CarroRepository
    {
        private static List<Carro> _carros = new List<Carro>{
        new Carro { Id = 1, Modelo = "Fusca", Categoria = "Econômico", Disponivel = true },
        new Carro { Id = 2, Modelo = "Ferrari", Categoria = "Luxo", Disponivel = false }};

        public static void AdicionarCarro(Carro carro)
        {
            _carros.Add(carro);
        }

        public static List<Carro> ListarCarros()
        {
            return _carros;
        }
        public static List<Carro> ObterCarrosPorCategoria(string categoria)
        {
            return _carros.Where(c => c.Categoria == categoria).ToList();
        }

        public static Carro ObterCarroPorId(int id)
        {
            return _carros.FirstOrDefault(c => c.Id == id);
        }

        public static void AtualizarCarro(int id, Carro carroAtualizado)
        {
            var carro = ObterCarroPorId(id);
            if (carro != null)
            {
                carro.Modelo = carroAtualizado.Modelo;
                carro.Categoria = carroAtualizado.Categoria;
                carro.Disponivel = carroAtualizado.Disponivel;
            }
        }

        public static void RemoverCarro(int id)
        {
            var carro = ObterCarroPorId(id);
            if (carro != null)
            {
                _carros.Remove(carro);
            }
        }
    }
}
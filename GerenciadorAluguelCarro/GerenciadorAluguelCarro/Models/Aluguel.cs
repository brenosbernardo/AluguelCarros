namespace GerenciadorAluguelCarro.Models
{
    public class Aluguel
    {
        public string Id { get; set; }
        public Cliente Cliente { get; set; }
        public Carro Carro { get; set; }
        public DateTime Data { get; set; }
        public bool Sucesso { get; set; }
    }

}

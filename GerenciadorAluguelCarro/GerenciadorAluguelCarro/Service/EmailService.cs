using GerenciadorAluguelCarro.Models;

namespace GerenciadorAluguelCarro.Service
{
    public static class EmailService
    {
        public static void EnviarEmailSucesso(Cliente cliente, Aluguel aluguel)
        {
            Console.WriteLine($"Email enviado para {cliente.Email}: Aluguel confirmado!");
        }

        public static void EnviarEmailFalha(Cliente cliente, string motivo)
        {
            Console.WriteLine($"Email enviado para {cliente.Email}: Aluguel falhou. Motivo: {motivo}");
        }
    }

}

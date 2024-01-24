using DesafioFundamentos.Models;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Coloca o encoding para UTF8 para exibir acentuação
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Seja bem vindo ao Estacionamento Tech da Avanade!\n");

        decimal precoInicial = 0;
        decimal precoPorHora = 0;

        // Instancia a classe Estacionamento
        Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

        while (true)
        {
            try
            {
                Console.WriteLine("Digite o preço inicial: ");
                estacionamento.PrecoInicial = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("\nDigite o preço por hora: ");
                estacionamento.PrecoPorHora = Convert.ToDecimal(Console.ReadLine());
                // Se chegarmos aqui, significa que nenhum erro ocorreu e podemos sair do loop
                break;
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("\nEntrada inválida. Por favor, digite um número.");
            }
        }

        bool exibirMenu = true;

        while (exibirMenu)
        {
            exibirMenu = ExibirMenu(estacionamento);
        }

        Console.WriteLine("O programa se encerrou");
    }

    static bool ExibirMenu(Estacionamento estacionamento)
    {
        Console.Clear();
        Console.WriteLine("Digite a sua opção:");
        Console.WriteLine("1 - Cadastrar veículo");
        Console.WriteLine("2 - Remover veículo");
        Console.WriteLine("3 - Listar veículos");
        Console.WriteLine("4 - Encerrar");

        switch (Console.ReadLine())
        {
            case "1":
                estacionamento.AdicionarVeiculo();
                break;

            case "2":
                estacionamento.RemoverVeiculo();
                break;

            case "3":
                estacionamento.ListarVeiculos();
                break;

            case "4":
                string confirmacao = "";
                while (confirmacao.ToLower() != "s" && confirmacao.ToLower() != "n")
                {
                    Console.WriteLine("Você realmente deseja encerrar o programa? (s/n)\n");
                    confirmacao = Console.ReadLine();
                    if (confirmacao.ToLower() == "s")
                    {
                        return false;
                    }
                    else if (confirmacao.ToLower() != "n")
                    {
                        Console.WriteLine("Entrada inválida. Por favor, digite 's' para sim ou 'n' para não.");
                    }
                }
                break;

            default:
                Console.WriteLine("Opção inválida. Digite um valor válido!");
                break;
        }

        Console.WriteLine("Pressione a tecla 'Enter' para continuar");
        Console.ReadLine();

        return true;
    }
}

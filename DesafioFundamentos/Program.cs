using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

/* Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:");
precoPorHora = Convert.ToDecimal(Console.ReadLine()); */

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n");

while (true)
{
    try
    {
        Console.Write("Digite o preço inicial: ");
        precoInicial = Convert.ToDecimal(Console.ReadLine());
        es.PrecoInicial = precoInicial; // Lança uma exceção se o valor for inválido
        Console.Clear();

        Console.Write("\nDigite o preço por hora: ");
        precoPorHora = Convert.ToDecimal(Console.ReadLine());
        es.PrecoPorHora = precoPorHora; // Lança uma exceção se o valor for inválido
        Console.Clear();

        break; // Se chegarmos aqui, significa que nenhum erro ocorreu e podemos sair do loop
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message); // Imprime a mensagem de erro
        Console.WriteLine("Por favor, tente novamente.\n");
    }
    catch (FormatException)
    {
        Console.WriteLine("\nEntrada inválida. Por favor, digite um número.");
    }
}

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
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
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida. Digite um valor válido!");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");

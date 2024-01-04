using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n");

decimal precoInicial = 0;
decimal precoPorHora = 0;

// Instancia a classe Estacionamento
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

while (true)
{
    try
    {
        Console.Write("Digite o preço inicial: ");
        precoInicial = Convert.ToDecimal(Console.ReadLine());
        es.PrecoInicial = precoInicial; // Lança uma exceção se o valor for inválido

        Console.Write("\nDigite o preço por hora: ");
        precoPorHora = Convert.ToDecimal(Console.ReadLine());
        es.PrecoPorHora = precoPorHora; // Lança uma exceção se o valor for inválido
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

    Console.WriteLine("Pressione a tecla 'Enter' para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");

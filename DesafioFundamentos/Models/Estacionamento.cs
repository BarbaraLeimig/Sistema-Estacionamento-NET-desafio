using System.Data;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal _precoInicial;
        private decimal _precoPorHora;
        private List<string> veiculos = new List<string>();

        public decimal PrecoInicial
        {
            get => _precoInicial;
            set
            {
                if (value < 0) 
                    throw new ArgumentException("\nO valor inserido não pode ser negativo. Por favor, tente novamente.\n");
                _precoInicial = value;
            }
        }

        public decimal PrecoPorHora
        {
            get => _precoPorHora;
            set
            {
                if (value < 0)
                    throw new ArgumentException("\nO valor inserido não pode ser negativo. Por favor, tente novamente.\n");
                _precoPorHora = value;
            }
        }

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Clear();
            // Loop para adicionar veículo
            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string placa = Console.ReadLine().ToUpper();
                // Utiliza Regular Expression para verificar se a placa é válida (padrão normal ou Mercosul)
                Regex regex = new Regex(@"^[a-zA-Z]{3}-\d{4}$|^[a-zA-Z]{3}\d[a-zA-Z]\d{2}$");
                // Verifica se a placa não é nula ou vazia e se corresponde ao padrão definido com o Regex
                if (!string.IsNullOrWhiteSpace(placa) && regex.IsMatch(placa))
                {
                    // Adiciona o veículo
                    veiculos.Add(placa);
                    Console.WriteLine($"\nVeículo de placa {placa} estacionado com sucesso!");
                    // Se chegarmos aqui, siginifica que a placa é válida e foi adicionada ao sistema. Sai do loop.
                    break;
                }
                else
                {
                    Console.WriteLine("A placa do veículo está em branco ou é inválida! Por favor, digite uma placa válida.\n");
                }
            }
        }

        public void RemoverVeiculo()
        {
            Console.Clear();
            // Loop para remover veículo existente
            while (true)
            {
                Console.WriteLine("Digite a placa do veículo que deseja remover:");
                string placa = Console.ReadLine().ToUpper();
                // Verifica se a placa do veículo é nula ou está em branco
                if (!string.IsNullOrWhiteSpace(placa))
                {
                    // Verifica se o veículo existe
                    if (veiculos.Any(x => x.ToUpper() == placa))
                    {
                        // loop para digitar quantidade de horas válidas
                        while (true)
                        {
                            Console.WriteLine("\nDigite a quantidade de horas que o veículo permaneceu estacionado:");
                            if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)
                            {
                                // Calcula o valor total a ser pago
                                decimal valorTotal = PrecoInicial + PrecoPorHora * horas;
                                // Remove a placa da lista de veículos
                                veiculos.Remove(placa);
                                Console.Clear();
                                Console.WriteLine($"O veículo de placa {placa} foi removido e o preço total foi de: {valorTotal:C}.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Atenção: a quantidade de horas deve ser um número inteiro positivo!");
                            }
                        }
                        // Se chegarmos aqui, siginifica que a placa é válida e foi removida do sistema. Sai do loop.
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.\n");
                    }
                }
                else
                {
                    Console.WriteLine("A placa do veículo não pode ser nula ou vazia");
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.Clear();
                Console.WriteLine("\nOs veículos estacionados são:");
                int i = 0;
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine($"Veículo {i + 1}: {veiculo}");
                    i++;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nNão há veículos estacionados.");
            }
        }
    }
}

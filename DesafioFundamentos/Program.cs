using DesafioFundamentos.Models;

namespace DesafioFundamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Coloca o encoding para UTF8 para exibir acentuação
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\nSeja bem vindo ao Estacionamento SmartPark Recife Antigo!\n");

            // Instancia a classe Estacionamento
            ParkingLot parkingLot = new ParkingLot();

            // Exibe o menu do estacionamento
            parkingLot.MainMenu();
        }

    }
}
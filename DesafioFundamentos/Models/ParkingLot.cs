using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DocumentValidator;

namespace DesafioFundamentos.Models
{
    public class ParkingLot
    {
        private const decimal _startingPrice = 10.0M;
        private const decimal _pricePerHour = 2.00M;
        private const int _totalCarSpaces = 230;
        private const int _totalMotorcycleSpaces = 70;
        private List<User> _users = new List<User>();
        private Dictionary<string, DateTime> _parkedCars = new Dictionary<string, DateTime>();
        private Dictionary<string, DateTime> _parkedMotorcycles = new Dictionary<string, DateTime>();

        public void MainMenu()
        {
            Console.WriteLine("Digite o número correspondente à área a qual deseja acesssar:\n" +
                                "1 - Área do Usuário\n" +
                                "2 - Área do Estacionamento\n" +
                                "3 - Encerrar programa");
            string option = Console.ReadLine();
            Console.Clear();
            switch (option)
            {
                case "1":
                    UserAreaMenu();
                    break;
                case "2":
                    ParkingAreaMenu();
                    break;
                case "3":
                    TerminateProgram();
                    break;
                default:
                    Console.WriteLine("Opção inválida! Por favor, digite uma das opções do menu.");
                    Proceed();
                    MainMenu();
                    break;
            }
        }

        public void UserAreaMenu()
        {
            Console.WriteLine("Escolha a área que deseja acessar:\n" +
                                "1 - Usuário\n" +
                                "2 - Veículo\n" +
                                "3 - Retornar ao Menu Inicial");
            string option = Console.ReadLine();
            Console.Clear();
            switch (option)
            {
                case "1":
                    UserProfile();
                    break;
                case "2":
                    VehicleProfile();
                    break;
                case "3":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Opção inválida! Por favor, digite uma das opções do menu.");
                    Proceed();
                    UserAreaMenu();
                    break;
            }
        }

        public void UserProfile()
        {
            Console.WriteLine("Escolha a área que deseja acessar:\n" +
                                "1 - Adicionar usuário\n" +
                                "2 - Exibir dados do usuário\n" +
                                "3 - Editar usuário\n" +
                                "4 - Excluir minha conta\n" +
                                "5 - Retornar à Área do Usuário");
            string option = Console.ReadLine();
            Console.Clear();
            switch (option)
            {
                case "1":
                    AddUser();
                    break;
                case "2":
                    ShowUser();
                    break;
                case "3":
                    EditUser();
                    break;
                case "4":
                    RemoveUser();
                    break;
                case "5":
                    UserAreaMenu();
                    break;
                default:
                    Console.WriteLine("Opção inválida! Por favor, digite uma das opções do menu.");
                    Proceed();
                    UserProfile();
                    break;
            }
        }

        public void VehicleProfile()
        {
            Console.WriteLine("Escolha a área que deseja acessar:\n" +
                                "1 - Cadastrar veículo\n" +
                                "2 - Exibir veículo\n" +
                                "3 - Editar veiculo\n" +
                                "4 - Remover veículo\n" +
                                "5 - Retornar à Área do Usuário");
            string option = Console.ReadLine();
            Console.Clear();
            switch (option)
            {
                case "1":
                    AddVehicle();
                    break;
                case "2":
                    ShowVehicles();
                    break;
                case "3":
                    EditVehicle();
                    break;
                case "4":
                    RemoveVehicle();
                    break;
                case "5":
                    UserAreaMenu();
                    break;
                default:
                    Console.WriteLine("Opção inválida! Digite uma opção válida");
                    Proceed();
                    VehicleProfile();
                    break;
            }
        }

        public void ParkingAreaMenu()
        {
            Console.WriteLine("Escolha uma das opções abaixo:\n" +
                               "1 - Estacionar veículo\n" +
                               "2 - Listar veículos estacionados\n" +
                               "3 - Listar vagas disponíveis para carro\n" +
                               "4 - Listar vagas disponíveis para moto\n" +
                               "5 - Deixar o estacinamento\n" +
                               "6 - Retornar ao Menu Inicial");
            string option = Console.ReadLine();
            Console.Clear();
            switch (option)
            {
                case "1":
                    ParkVehicle();
                    break;
                case "2":
                    ShowParkedVehicles();
                    break;
                case "3":
                    Console.WriteLine($"Atualmente temos {AvailableCarSpaces()} vagas disponíveis para carros.");
                    Proceed();
                    ParkingAreaMenu();
                    break;
                case "4":
                    Console.WriteLine($"Atualmente temos {AvailableMotorcycleSpaces()} vagas disponíveis para motos.");
                    Proceed();
                    ParkingAreaMenu();
                    break;
                case "5":
                    RemoveParkedVehicle();
                    break;
                case "6":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Opção inválida! Digite uma opção válida");
                    Proceed();
                    ParkingAreaMenu();
                    break;
            }
        }


        // Método para encerramento da aplicação
        public void TerminateProgram()
        {
            while (true)
            {
                Console.WriteLine("Você realmente deseja encerrar o programa? (s/n)");
                string answer = Console.ReadLine().ToLower();
                switch (answer)
                {
                    case "s":
                        Console.Clear();
                        Console.WriteLine("\nO programa se encerrou");
                        Environment.Exit(0);
                        break;

                    case "n":
                        Console.Clear();
                        MainMenu();
                        break;

                    default:
                        Console.WriteLine("Entrada inválida. Por favor, digite 's' para sim ou 'n' para não.");
                        break;
                }
            }
        }

        // Métodos CRUD referentes ao UserProfile
        public void AddUser()
        {
            while (true)
            {
                try
                {
                    string cpf = InputData("\nDigite o seu CPF:");
                    if (CpfValidation.Validate(cpf))
                    {
                        string fullName = InputData("Digite o seu nome completo:");
                        User newUser = new User(fullName, cpf);
                        _users.Add(newUser);
                        Console.WriteLine("\nUsuário cadastrado com sucesso!");
                        Proceed();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("CPF inválido. Por favor tente novamente.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            UserProfile();
        }

        public void ShowUser()
        {
            while (true)
            {
                try
                {
                    string cpf = InputData("\nDigite o CPF do usuário que deseja encontrar:");
                    User user = _users.SingleOrDefault(u => u.Cpf == cpf);
                    if (user != null)
                    {
                        Console.Clear();
                        Console.WriteLine($"Usuario encontrado!\n" + $"Nome: {user.FullName}\n" + $"CPF: {user.Cpf}\n");
                        for (int counter = 0; counter < user.Vehicles.Count; counter++)
                        {
                            Vehicle vehicle = user.Vehicles[counter];
                            Console.WriteLine($"Veículo {counter + 1}\n" +
                                                $"Tipo: {vehicle.VehicleType}\n" +
                                                $"Marca: {vehicle.Brand}\n" +
                                                $"Modelo: {vehicle.Model}\n" +
                                                $"Placa: {vehicle.LicensePlate}\n" +
                                                $"Cor: {vehicle.Color}\n");
                        }
                        Proceed();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Usuário não encontrado.\n" +
                                        "Por favor, verifique se você está cadastrado ou se digitou corretamente.");
                        Proceed();
                        break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            UserProfile();
        }

        public void EditUser()
        {
            string cpf = InputData("Digite o CPF do usuário que deseja editar:");
            while (true)
            {
                User user = _users.SingleOrDefault(u => u.Cpf == cpf);
                if (user != null)
                {
                    Console.WriteLine("Escolha a opção que deseja editar:\n" +
                                      "1 - Editar nome completo\n" +
                                      "2 - Retornar ao menu anterior");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            user.FullName = InputData("Digite o novo nome completo:");
                            Console.WriteLine("Nome completo editado com sucesso!");
                            Proceed();
                            break;
                        case "2":
                            Console.Clear();
                            UserProfile();
                            break;
                        default:
                            Console.WriteLine("Opção inválida! Por favor, digite uma das opções do menu.");
                            Proceed();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado!");
                    Proceed();
                    break;
                }
            }
            UserProfile();
        }

        public void RemoveUser()
        {
            string cpf = InputData("Digite o CPF do usuário que deseja editar:");
            bool delete = true;
            while (delete)
            {
                User user = _users.SingleOrDefault(u => u.Cpf == cpf);
                if (user != null)
                {
                    Console.WriteLine("Você deseja remover este usuário? Digite 's' para sim ou 'n' para não.");
                    switch (Console.ReadLine())
                    {
                        case "s":
                            _users.Remove(user);
                            Console.WriteLine("Usuário removido com sucesso!");
                            Proceed();
                            delete = false;
                            break;
                        case "n":
                            Console.WriteLine("Operação cancelada pelo usuário.");
                            Proceed();
                            UserProfile();
                            break;
                        default:
                            Console.WriteLine("Entrada inválida. Por favor, digite 's' para sim ou 'n' para não.");
                            Proceed();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado!");
                    Proceed();
                    break;
                }
            }
            UserProfile();
        }

        // Métodos CRUD referentes ao VehicleProfile
        public void AddVehicle()
        {
            string cpf = InputData("Digite o CPF do usuário:");
            while (true)
            {
                User user = _users.SingleOrDefault(u => u.Cpf == cpf);
                if (user != null)
                {
                    string VehicleType = InputData("Digite o tipo de veículo (Carro ou Moto):");
                    string brand = InputData("Digite a marca do veículo:");
                    string model = InputData("Digite o modelo do veículo:");
                    string licensePlate = ValidateLicensePlate();
                    string color = InputData("Digite a cor do veículo:");

                    Vehicle newVehicle;
                    if (VehicleType.ToLower() == "carro")
                    {
                        newVehicle = new Car(brand, model, licensePlate, color);
                    }
                    else if (VehicleType.ToLower() == "moto")
                    {
                        newVehicle = new Motorcycle(brand, model, licensePlate, color);
                    }
                    else
                    {
                        Console.WriteLine("Atenção! Tipo de veículo inválido, confira e digite novamente.");
                        Proceed();
                        continue;
                    }
                    user.AddVehicle(newVehicle);
                    Console.WriteLine("Veículo cadastrado com sucesso!");
                    Proceed();
                    break;
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado!");
                    Proceed();
                    break;
                }
            }
            VehicleProfile();
        }

        public void ShowVehicles()
        {
            while (true)
            {
                string cpf = InputData("Digite o CPF do usuário para exibir seus veículos:");
                User user = _users.SingleOrDefault(u => u.Cpf == cpf);
                if (user != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Olá {user.FullName}! Veja abaixo os seus veículos cadastrados no nosso sistema:");
                    for (int counter = 0; counter < user.Vehicles.Count; counter++)
                    {
                        Vehicle vehicle = user.Vehicles[counter];
                        Console.WriteLine($"\nVeículo {counter + 1}\n" +
                                            $"Tipo: {vehicle.VehicleType}\n" +
                                            $"Marca: {vehicle.Brand}\n" +
                                            $"Modelo: {vehicle.Model}\n" +
                                            $"Placa: {vehicle.LicensePlate}\n" +
                                            $"Cor: {vehicle.Color}\n");
                    }
                    Proceed();
                    break;
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado.\n" +
                                    "Por favor, verifique se você está cadastrado ou se digitou corretamente.");
                    Proceed();
                    break;
                }
            }
            VehicleProfile();
        }

        public void EditVehicle()
        {
            bool edit = true;
            while (edit)
            {
                string cpf = InputData("Digite o CPF do usuário que deseja editar:");
                User user = _users.SingleOrDefault(u => u.Cpf == cpf);
                if (user != null)
                {
                    string plate = InputData("Digite a placa do veículo que deseja editar:").ToUpper();
                    Vehicle vehicle = user.Vehicles.SingleOrDefault(v => v.LicensePlate == plate);
                    if (vehicle != null)
                    {
                        vehicle.Brand = InputData("Digite a marca do veículo:");
                        vehicle.Model = InputData("Digite o modelo do veículo:");
                        vehicle.Color = InputData("Digite a cor do veículo:");
                        Console.WriteLine("Veículo atualizado com sucesso!");
                        Proceed();
                        edit = false;
                    }
                    else
                    {
                        Console.WriteLine("Veículo não encontrado!");
                        Proceed();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado!");
                    Proceed();
                    break;
                }
            }
            VehicleProfile();
        }

        public void RemoveVehicle()
        {
            bool proceedLoop = true;
            while (proceedLoop)
            {
                string cpf = InputData("Digite o seu CPF:");
                User user = _users.SingleOrDefault(u => u.Cpf == cpf);
                if (user != null)
                {
                    string plate = InputData("Digite a placa do veículo que deseja remover:").ToUpper();
                    Vehicle vehicle = user.Vehicles.SingleOrDefault(v => v.LicensePlate == plate);
                    if (vehicle != null)
                    {
                        Console.WriteLine("Você deseja remover este usuário? Digite 's' para sim ou 'n' para não.");
                        switch (Console.ReadLine())
                        {
                            case "s":
                                user.Vehicles.Remove(vehicle);
                                Console.WriteLine("Veículo removido com sucesso!");
                                Proceed();
                                proceedLoop = false;
                                break;
                            case "n":
                                Console.WriteLine("Operação cancelada pelo usuário.");
                                Proceed();
                                VehicleProfile();
                                break;
                            default:
                                Console.WriteLine("Entrada inválida. Por favor, digite 's' para sim ou 'n' para não.");
                                Proceed();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Veículo não encontrado!");
                        Proceed();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado!");
                    Proceed();
                    break;
                }
            }
            VehicleProfile();
        }

        // Métodos referentes à Área do Estacionamento
        public void ParkVehicle()
        {
            bool proceedLoop = true;
            while (proceedLoop)
            {
                string cpf = InputData("Digite o seu CPF:");
                User user = _users.SingleOrDefault(u => u.Cpf == cpf);
                if (user != null)
                {
                    string plate = InputData("Digite a placa do veículo:").ToUpper();
                    Vehicle vehicle = user.Vehicles.SingleOrDefault(v => v.LicensePlate == plate);
                    if (vehicle != null)
                    {
                        if (vehicle.VehicleType == "Carro")
                        {
                            ParkCar(plate);
                            proceedLoop = false;
                        }
                        else
                        {
                            ParkMotorcycle(plate);
                            proceedLoop = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Veículo não encontrado! Verifique se digitou corretamente ou " +
                                            "cadastre seu veículo em nosso sistema para utilizar o Smart Park Recife Antigo.");
                        Proceed();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado! Verifique se digitou corretamente ou " +
                                        "cadestre-se em nosso sistema para utilizar o Smart Park Recife Antigo.");
                    Proceed();
                    break;
                }
            }
            ParkingAreaMenu();
        }

        public void ShowParkedVehicles()
        {
            Console.Clear();
            if (_parkedCars.Any() || _parkedMotorcycles.Any())
            {
                Console.WriteLine("\nOs veículos estacionados são:");

                if (_parkedCars.Any())
                {
                    Console.WriteLine("\nCarros:");
                    for (int i = 0; i < _parkedCars.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {_parkedCars.ElementAt(i).Key}");
                    }
                }
                if (_parkedMotorcycles.Any())
                {
                    Console.WriteLine("\nMotos:");
                    for (int i = 0; i < _parkedMotorcycles.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {_parkedMotorcycles.ElementAt(i).Key}");
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nNão há veículos estacionados.");
            }
            Proceed();
            ParkingAreaMenu();
        }

        public int AvailableCarSpaces()
        {
            return _totalCarSpaces - _parkedCars.Count;
        }

        public int AvailableMotorcycleSpaces()
        {
            return _totalMotorcycleSpaces - _parkedMotorcycles.Count;
        }

        public void RemoveParkedVehicle()
        {
            bool delete = true;
            while (delete)
            {
                string plate = InputData("Digite a plate do seu veículo:").ToUpper();
                if (plate != null)
                {
                    if (_parkedCars.ContainsKey(plate))
                    {
                        DateTime checkinHour = _parkedCars[plate];
                        _parkedCars.Remove(plate);
                        int parkedHours = (int)Math.Ceiling((DateTime.Now - checkinHour).TotalHours);
                        decimal totalPrice = _startingPrice + _pricePerHour * parkedHours;
                        Console.Clear();
                        Console.WriteLine($"Seu carro permaneceu estacionado por {parkedHours} hora(s). O valor total a ser pago é: {totalPrice:C}");
                        Payment(totalPrice);
                    }
                    else if (_parkedMotorcycles.ContainsKey(plate))
                    {
                        DateTime checkinHour = _parkedMotorcycles[plate];
                        _parkedMotorcycles.Remove(plate);
                        int parkedHours = (int)Math.Ceiling((DateTime.Now - checkinHour).TotalHours);
                        decimal totalPrice = _startingPrice + _pricePerHour * parkedHours;
                        Console.Clear();
                        Console.WriteLine($"Sua moto permaneceu estacionada por {parkedHours} hora(s). O valor total a ser pago é: {totalPrice:C}");
                        Payment(totalPrice);
                    }
                    else
                    {
                        Console.WriteLine("\nVeículo não encontrado! Por favor, verifique se digitou corretamente.");
                        Proceed();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\nValor digitado inválido! Por favor, verifique se digitou corretamente.");
                    Proceed();
                    break;
                }
            }
            ParkingAreaMenu();
        }

        // Métodos secundários da aplicação

        private void ParkCar(string plate)
        {
            if (AvailableCarSpaces() > 0)
            {
                _parkedCars[plate] = DateTime.Now;
                Console.WriteLine("\nCarro estacionado com sucesso!");
                Proceed();
            }
            else
            {
                Console.WriteLine("\nDesculpe, todas as vagas para carros estão ocupadas.");
                Proceed();
            }
        }

        private void ParkMotorcycle(string plate)
        {
            if (AvailableMotorcycleSpaces() > 0)
            {
                _parkedMotorcycles[plate] = DateTime.Now;
                Console.WriteLine("\nMoto estacionada com sucesso!");
                Proceed();
            }
            else
            {
                Console.WriteLine("\nDesculpe, todas as vagas para motos estão ocupadas.");
                Proceed();
            }

        }

        public void Payment(decimal totalPrice)
        {
            Console.WriteLine("Escolha a forma de pagamento:\n" +
                               "1 - PIX\n" +
                               "2 - Débito\n" +
                               "3 - Crédito");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Você escolheu pagar via PIX! O seu QR Code já foi gerado.");
                    Pay(totalPrice);
                    break;
                case "2":
                    Console.WriteLine("Você escolheu pagar via Débito! Aproxime ou insira seu cartão da maquineta.");
                    Pay(totalPrice);
                    break;
                case "3":
                    Console.WriteLine("Você escolheu pagar via Crédito! Aproxime ou insira seu cartão da maquineta.");
                    Pay(totalPrice);
                    break;
                default:
                    Console.WriteLine("Opção inválida! Digite uma opção válida");
                    Proceed();
                    Payment(totalPrice);
                    break;
            }
        }

        public void Pay(decimal totalPrice)
        {
            Console.WriteLine("Pressione Enter para pagar...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Pagamento no valor de {totalPrice:C} efetuado com sucesso!\n" +
                                "Obrigada pela confiança! Te aguardamos na próxima vinda ao Recife Antigo!");
            Environment.Exit(0);
        }
        private string InputData(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void Proceed()
        {
            Console.WriteLine("\nPressione a tecla 'Enter' para continuar");
            Console.ReadLine();
            Console.Clear();
        }

        public string ValidateLicensePlate()
        {
            while (true)
            {
                string plate = InputData("Digite a placa do veículo:").ToUpper();
                Regex regex = new Regex(@"^[a-zA-Z]{3}-\d{4}$|^[a-zA-Z]{3}\d[a-zA-Z]\d{2}$");
                if (!string.IsNullOrWhiteSpace(plate) && regex.IsMatch(plate))
                {
                    return plate;
                }
                else
                {
                    Console.WriteLine("A placa do veículo está em branco ou é inválida! Por favor, digite uma placa válida.\n");
                }
            }
        }
    }
}



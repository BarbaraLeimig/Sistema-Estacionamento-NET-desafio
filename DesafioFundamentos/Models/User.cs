using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class User
    {
        private string _fullName { get; set; }
        private string _cpf { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("\nO valor inserido não pode ser nulo ou vazio!\n" +
                                                "Por favor, digite novamente seu nome completo.\n");
                _fullName = value;
            }
        }

        public string Cpf
        {
            get => _cpf;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("\nO valor inserido não pode ser nulo ou vazio!\n" +
                                                "Por favor, digite novamente a sua reposta.\n");
                _cpf = value;
            }
        }

        public User(string fullName, string cpf)
        {
            FullName = fullName;
            Cpf = cpf;
        }
        
         public void AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }
    }
}
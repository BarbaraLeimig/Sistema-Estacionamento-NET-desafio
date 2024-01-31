using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Motorcycle : Vehicle
    {
        public override string VehicleType => "Moto";

        public Motorcycle(string brand, string model, string licensePlate, string color) : base(brand, model, licensePlate, color) { }

    }
}
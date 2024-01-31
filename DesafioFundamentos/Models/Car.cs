using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Car : Vehicle
    {
        public override string VehicleType => "Carro";

        public Car(string brand, string model, string licensePlate, string color) : base(brand, model, licensePlate, color) { }

    }
}

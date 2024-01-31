using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public virtual string VehicleType { get; }

        protected Vehicle(string brand, string model, string licensePlate, string color)
        {
            Brand = brand;
            Model = model;
            LicensePlate = licensePlate;
            Color = color;
        }
    }
}
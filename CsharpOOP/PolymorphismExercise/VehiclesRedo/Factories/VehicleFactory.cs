using VehiclesRedo.Models;

namespace VehiclesRedo
{
    public class VehicleFactory
    {
        public VehicleFactory()
        {

        }
        public Vehicle Create(string type, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle = null;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            return vehicle;
        }
    }
}
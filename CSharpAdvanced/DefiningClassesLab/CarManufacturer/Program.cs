using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car("Lambo", "Nai-dobriq", 1);

            car.FuelConsumption = 12;
            car.FuelQuantity = 200;

            Engine engine = new Engine(650, 1000);
            Tire[] tires = new Tire[]
                {
                    new Tire(2008,1200),
                    new Tire(2008,1200),
                    new Tire(2008,1200),
                    new Tire(2008,1200)
                };


            Car toyota = new Car("t", "b", 1, 5, 4, engine, tires);

            car.Drive(20);
            car.Drive(10);
            Console.WriteLine(car.WhoAmI());

            /*            console.writeline($"{car.make} - {car.model} - {car.year}");*/
        }
    }
}
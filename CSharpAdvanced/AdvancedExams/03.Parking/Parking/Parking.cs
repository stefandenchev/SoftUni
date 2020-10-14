using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public List<Car> data;
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }
        public int Count => data.Count;

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car manufacturerToRemove = data.FirstOrDefault(x => x.Manufacturer == manufacturer);
            Car modelToRemove = data.FirstOrDefault(x => x.Model == model);
            return data.Remove(modelToRemove);
        }

        public Car GetLatestCar()
        {
            if (Count == 0)
            {
                return null;
            }
            else
            {
                Car car = data.OrderByDescending(x => x.Year).FirstOrDefault();
                return car;
            }
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car manufacturerToGet = data.FirstOrDefault(x => x.Manufacturer == manufacturer);
            Car modelToGet = data.FirstOrDefault(x => x.Manufacturer == model);
            return manufacturerToGet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
    }
}

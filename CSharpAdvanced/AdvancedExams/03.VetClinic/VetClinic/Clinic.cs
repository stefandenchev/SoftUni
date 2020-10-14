using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace VetClinic
{
    public class Clinic
    {
        public List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            if (data.Any(x => x.Name == name))
            {
                data.RemoveAll(x => x.Name == name);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Pet GetPet(string name, string owner)
        {
            bool exists = false;
            if (data.Any(x => x.Name == name & x.Owner == owner))
            {
                exists = true;
            }
            if (exists)
            {
                Pet pet = data.Where(x => x.Name == name & x.Owner == owner).FirstOrDefault();
                return pet;
            }
            return null;
        }

        public Pet GetOldestPet()
        {
            var sorted = data.OrderByDescending(x => x.Age);
            var oldest = sorted.First();
            return oldest;
        }

        /*public int Count()
        {
            return data.Count();
        }*/

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString();
        }
    }
}
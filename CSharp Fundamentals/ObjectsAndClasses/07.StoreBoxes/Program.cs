using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] elements = command.Split();

                string serialNumber = elements[0];
                string name = elements[1];
                int quantity = int.Parse(elements[2]);
                decimal itemPrice = decimal.Parse(elements[3]);
                decimal boxPrice = quantity * itemPrice;

                Box box = new Box();
                Item item = new Item();

                box.SerialNumber = serialNumber;
                box.Item.Name = name;
                box.Quantity = quantity;
                item.Price = itemPrice;
                box.PriceForBox = boxPrice;

                boxes.Add(box);

                command = Console.ReadLine();
            }


            var finalList = boxes.OrderByDescending(x => x.PriceForBox).ToList();

            foreach (Box box in finalList)
            {
                Console.WriteLine(string.Join(Environment.NewLine, boxes));
            }

        }
    }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceForBox { get; set; }

        public Box()
        {
            Item = new Item();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(SerialNumber);
            sb.Append("-- " + Item.Name + " - $");
            sb.AppendLine($"{Item.Price:f2}: {Quantity}");
            sb.Append("-- $" + PriceForBox);

            return sb.ToString().TrimEnd();
        }
    }
}

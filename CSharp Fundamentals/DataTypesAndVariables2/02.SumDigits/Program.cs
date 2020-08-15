using System;

namespace _02.SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                sum += int.Parse(num[i].ToString());
            }
            Console.WriteLine(sum);

/*            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            while(num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            Console.WriteLine(sum);*/
        }
    }
}

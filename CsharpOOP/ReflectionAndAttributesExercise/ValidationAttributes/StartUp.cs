using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 null,
                 -1
             );

            bool isvalidentity = Validator.IsValid(person);

            Console.WriteLine(isvalidentity);
        }
    }
}
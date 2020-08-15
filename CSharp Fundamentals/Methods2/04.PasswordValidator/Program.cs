using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            ValidatePassword(password);
        }

        static void ValidatePassword(string text)
        {
            bool invalid = false;
            if (text.Length < 6 || text.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                invalid = true;
            }

            if (!CheckIfContainsOnlyDigitsAndLetters(text))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                invalid = true;
            }

            if (CountNumOfDigits(text) < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                invalid = true;
            }

            if (!invalid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool CheckIfContainsOnlyDigitsAndLetters(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                char currentCharacter = text[i];
                if (!((currentCharacter >= 48 && currentCharacter <= 57)
                    || (currentCharacter >= 65 && currentCharacter <= 90)
                    || (currentCharacter >= 97 && currentCharacter <= 122)))
                {
                    return false;
                }
            }
            return true;
        }

        static int CountNumOfDigits (string text)
        {
            int counter = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= 48 && text[i] <= 57)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
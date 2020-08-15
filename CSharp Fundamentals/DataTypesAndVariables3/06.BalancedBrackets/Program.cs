using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            string result = "BALANCED";

            string brackets = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();

                if (str == "(" || str == ")")
                {
                    brackets += str;
                }
            }

            if (brackets.Length % 2 == 1)
            {
                result = "UNBALANCED";
            }

            for (int j = 0; j < brackets.Length; j++)
            {
                if (j % 2 == 0 && brackets[j] == ')')
                {
                    result = "UNBALANCED";
                    break;
                }
                if (j % 2 == 1 && brackets[j] == '(')
                {
                    result = "UNBALANCED";
                    break;
                }
            }
            Console.WriteLine(result);


            /*            byte count = byte.Parse(Console.ReadLine());
                        int openingCount = 0;
                        int closingCount = 0;
                        bool unbalanced = false;

                        for (int i = 0; i < count; i++)
                        {
                            string input = Console.ReadLine();
                            if(input == "(")
                            {
                                openingCount++;
                                if (Math.Abs(openingCount - closingCount) > 1)
                                {
                                    unbalanced = true;
                                    continue;
                                }
                            } 
                            else if (input == ")")
                            {
                                closingCount++;
                                if (Math.Abs(openingCount - closingCount) > 1)
                                {
                                    unbalanced = true;
                                    continue;
                                }
                            } 
                            else
                            {
                                continue;
                            }
                        }
                        if (unbalanced || openingCount != closingCount)
                        {
                            Console.WriteLine("UNBALANCED");
                        }
                        else if (openingCount == closingCount)
                        {
                            Console.WriteLine("BALANCED");
                        }
                        else
                        {
                            Console.WriteLine("UNBALANCED");
                        }*/
        }
    }
}

using System;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Break nested loops - how to.
            // 1. Flag boolean - check after each loop
            // 2. return - only on the innermost loop
            // 3. Envornment.Exit

            //Ctrl K C
            //Ctrl K U


            bool check = false;

            // 01:15:43

            for (int hours = 0; hours <= 23; hours++)
            {
                for (int minutes = 0; minutes <= 59; minutes++)
                {
                    for (int seconds = 0; seconds <= 59; seconds++)
                    {
                        Console.WriteLine($"{hours:d2}:{minutes:d2}:{seconds:d2}");

                        if (hours == 1 && minutes == 15 && seconds == 43)
                        {
                            /*check = true;
                            break;*/

                            //return;

                            Environment.Exit(0);
                        }
                    }

                    /*if (check)
                    {
                        break;
                    }*/
                }
                /*if (check)
                {
                    break;
                }*/
            }
        }
    }
}

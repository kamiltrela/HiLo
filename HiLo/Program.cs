using System;

namespace HiLo
{
    class Program
    {
        static class HiLoGame
        {
            public const int MAXIMUM = 10; // number to guess is always 10 or less
            private static Random random = new Random();
            private static int currentNumber = random.Next(1, MAXIMUM + 1); // generate number to start the game with
            private static int pot = 10; // pot starts at $10

            public static int GetPot() { return pot; }

            // Generate the next number to play with, 
            // user guesses if current number is higher or lower and gains $1
            // for correct answer and loses $1 for incorrect answer
            public static void Guess(bool higher)
            {
                int nextNumber = random.Next(1, MAXIMUM + 1);

                if ((higher && nextNumber >= currentNumber) || (!higher && nextNumber <= currentNumber))
                {
                    Console.WriteLine("You guessed right!");
                    pot++;
                }
                else
                {
                    Console.WriteLine("Bad luck, you guessed wrong.");
                    pot--;
                }
                currentNumber = nextNumber;
                Console.WriteLine($"The current number is {currentNumber}");
            }

            // Get a hint for more accuracy when making a guess, costs $1
            public static void Hint()
            {
                int half = MAXIMUM / 2;
                if (currentNumber >= half)
                    Console.WriteLine($"The number is at least {half}");
                else Console.WriteLine($"The number is at most {half}");
                pot--;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HiLo.");
            Console.WriteLine($"Guess numbers between 1 and {HiLoGame.MAXIMUM}.");
            HiLoGame.Hint();

            // Continue playing game until pot runs out of money or user quits
            while (HiLoGame.GetPot() > 0)
            {
                Console.WriteLine("Press h for higher, l for lower, ? to buy a hint,");
                Console.WriteLine($"or any other key to quit with ${HiLoGame.GetPot()}.\n");
                char key = Console.ReadKey(true).KeyChar;
                if (key == 'h') HiLoGame.Guess(true);
                else if (key == 'l') HiLoGame.Guess(false);
                else if (key == '?') HiLoGame.Hint();
                else return;
            }
            Console.WriteLine("The pot is empty. Bye!");
        }
    }
}

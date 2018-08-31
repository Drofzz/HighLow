using System;
using System.Diagnostics;

namespace HighLow
{
    class Program
    {
        private static readonly Random Random = new Random();
        static void Main(string[] args)
        {
            const int min = 0;
            const int max = 1000;
            var game = new Game(Random, min, max);
            Console.WriteLine($"Try and guess the number between {min} and {max}");
            Debug.WriteLine($"Pst! The number is {game.Number}");
            while (!game.Complete)
            {
                var guess = int.Parse(Console.ReadLine());
                var feedback = game.Guess(guess);

                var adverb = "";
                var adjective = "";

                if (feedback == 0)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    if (Math.Abs(feedback) == 2) adverb = "lot";
                    if (Math.Abs(feedback) == 1) adverb = "little";
                    if (feedback > 0) adjective = "greater";
                    if (feedback < 0) adjective = "less";

                    Console.WriteLine($"Number is a {adverb} {adjective} than {guess}");
                }
            }
            Console.WriteLine($"Number was {game.Number}");
            Console.WriteLine("Game Over!");
            Console.ReadKey();
        }
    }
}

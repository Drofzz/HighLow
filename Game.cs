using System;

namespace HighLow
{
    class Game {
        /// <summary>
        /// The Number to guess
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// Tries used to Guess
        /// </summary>
        public int Tries { get; private set; } = 0;

        /// <summary>
        /// Is Game Finish
        /// </summary>
        public bool Complete {get; private set;} = false;

        /// <summary>
        /// Create a new Game, from a Randomizer object, and the number between min and max
        /// </summary>
        /// <param name="random">Randomizer object</param>
        /// <param name="min">Smallest Number</param>
        /// <param name="max">Biggest Number</param>
        public Game(Random random,int min, int max){
            Number = random.Next(min,max);
        }

        /// <summary>
        /// Make a guess
        /// </summary>
        /// <param name="guess">the number to guess</param>
        /// <returns></returns>
        public int Guess(int guess)
        {
            Tries++;
            var percent = (float)guess / Number;

            //If number is guessed
            if (guess == Number)
            {
                Complete = true;
                return 0;
            }

            if (percent >= 1.05f) return -2; //Less then number over 5%
            if (percent > 1.00f) return -1; //Less then number between 0-5%
            if (percent <= 0.95f) return 2; //Greater then number over 5%
            if (percent < 1.00f) return 1; //Greater then number between 0-5%
            throw new Exception("Invalid Range");
        }
    }
}
namespace BullsAndCows.Logic
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class GameLogic : IGameLogicProvider
    {
        public GuessResult CheckGuess(string guess, string number)
        {
            var guessAsArray = guess.ToCharArray();

            var bulls = 0;

            var cows = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (guessAsArray[i] == number[i])
                {
                    bulls++;
                    guessAsArray[i] = '#';
                }
            }

            for (int i = 0; i < number.Length; i++)
            {
                if (number.Contains(guessAsArray[i]))
                {
                    cows++;
                }
            }

            return new GuessResult()
            {
                Bulls = bulls,
                Cows = cows,
                GameIsOver = bulls == 4
            };
        }

        public bool IsValidNumber(string number)
        {
            int num;
            return new HashSet<char>(number.ToCharArray()).Count == 4 && int.TryParse(number, out num);
        }
    }
}

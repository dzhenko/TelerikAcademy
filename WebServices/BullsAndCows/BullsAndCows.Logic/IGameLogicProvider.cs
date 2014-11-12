namespace BullsAndCows.Logic
{
    public interface IGameLogicProvider
    {
        GuessResult CheckGuess(string guess, string number);

        bool IsValidNumber(string number);
    }
}

namespace BullsAndCows.Web.Infrastructure
{
    public interface IRandomChanceProvider
    {
        bool GetChance(int percent);
    }
}
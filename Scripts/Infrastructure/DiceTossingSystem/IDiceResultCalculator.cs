namespace Infrastructure.DiceTossingSystem
{
    public interface IDiceResultCalculator
    {
        int GetRandomResult();
        int GetBonus();
    }
}
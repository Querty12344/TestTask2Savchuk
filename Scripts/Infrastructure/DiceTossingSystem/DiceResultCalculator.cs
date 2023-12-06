using Infrastructure.BonusSystem;
using UnityEngine;

namespace Infrastructure.DiceTossingSystem
{
    public class DiceResultCalculator : IDiceResultCalculator
    {
        private readonly IBonusService _bonuses;

        public DiceResultCalculator(IBonusService bonuses)
        {
            _bonuses = bonuses;
        }

        public int GetRandomResult()
        {
            return Random.Range(1, 21);
        }

        public int GetBonus()
        {
            return _bonuses.GetBonus();
        }
    }
}
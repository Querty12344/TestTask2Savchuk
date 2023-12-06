using System;
using System.Collections.Generic;
using Infrastructure.Factories;
using Infrastructure.GamePool;

namespace Infrastructure.BonusSystem
{
    public class BonusService : IBonusService
    {
        private readonly IGameFactory _gameFactory;
        private readonly IGamePool _gamePool;

        public BonusService(IGamePool gamePool, IGameFactory gameFactory)
        {
            _gamePool = gamePool;
            _gameFactory = gameFactory;
        }

        public int GetBonus()
        {
            var finalBonus = 0;
            foreach (var bonus in _gamePool.Bonuses)
            {
                finalBonus += bonus.BonusValue;
                _gameFactory.CreateBonusNumberIndicator(bonus.BonusValue, bonus.transform);
            }

            return finalBonus;
        }

        public IEnumerable<int> GetRandomBonuses(int count)
        {
            var r = new Random();
            var bonusValues = new List<int>();
            for (var i = 0; i < count; i++) bonusValues.Add(r.Next(1, 4));
            return bonusValues;
        }
    }
}
using System;
using System.Collections.Generic;
using Infrastructure.AssetsManagement;
using Infrastructure.BonusSystem;
using Infrastructure.GamePool;
using UnityEngine;
using Object = UnityEngine.Object;
using Vector3 = System.Numerics.Vector3;

namespace Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IGamePool _gamePool;
        private ScenePresets.ScenePresets _scene;

        public GameFactory(IAssetProvider assetProvider, IGamePool gamePool)
        {
            _assetProvider = assetProvider;
            _gamePool = gamePool;
        }

        public void InitOnScene(ScenePresets.ScenePresets scene)
        {
            _scene = scene;
        }

        public void CreateDice()
        {
            var dice = Object.Instantiate(_assetProvider.Dice, _scene.DiceRoot);
            dice.Init(this);
            _gamePool.Dice = dice;
        }


        public void CreateBonuses(IEnumerable<int> bonusesValues)
        {
            var bonuses = new List<Bonus>();
            var i = 0;
            foreach (var bonusValue in bonusesValues)
            {
                var nextBonus = Object.Instantiate(_assetProvider.Bonus, _scene.BonusPlaces[i]);
                nextBonus.BonusValue = bonusValue;
                bonuses.Add(nextBonus);
                i++;
            }

            _gamePool.Bonuses = bonuses;
        }

        public void CreateTossEffect()
        {
            Object.Instantiate(_assetProvider.TossingEffect, _scene.TossingEffectPlace);
        }

        public void CreateFinalEffect()
        {
            Object.Instantiate(_assetProvider.ResultEffect, _scene.ResultEffectPlace);
        }

        public void CreateBonusEffect()
        {
            Object.Instantiate(_assetProvider.BonusEffect, _scene.BonusEffectPlace);
        }

        public void CreateBonusNumberIndicator(int bonusValue, Transform at)
        {
            var text = Object.Instantiate(_assetProvider.BonusAddingText, at);
            text.Init(bonusValue.ToString(), _scene.UIRoot);
        }

        public void CreateBonusNumberIndicator(int bonusValue, Vector3 at)
        {
            throw new NotImplementedException();
        }
    }
}
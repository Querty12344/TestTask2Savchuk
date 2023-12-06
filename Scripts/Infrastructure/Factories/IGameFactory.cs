using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Factories
{
    public interface IGameFactory
    {
        void CreateDice();
        void CreateBonuses(IEnumerable<int> bonusesValues);
        void CreateTossEffect();
        void CreateFinalEffect();
        void CreateBonusEffect();
        void CreateBonusNumberIndicator(int bonusValue, Transform at);
        void InitOnScene(ScenePresets.ScenePresets scene);
    }
}
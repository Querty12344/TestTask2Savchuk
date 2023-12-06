using Infrastructure.Factories;
using UnityEngine;

namespace DiceComponents
{
    public class DiceEffects : MonoBehaviour
    {
        private IGameFactory _factory;

        public void Init(IGameFactory factory)
        {
            _factory = factory;
        }

        public void PlayTossEffect()
        {
            _factory.CreateTossEffect();
        }

        public void PlayFinalEffect()
        {
            _factory.CreateFinalEffect();
        }

        public void PlayBonusEffect()
        {
            _factory.CreateBonusEffect();
        }
    }
}
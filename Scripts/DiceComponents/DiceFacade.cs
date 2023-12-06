using Infrastructure.Factories;
using UnityEngine;

namespace DiceComponents
{
    public class DiceFacade : MonoBehaviour
    {
        [SerializeField] private DiceMover _mover;
        [SerializeField] private DiceRotator _rotator;
        [SerializeField] private DiceEffects _diceEffects;
        [SerializeField] private DiceResultIndicator _diceResultIndicator;

        public void Init(IGameFactory factory)
        {
            _diceEffects.Init(factory);
        }

        public void TossDice()
        {
            _mover.StartMoving();
            _rotator.StartRotation();
            _diceResultIndicator.Hide();
            _diceEffects.PlayTossEffect();
        }

        public void StopDice()
        {
            _mover.StopMoving();
            _rotator.StopRotating();
            _diceEffects.PlayFinalEffect();
        }

        public void SetPreResult(int result)
        {
            _diceResultIndicator.SetResult(result.ToString());
        }

        public void AddBonus(int result)
        {
            _diceEffects.PlayBonusEffect();
            _diceResultIndicator.SetResult(result.ToString());
        }
    }
}
using System.Collections;
using Infrastructure.CoroutineRunner;
using Infrastructure.GamePool;
using Infrastructure.UI;
using UnityEngine;

namespace Infrastructure.DiceTossingSystem
{
    public class DiceTosser : IDiceTosser
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IDiceResultCalculator _diceResultCalculator;
        private readonly IGamePool _gamePool;
        private readonly IUIService _uiService;

        public DiceTosser(IDiceResultCalculator diceResultCalculator, ICoroutineRunner coroutineRunner,
            IGamePool gamePool, IUIService uiService)
        {
            _diceResultCalculator = diceResultCalculator;
            _coroutineRunner = coroutineRunner;
            _gamePool = gamePool;
            _uiService = uiService;
        }

        public void TossDice()
        {
            _coroutineRunner.StartCoroutine(DiceTossing());
        }

        private IEnumerator DiceTossing()
        {
            DisableUI();
            yield return new WaitForSeconds(Constants.Constants.BonusInitTime);

            StartDiceTossing();
            yield return new WaitForSeconds(Constants.Constants.DiceTossingTime);

            StopDiceTossing();
            var preResult = SetTossingResult();
            yield return new WaitForSeconds(Constants.Constants.BonusOffsetTime);

            var finalResult = AddBonus(preResult);
            yield return new WaitForSeconds(Constants.Constants.BonusGettingTime);

            ShowWinIndicator(finalResult);
            EnableUI();
        }

        private void ShowWinIndicator(int result)
        {
            _uiService.ShowWinIndicator(result > Constants.Constants.WinResult);
        }

        private void StartDiceTossing()
        {
            _gamePool.Dice.TossDice();
        }

        private void StopDiceTossing()
        {
            _gamePool.Dice.StopDice();
        }

        private int SetTossingResult()
        {
            var preResult = _diceResultCalculator.GetRandomResult();
            _gamePool.Dice.SetPreResult(preResult);
            return preResult;
        }

        private int AddBonus(int preResult)
        {
            var bonus = _diceResultCalculator.GetBonus();
            _gamePool.Dice.AddBonus(preResult + bonus);
            return preResult + bonus;
        }

        private void DisableUI()
        {
            _uiService.Deactivate();
        }

        private void EnableUI()
        {
            _uiService.Activate();
        }
    }
}
using Infrastructure.BonusSystem;
using Infrastructure.Factories;
using UnityEngine;

namespace Infrastructure.StateMachine.GameStates
{
    public class GameLoopState : IState
    {
        private readonly IBonusService _bonusService;
        private readonly IGameFactory _gameFactory;

        public GameLoopState(IGameFactory gameFactory, IBonusService bonusService)
        {
            _gameFactory = gameFactory;
            _bonusService = bonusService;
        }

        public void Enter(IStateMachine stateMachine)
        {
            InitBonuses();
            HideLoadingCurtain();
        }

        private void InitBonuses()
        {
            _gameFactory.CreateBonuses(_bonusService.GetRandomBonuses(Constants.Constants.BonusCount));
        }

        private void HideLoadingCurtain()
        {
            Object.FindObjectOfType<ScenePresets.ScenePresets>().LoadingCurtain.FadeOut();
        }
    }
}
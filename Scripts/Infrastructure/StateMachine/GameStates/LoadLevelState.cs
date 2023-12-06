using Infrastructure.Factories;
using Infrastructure.UI;
using UnityEngine;

namespace Infrastructure.StateMachine.GameStates
{
    public class LoadLevelState : IState
    {
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private readonly IUIService _uiService;

        public LoadLevelState(IUIFactory uiFactory, IUIService uiService, IGameFactory gameFactory)
        {
            _uiFactory = uiFactory;
            _uiService = uiService;
            _gameFactory = gameFactory;
        }

        public void Enter(IStateMachine stateMachine)
        {
            InitializeFactories();
            InitializeUI();
            InitializeDice();
            MoveNextState(stateMachine);
        }

        private void InitializeFactories()
        {
            var scenePresets = Object.FindObjectOfType<ScenePresets.ScenePresets>();
            var uiMediator = Object.FindObjectOfType<UIMediator>();
            _uiFactory.InitOnScene(scenePresets, uiMediator);
            _gameFactory.InitOnScene(scenePresets);
            _uiService.InitOnScene(uiMediator);
        }

        private void InitializeUI()
        {
            _uiService.InitHud();
        }

        private void InitializeDice()
        {
            _gameFactory.CreateDice();
        }

        private void MoveNextState(IStateMachine stateMachine)
        {
            stateMachine.Enter<GameLoopState>();
        }
    }
}
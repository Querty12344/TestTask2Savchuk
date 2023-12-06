using Infrastructure.AssetsManagement;
using Infrastructure.SceneManagement;

namespace Infrastructure.StateMachine.GameStates
{
    public class ResourceLoadingState : IState
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ISceneLoader _sceneLoader;
        private IStateMachine _stateMachine;

        public ResourceLoadingState(IAssetProvider assetProvider, ISceneLoader sceneLoader)
        {
            _assetProvider = assetProvider;
            _sceneLoader = sceneLoader;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _assetProvider.LoadAssets();
            _sceneLoader.Load("Game", MoveNextState);
        }

        private void MoveNextState()
        {
            _stateMachine.Enter<LoadLevelState>();
        }
    }
}
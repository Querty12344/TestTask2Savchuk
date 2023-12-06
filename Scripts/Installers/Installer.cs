using Infrastructure.AssetsManagement;
using Infrastructure.BonusSystem;
using Infrastructure.Bootstrap;
using Infrastructure.CoroutineRunner;
using Infrastructure.DiceTossingSystem;
using Infrastructure.Factories;
using Infrastructure.GamePool;
using Infrastructure.SceneManagement;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.GameStates;
using Infrastructure.UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private Bootstrap _bootstrap;

        public override void InstallBindings()
        {
            BindMainInfrastructure();
            BindGameLogic();
            BindFactories();
            BindUIServices();
            BindGameStates();
        }

        private void BindMainInfrastructure()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        }

        private void BindGameLogic()
        {
            Container.Bind<IBonusService>().To<BonusService>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromInstance(_bootstrap).AsSingle();
            Container.Bind<IDiceResultCalculator>().To<DiceResultCalculator>().AsSingle();
            Container.Bind<IDiceTosser>().To<DiceTosser>().AsSingle();
            Container.Bind<IGamePool>().To<GamePool>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }

        private void BindUIServices()
        {
            Container.Bind<IUIService>().To<UIService>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.Bind<GameLoopState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<ResourceLoadingState>().AsSingle();
        }
    }
}
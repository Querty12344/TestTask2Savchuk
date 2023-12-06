using Infrastructure.AssetsManagement;
using Infrastructure.UI;
using Infrastructure.UI.Elements;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private ScenePresets.ScenePresets _scene;
        private UIMediator _uiMediator;

        public UIFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void InitOnScene(ScenePresets.ScenePresets scene, UIMediator uiMediator)
        {
            _scene = scene;
            _uiMediator = uiMediator;
        }

        public Hud CreateHud()
        {
            var hud = Object.Instantiate(_assetProvider.Hud, _scene.UIRoot);
            hud.Construct(_uiMediator);
            return hud;
        }
    }
}
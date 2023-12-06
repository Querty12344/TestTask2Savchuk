using Infrastructure.UI;
using Infrastructure.UI.Elements;

namespace Infrastructure.Factories
{
    public interface IUIFactory
    {
        Hud CreateHud();
        void InitOnScene(ScenePresets.ScenePresets scene, UIMediator uiMediator);
    }
}
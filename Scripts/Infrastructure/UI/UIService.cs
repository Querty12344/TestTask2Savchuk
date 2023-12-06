using Infrastructure.Factories;
using Infrastructure.UI.Elements;

namespace Infrastructure.UI
{
    public class UIService : IUIService
    {
        private readonly IUIFactory _uiFactory;
        private Hud _hud;
        private UIMediator _uiMediator;

        public UIService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void InitOnScene(UIMediator uiMediator)
        {
            _uiMediator = uiMediator;
        }

        public void ShowWinIndicator(bool win)
        {
            _hud?.ShowWinIndicator(win);
        }

        public void InitHud()
        {
            if (_hud == null) _hud = _uiFactory.CreateHud();
        }

        public void Deactivate()
        {
            _uiMediator.OnUIDisabled?.Invoke();
        }

        public void Activate()
        {
            _uiMediator.OnUIEnabled?.Invoke();
        }
    }
}
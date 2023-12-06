namespace Infrastructure.UI
{
    public interface IUIService
    {
        void InitHud();
        void Deactivate();
        void Activate();
        void InitOnScene(UIMediator uiMediator);
        void ShowWinIndicator(bool win);
    }
}
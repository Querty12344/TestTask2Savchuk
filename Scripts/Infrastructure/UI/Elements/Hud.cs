using UnityEngine;

namespace Infrastructure.UI.Elements
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private TossButton _tossButton;
        [SerializeField] private GameObject _win;
        [SerializeField] private GameObject _lose;

        public void Construct(UIMediator uiMediator)
        {
            uiMediator.OnUIDisabled += _tossButton.Disable;
            _tossButton.Construct(uiMediator.TossDice);
            uiMediator.OnUIEnabled += _tossButton.Enable;
        }

        public void ShowWinIndicator(bool win)
        {
            _win.SetActive(win);
            _lose.SetActive(!win);
        }
    }
}
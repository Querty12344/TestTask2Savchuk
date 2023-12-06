using System;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.UI.Elements
{
    public class TossButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private Action _tossDice;

        public void Construct(Action tossDice)
        {
            _tossDice = tossDice;
        }

        public void Click()
        {
            _tossDice.Invoke();
        }

        public void Disable()
        {
            _button.interactable = false;
        }

        public void Enable()
        {
            _button.interactable = true;
        }
    }
}
using System;
using Infrastructure.DiceTossingSystem;
using UnityEngine;
using Zenject;

namespace Infrastructure.UI
{
    public class UIMediator : MonoBehaviour
    {
        private IDiceTosser _diceTosser;
        public Action OnUIDisabled;
        public Action OnUIEnabled;

        [Inject]
        public void Construct(IDiceTosser diceTosser)
        {
            _diceTosser = diceTosser;
            DontDestroyOnLoad(this);
        }

        public void TossDice()
        {
            _diceTosser.TossDice();
        }
    }
}
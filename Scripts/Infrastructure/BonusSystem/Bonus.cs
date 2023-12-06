using TMPro;
using UnityEngine;

namespace Infrastructure.BonusSystem
{
    public class Bonus : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private int _bonusValue;

        public int BonusValue
        {
            set
            {
                _bonusValue = value;
                _text.text = "+ " + value;
            }
            get => _bonusValue;
        }
    }
}
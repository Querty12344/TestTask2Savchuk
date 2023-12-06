using TMPro;
using UnityEngine;

namespace DiceComponents
{
    public class DiceResultIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void Hide()
        {
            _text.text = " ";
        }

        public void SetResult(string result)
        {
            _text.text = result;
        }
    }
}
using TMPro;
using UnityEngine;

namespace Effects
{
    public class BonusAddingText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _lerpSpeed;
        private float _startDistance;
        private Transform _target;

        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, _lerpSpeed);
            _text.alpha = Vector3.Distance(transform.position, _target.position) / _startDistance;
            if (Vector3.Distance(transform.position, _target.position) < Constants.Constants.BonusPositionEpsilon)
                Destroy(gameObject);
        }

        public void Init(string text, Transform target)
        {
            _target = target;
            _text.text = "+ " + text;
            _startDistance = Vector3.Distance(transform.position, _target.position);
        }
    }
}
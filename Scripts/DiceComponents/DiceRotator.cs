using System.Collections;
using UnityEngine;

namespace DiceComponents
{
    public class DiceRotator : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Transform _dice;
        private Coroutine _rotating;
        private Quaternion _startRotation;

        public void StartRotation()
        {
            _startRotation = _dice.rotation;
            _rotating = StartCoroutine(Rotating());
        }

        public void StopRotating()
        {
            StopCoroutine(_rotating);
            SetDefaultRotation();
        }

        private IEnumerator Rotating()
        {
            while (true)
            {
                _dice.rotation *= Quaternion.Euler(_rotationSpeed, -_rotationSpeed, _rotationSpeed);
                yield return new WaitForFixedUpdate();
            }
        }

        private void SetDefaultRotation()
        {
            _dice.rotation = _startRotation;
        }
    }
}
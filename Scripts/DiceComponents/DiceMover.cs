using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace DiceComponents
{
    public class DiceMover : MonoBehaviour
    {
        [SerializeField] private float _maxOffset;
        [SerializeField] private float _smooth;
        [SerializeField] private float _speed;
        [SerializeField] private Transform _dice;
        private readonly Random _random = new();
        private Coroutine _moving;
        private Vector3 _startPosition;

        public void StartMoving()
        {
            _startPosition = _dice.position;
            _moving = StartCoroutine(Moving());
        }

        public void StopMoving()
        {
            StopCoroutine(_moving);
            SetDefaultPosition();
        }

        private IEnumerator Moving()
        {
            var targetPos = CalculateNextRandomPos();
            var offset = Vector3.zero;
            while (true)
            {
                if ((targetPos - _dice.position).magnitude < Constants.Constants.PositionEpsilon)
                    targetPos = CalculateNextRandomPos();
                RecalculateOffset(ref offset, targetPos);
                _dice.position += offset;
                yield return new WaitForFixedUpdate();
            }
        }

        private void RecalculateOffset(ref Vector3 offset, Vector3 targetPos)
        {
            offset = 1 / (1 + _smooth) * (_smooth * offset + (targetPos - _dice.position).normalized * _speed);
        }

        private Vector3 CalculateNextRandomPos()
        {
            var randomHorizontalVector =
                new Vector3((float)_random.NextDouble(), (float)_random.NextDouble(), 0f).normalized;
            randomHorizontalVector.x *= _random.Next(-1, 2);
            randomHorizontalVector.y *= _random.Next(-1, 2);
            var targetPosition = _startPosition + randomHorizontalVector * _maxOffset;
            return targetPosition;
        }

        private void SetDefaultPosition()
        {
            _dice.position = _startPosition;
        }
    }
}
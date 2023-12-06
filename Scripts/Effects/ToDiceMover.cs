using UnityEngine;

namespace Effects
{
    public class ToDiceMover : MonoBehaviour
    {
        [SerializeField] private float _lerpSpeed;
        private Transform _dice;

        private void Start()
        {
            _dice = FindObjectOfType<ScenePresets.ScenePresets>().DiceRoot;
        }

        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _dice.position, _lerpSpeed);
        }
    }
}
using System.Collections;
using UnityEngine;

namespace Effects
{
    public class Effect : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;

        private void Start()
        {
            StartCoroutine(DestroyByTime());
        }

        private IEnumerator DestroyByTime()
        {
            yield return new WaitForSeconds(_lifeTime);
            if (gameObject) Destroy(gameObject);
        }
    }
}
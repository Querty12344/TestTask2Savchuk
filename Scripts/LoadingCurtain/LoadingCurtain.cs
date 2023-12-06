using System.Collections;
using UnityEngine;

namespace LoadingCurtain
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtain;
        [SerializeField] private float _fadeSpeed;

        public void FadeOut()
        {
            StartCoroutine(Fade());
        }

        private IEnumerator Fade()
        {
            while (_curtain.alpha > Constants.Constants.FadeEpsilon)
            {
                _curtain.alpha -= _fadeSpeed;
                yield return new WaitForFixedUpdate();
            }

            Destroy(gameObject);
        }
    }
}
using System;
using System.Collections;
using Infrastructure.CoroutineRunner;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action callBack = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, callBack));
        }

        private IEnumerator LoadScene(string name, Action callBack)
        {
            var loadScene = SceneManager.LoadSceneAsync(name);
            while (true)
            {
                if (loadScene.isDone)
                {
                    callBack?.Invoke();
                    break;
                }

                yield return null;
            }
        }
    }
}
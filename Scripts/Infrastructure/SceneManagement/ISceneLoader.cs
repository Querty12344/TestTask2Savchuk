using System;

namespace Infrastructure.SceneManagement
{
    public interface ISceneLoader
    {
        void Load(string sceneName, Action callBack = null);
    }
}
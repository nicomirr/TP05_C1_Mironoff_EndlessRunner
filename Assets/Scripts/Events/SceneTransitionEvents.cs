using System;
using Game.Data;

namespace Game.Events
{
    public static class SceneTransitionEvents
    {
        public static event Action<SceneToLoadSo> OnSceneChangeRequested;

        public static void RaiseSceneChangeRequested(SceneToLoadSo sceneToLoad)
        {
            OnSceneChangeRequested?.Invoke(sceneToLoad);
        }
    }
}



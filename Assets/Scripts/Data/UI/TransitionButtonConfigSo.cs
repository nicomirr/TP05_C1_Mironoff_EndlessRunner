using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "TransitionButtonSo", menuName = "Scriptable Objects/TransitionButtonSo")]
    public class TransitionButtonConfigSo : ScriptableObject
    {
        [SerializeField] private SceneToLoadSo _sceneToLoad;
        public SceneToLoadSo SceneToLoad => _sceneToLoad;

        [SerializeField] private bool _displayCursor;
        public bool DisplayCursor => _displayCursor;
    }
}

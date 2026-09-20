using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SceneToLoad", menuName = "Scriptable Objects/SceneToLoad")]
    public class SceneToLoadSo : ScriptableObject
    {
        [SerializeField] private string _sceneToLoadName;
        public string sceneToLoadName => _sceneToLoadName;

        [SerializeField] private float _transitionTime;
        public float TransitionTime => _transitionTime;
    }
}



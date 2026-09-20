using UnityEngine;

namespace Game.SceneTransitions
{
    public class FadeBackgroundController : MonoBehaviour
    {
        private static readonly int FADE_OUT_TRIGGER = Animator.StringToHash("fadeOut");

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void FadeOut()
        {
            _animator.SetTrigger(FADE_OUT_TRIGGER);
        }
    }
}


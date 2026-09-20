using UnityEngine;

namespace Game.UI
{
    public class UIAnimatedPanel : UIPanel
    {
        private static readonly int ShowTrigger = Animator.StringToHash("Show");
        private static readonly int HideTrigger = Animator.StringToHash("Hide");

        private Animator _animator;

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        public override void DisplayPanel()
        {
            base.DisplayPanel();
            _animator.SetTrigger(ShowTrigger);
        }

        public override void HidePanel()
        {
            _animator.SetTrigger(HideTrigger);
        }

        public void OnHideAnimationFinished()
        {
            base.HidePanel();          
        }
    }
}

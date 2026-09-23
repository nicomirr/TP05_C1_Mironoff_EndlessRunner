using UnityEngine;
using System.Collections;
using Game.Data;

namespace Game.UI
{
    public class UIClickableScalableObject : UIClickableObject
    {
        [SerializeField] private ScalableObjectConfigSo _scalerData;

        private Vector2 _originalScale;

        private void Start()
        {
            _originalScale = transform.localScale;
        }

        protected override void ClickReaction()
        {
            base.ClickReaction();

            StopAllCoroutines();
            StartCoroutine(ScaleObjectRoutine());
        }

        private IEnumerator ScaleObjectRoutine()
        {
            Vector2 newScale = new Vector2(_originalScale.x * _scalerData.ScaleMultiplier, _originalScale.y * _scalerData.ScaleMultiplier);

            this.transform.localScale = newScale;   

            yield return new WaitForSeconds(_scalerData.ScaleTime);

            this.transform.localScale = _originalScale;
        }
    }
}


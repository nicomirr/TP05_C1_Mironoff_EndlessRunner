using UnityEngine;
using UnityEngine.UI;
using Game.Events;
using Game.Data;

public class UITransitionButton : MonoBehaviour
{
    [SerializeField] private TransitionButtonConfigSo _data;

    private AudioSource _audioSource;
    private Button _button;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        _audioSource.Play();

        UIEvents.RaiseChangeCursorVisibilityRequest(_data.DisplayCursor);
        SceneTransitionEvents.RaiseSceneChangeRequested(_data.SceneToLoad);
    }
}

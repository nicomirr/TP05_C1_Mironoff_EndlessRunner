using Game.Data;
using Game.Events;
using System.Collections;
using UnityEngine;

public class DELETEME : MonoBehaviour
{
    [SerializeField] private SceneToLoadSo _data;

    private void OnEnable()
    {
        PlayerEvents.OnPlayerDeath += GoToMainMenu;
    }

    private void OnDisable()
    {
        PlayerEvents.OnPlayerDeath -= GoToMainMenu;
    }

    private void GoToMainMenu()
    {
        StartCoroutine(GoToMainMenuRoutine());
    }

    private IEnumerator GoToMainMenuRoutine()
    {
        yield return new WaitForSeconds(3);
        UIEvents.RaiseChangeCursorVisibilityRequest(true);
        SceneTransitionEvents.RaiseSceneChangeRequested(_data);
    }
}

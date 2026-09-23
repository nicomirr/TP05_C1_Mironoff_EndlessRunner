using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using TMPro;
using Game.Events;
using Game.Data;

namespace Game.UI
{
    public class UIScoreboard : UIAnimatedPanel
    {
        [SerializeField] private ScoreboardConfigSo _data;

        [SerializeField] private TMP_Text _scoreValueText;
        [SerializeField] private List<GameObject> _scoreMenuButtons;

        private void Start()
        {
            foreach(GameObject button in _scoreMenuButtons)
                button.SetActive(false);
        }

        private void OnEnable()
        {
            UIEvents.OnDisplayScoreboard += DisplayScoreboard;
        }

        private void OnDisable()
        {
            UIEvents.OnDisplayScoreboard -= DisplayScoreboard;
        }

        private void DisplayScoreboard(float scoreValue)
        {
            StartCoroutine(DisplayScoreboardRoutine(scoreValue));
        }

        private IEnumerator DisplayScoreboardRoutine(float scoreValue)
        {
            UIEvents.RaiseChangeCursorVisibilityRequest(true);

            yield return new WaitForSeconds(_data.BoardDelayTime);

            SetScoreValueText(scoreValue);
            DisplayPanel();

            yield return new WaitForSeconds(_data.BoardButtonsDelayTime);

            DisplayScoreMenuButtons();
        }

        private void SetScoreValueText(float scoreValue)
        {
            _scoreValueText.text = scoreValue.ToString("F2", CultureInfo.InvariantCulture) + " km";
        }

        private void DisplayScoreMenuButtons()
        {
            foreach (GameObject button in _scoreMenuButtons)
                button.SetActive(true);
        }

    }

}


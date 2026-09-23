using UnityEngine;
using TMPro;
using Game.Events;
using Game.Data;

namespace Game.UI
{
    public class UIPlayerScore : MonoBehaviour
    {
        private TMP_Text _scoreText;

        private void Awake()
        {
            _scoreText = GetComponentInChildren<TMP_Text>();
        }

        private void OnEnable()
        {
            UIEvents.OnPlayerScoreUpdated += UpdateScoreText;
            UIEvents.OnDisplayScoreboard += EmptyScoreText;
        }

        private void OnDisable()
        {
            UIEvents.OnPlayerScoreUpdated -= UpdateScoreText;
            UIEvents.OnDisplayScoreboard -= EmptyScoreText;
        }

        private void Start()
        {
            _scoreText.text = "0.00 km";
        }

        private void UpdateScoreText(float score)
        {
            float scoreInKm = score;

            _scoreText.text = scoreInKm.ToString("F2") + " km";
        }

        private void EmptyScoreText(float _)
        {
            _scoreText.text = "";
        }
    }

}


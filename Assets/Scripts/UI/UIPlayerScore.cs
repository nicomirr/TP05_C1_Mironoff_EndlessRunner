using UnityEngine;
using TMPro;
using Game.Events;
using Game.Data;

namespace Game.UI
{
    public class UIPlayerScore : MonoBehaviour
    {
        [SerializeField] private UIScoreConfigSo _data;
        private TMP_Text _scoreText;

        private void Awake()
        {
            _scoreText = GetComponentInChildren<TMP_Text>();
        }

        private void OnEnable()
        {
            UIEvents.OnPlayerScoreUpdated += UpdateScoreText;
        }

        private void OnDisable()
        {
            UIEvents.OnPlayerScoreUpdated -= UpdateScoreText;
        }

        private void Start()
        {
            _scoreText.text = "0.00 km";
        }

        private void UpdateScoreText(int score)
        {
            float scoreInKm = score / _data.ScoreUnitsPerKilometer;

            _scoreText.text = scoreInKm.ToString("F2") + " km";
        }
    }

}


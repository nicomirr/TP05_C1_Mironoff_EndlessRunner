using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIInstructions : MonoBehaviour
    {
        [SerializeField] private List<UIPanel> _instructions;

        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _previousButton;

        private AudioSource _audioSource;

        private int _currentIndex;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            _nextButton.onClick.AddListener(ShowNextInstruction);
            _previousButton.onClick.AddListener(ShowPreviousInstruction);
        }

        private void OnDestroy()
        {
            _nextButton.onClick.RemoveAllListeners();
            _previousButton.onClick.RemoveAllListeners();
        }

        private void ShowNextInstruction()
        {
            _audioSource.Play();

            int previousIndex = _currentIndex;

            _currentIndex++;

            if (_currentIndex == _instructions.Count)
                _currentIndex = 0;

            _instructions[previousIndex].HidePanel();
            _instructions[_currentIndex].DisplayPanel();          

        }

        private void ShowPreviousInstruction()
        {
            _audioSource.Play();

            int previousIndex = _currentIndex;

            _currentIndex--;

            if(_currentIndex < 0)
                _currentIndex = _instructions.Count - 1;

            _instructions[previousIndex].HidePanel();
            _instructions[_currentIndex].DisplayPanel();
        }


    }
}



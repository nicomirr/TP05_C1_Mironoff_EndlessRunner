using UnityEngine;
using System.Collections;

public class PlayerFlicker
{
    private readonly SpriteRenderer _spriteRenderer;
    private readonly Color32 _playerOriginalColor;

    public PlayerFlicker(SpriteRenderer spriteRenderer)
    {
        _spriteRenderer = spriteRenderer;
        _playerOriginalColor = _spriteRenderer.color;
    }

    public IEnumerator FlickerRoutine(float time, int totalBlinks, Color32 flickerColor)
    {
        int totalChanges = totalBlinks * 2;
        float flickInterval = time / totalChanges;

        for (int i = 0; i < totalChanges; i++)
        {
            if (_spriteRenderer.color == _playerOriginalColor)
                _spriteRenderer.color = flickerColor;
            else
                _spriteRenderer.color = _playerOriginalColor;

            yield return new WaitForSeconds(flickInterval);
        }

        _spriteRenderer.color = _playerOriginalColor;
    }
}

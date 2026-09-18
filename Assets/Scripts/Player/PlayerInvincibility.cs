using System;
using System.Collections;
using UnityEngine;

public class PlayerInvincibility
{
    private readonly SpriteRenderer _spriteRenderer;
            
    private bool _isInvincible;
    public bool IsInvincible => _isInvincible;

    public event Action OnInvincibilityFinalized;

    public PlayerInvincibility(SpriteRenderer spriteRenderer)
    {
        _spriteRenderer = spriteRenderer;
    }
  
    public IEnumerator InvincibilityTimerRoutine(float time, float warningTime, int totalWarningBlinks, Color32 invincibilityColor)
    {
        _isInvincible = true;

        Color32 originalColor = _spriteRenderer.color;
        _spriteRenderer.color = invincibilityColor;

        yield return new WaitForSeconds(time - warningTime);

        int totalColorChanges = totalWarningBlinks * 2;
        float blinkInterval = warningTime / totalColorChanges;

        for (int i = 0; i < totalColorChanges; i++)
        {
            if (_spriteRenderer.color == originalColor)
                _spriteRenderer.color = invincibilityColor;
            else
                _spriteRenderer.color = originalColor;

            yield return new WaitForSeconds(blinkInterval);
        }

        _spriteRenderer.color = originalColor;

        _isInvincible = false;

        OnInvincibilityFinalized?.Invoke();
    }
    
}

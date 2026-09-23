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
  
    public IEnumerator InvincibilityTimerRoutine(PlayerFlicker playerFlicker, float time, float warningTime, int totalWarningBlinks, Color32 invincibilityColor)
    {
        _isInvincible = true;

        _spriteRenderer.color = invincibilityColor;

        yield return new WaitForSeconds(time - warningTime);

        yield return playerFlicker.FlickerRoutine(warningTime, totalWarningBlinks, invincibilityColor);

        _isInvincible = false;

        OnInvincibilityFinalized?.Invoke();
    }   
}

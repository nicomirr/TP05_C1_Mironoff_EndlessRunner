using System.Collections;
using UnityEngine;

public class PlayerInvincibility
{
    private readonly SpriteRenderer _spriteRenderer;
            
    private bool _isInvincible;
    public bool IsInvincible => _isInvincible;

    public PlayerInvincibility(SpriteRenderer spriteRenderer)
    {
        _spriteRenderer = spriteRenderer;
    }
  
    public IEnumerator InvincibilityTimerRoutine(float time, Color32 invincibilityColor)
    {
        _isInvincible = true;
        _spriteRenderer.color = invincibilityColor;

        yield return new WaitForSeconds(time);

        _spriteRenderer.color = Color.white;
        _isInvincible = false;
    }
    
}

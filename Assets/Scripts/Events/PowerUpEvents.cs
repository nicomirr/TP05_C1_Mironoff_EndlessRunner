using System;
using UnityEngine;

public static class PowerUpEvents
{
    public static event Action<float, Color32> OnInvincibilityEnabled;

    public static void RaiseInvincibilityEnabled(float time, Color32 invincibilityColor)
    {
        OnInvincibilityEnabled?.Invoke(time, invincibilityColor);
    }
}

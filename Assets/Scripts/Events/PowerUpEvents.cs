using System;
using UnityEngine;

public static class PowerUpEvents
{
    public static event Action<float, float, int, Color32> OnInvincibilityAcquired;

    public static void RaiseInvincibilityAcquired(float time, float warningTime, int totalWarningBlinks, Color32 invincibilityColor)
    {
        OnInvincibilityAcquired?.Invoke(time, warningTime, totalWarningBlinks, invincibilityColor);
    }
}

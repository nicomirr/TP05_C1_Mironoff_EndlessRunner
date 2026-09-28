using UnityEngine;
using System;
using Game.Data;

public class SpeedProgression
{
    private SpeedProgressionTimer _speedProgressionTimer;

    private readonly float _speedProgresion;
    private readonly float _maxWorldSpeed;

    private bool _speedLimitReached;
    public event Action OnLimitReached;

    public SpeedProgression(GameStateConfigSo data)
    {
        _speedProgressionTimer = new SpeedProgressionTimer(data);

        _speedProgresion = data.SpeedProgression;
        _maxWorldSpeed = data.MaxWorldSpeed;
    }

    public bool TryIncreaseWorldSpeed(ref float speed)
    {
        if (_speedLimitReached) return false;

        if(speed < _maxWorldSpeed)
        {
            speed += _speedProgresion;
            speed = Mathf.Min(speed, _maxWorldSpeed);

            return true;
        }

        RaiseLimitReached();
        _speedLimitReached = true;        

        return false;   
    }

    private void RaiseLimitReached()
    {
        OnLimitReached?.Invoke();
    }

    public void Reset()
    {
        _speedLimitReached = false;
        _speedProgressionTimer.Reset();
    }

    public bool HandleSpeedProgression(ref float speed)
    {
        if (!_speedProgressionTimer.UpdateTimer()) return false;

        return TryIncreaseWorldSpeed(ref speed);                       
    }
}

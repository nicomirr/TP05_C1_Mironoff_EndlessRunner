using UnityEngine;
using Game.Data;
using System;

public class SpeedProgression
{
    private readonly float _speedProgresion;
    private readonly float _maxWorldSpeed;

    private bool _speedLimitReached;
    public event Action OnLimitReached;

    public SpeedProgression(GameStateConfigSo _data)
    {
        _speedProgresion = _data.SpeedProgression;
        _maxWorldSpeed = _data.MaxWorldSpeed;
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

        if(!_speedLimitReached)
        {
            RaiseLimitReached();
            _speedLimitReached = true;
        }

        return false;   
    }

    private void RaiseLimitReached()
    {
        OnLimitReached?.Invoke();
    }

    public void Reset()
    {
        _speedLimitReached = false;
    }
}

using UnityEngine;
using Game.Data;

public class SpeedProgressionTimer
{
    private readonly float _speedProgressionTime;
    
    private float _timer;

    public SpeedProgressionTimer(GameStateConfigSo _data)
    {
        _speedProgressionTime = _data.SpeedProgressionTime;
    }

    public bool UpdateTimer()
    {
        _timer += Time.deltaTime;

        if (_timer >= _speedProgressionTime)
        {
            _timer -= _speedProgressionTime; 
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _timer = 0;
    }
}

using Game.Data;
using UnityEngine;

public class SpeedProgression
{
    private readonly float _speedProgresion;
    private readonly float _maxWorldSpeed;
     

    public SpeedProgression(GameStateConfigSo _data)
    {
        _speedProgresion = _data.SpeedProgression;
        _maxWorldSpeed = _data.MaxWorldSpeed;
    }

    public bool TryIncreaseWorldSpeed(ref float speed)
    {
        if(speed < _maxWorldSpeed)
        {
            speed += _speedProgresion;
            speed = Mathf.Min(speed, _maxWorldSpeed);

            return true;
        }        

        return false;   
    }
}

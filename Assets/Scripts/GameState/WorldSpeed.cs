using Game.Data;
using UnityEngine;

public class WorldSpeed : MonoBehaviour, ISpeedProvider
{
    public float WorldBaseSpeed => _worldBaseSpeed;
    public float WorldCurrentSpeed => _worldCurrentSpeed;
    public float WorldMaxSpeed => _worldMaxSpeed;

    private float _worldBaseSpeed;
    private float _worldCurrentSpeed;
    private float _worldMaxSpeed;

    public void Initialize(RunnerStateConfigSo _data)
    {
        _worldBaseSpeed = _data.InitialWorldSpeed;
        _worldCurrentSpeed = _worldBaseSpeed;        
        _worldMaxSpeed = _data.MaxWorldSpeed;
    }

    public void UpdateSpeed(float speed)
    {
        _worldCurrentSpeed = speed;
    }

}

using Game.Data;
using UnityEngine;

public class WorldSpeed : MonoBehaviour, ISpeedProvider
{
    public float WorldBaseSpeed => _worldBaseSpeed;
    public float WorldCurrentSpeed => _worldCurrentSpeed;

    private float _worldBaseSpeed;
    private float _worldCurrentSpeed;

    public void Initialize(RunnerStateConfigSo _data)
    {
        _worldBaseSpeed = _data.InitialWorldSpeed;
        _worldCurrentSpeed = _worldBaseSpeed;
    }

    public void UpdateSpeed(float speed)
    {
        _worldCurrentSpeed = speed;
    }

}

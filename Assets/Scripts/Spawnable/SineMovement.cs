using UnityEngine;
using Game.Data;

namespace Game.Spawnable
{
    public class SineMovement : MonoBehaviour, ISpawnableMovementPattern
    {
        [SerializeField] private SineMovementDataSo _data;        

        private float _time;

        public Vector2 CalculateVelocity(float speed, float speedMod)
        {
            _time += Time.deltaTime;

            float angularFrequency = _data.Frequency * Mathf.PI * 2f;

            float verticalSpeed = _data.Amplitude * angularFrequency * Mathf.Cos(angularFrequency * _time);

            return new Vector2(-speed * speedMod, verticalSpeed);
        }
    }
}
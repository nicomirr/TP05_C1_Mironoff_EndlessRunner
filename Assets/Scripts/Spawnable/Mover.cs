using UnityEngine;

public class Mover : MonoBehaviour
{
    //Tiene que ser global para todos y aumentar con el tiempo la speed
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity =  Vector2.left * _speed;
    }
}

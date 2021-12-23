using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private PlayerInput _playerInput;

    public void Init()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    private void OnEnable()
    {
        _playerInput.Roll += OnRoll;
    }

    private void OnDisable()
    {
        _playerInput.Roll -= OnRoll;
    }

    private void OnRoll(Vector2 direction)
    {
        _direction = Vector3.right * direction.x + Vector3.forward * direction.y;
        _rigidbody.velocity = _direction * _speed + Vector3.up * _rigidbody.velocity.y*Time.fixedDeltaTime;
        
    }

}

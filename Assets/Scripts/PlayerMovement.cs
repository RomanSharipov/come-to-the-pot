using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPowerUp;
    [SerializeField] private float _jumpPowerForward;
    [SerializeField] private float _delayBeforeJump;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private PlayerInput _playerInput;

    public void Init()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput.Roll += OnRoll;
        StartCoroutine(Jump());
    }

    private void OnDisable()
    {
        _playerInput.Roll -= OnRoll;
    }

    private void OnRoll(Vector2 direction)
    {
        _direction = Vector3.right * direction.x + Vector3.forward * direction.y;
        _rigidbody.velocity = _direction * _speed + Vector3.up * _rigidbody.velocity.y;
    }

    public IEnumerator Jump()
    {
        var waitForSeconds = new WaitForSeconds(_delayBeforeJump);
        yield return waitForSeconds;
        _rigidbody.AddForce(new Vector3(0 , _jumpPowerUp, _jumpPowerForward), ForceMode.Impulse);
    }
}

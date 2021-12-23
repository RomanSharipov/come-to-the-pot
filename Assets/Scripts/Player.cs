using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Transform _transform;

    public void Init()
    {
        _transform = GetComponent<Transform>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerMovement.Init();
    }

    public Vector3 GetCurrentPosition()
    {
        return _transform.position;
    }
}

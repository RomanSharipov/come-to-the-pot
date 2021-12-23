using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public Vector3 GetCurrentPosition()
    {
        return _transform.position;
    }
}

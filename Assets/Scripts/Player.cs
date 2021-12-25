using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _delayBeforeSwichOnControl;

    private PlayerMovement _playerMovement;
    private PlayerInput _playerInput;
    private Transform _transform;

    public void Init()
    {
        _transform = GetComponent<Transform>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement.Init();
        StartCoroutine(SwichOnControl());
    }

    public Vector3 GetCurrentPosition()
    {
        return _transform.position;
    }

    public IEnumerator SwichOnControl()
    {
        var waitForSeconds = new WaitForSeconds(_delayBeforeSwichOnControl);
        yield return waitForSeconds;
        _playerInput.enabled = true;
    }
}

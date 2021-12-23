using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Transform _transform;
    private float offset;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        offset = _player.GetCurrentPosition().z - _transform.position.z;
    }

    private void Update()
    {
        _transform.position = new Vector3(_player.GetCurrentPosition().x, _transform.position.y, _player.GetCurrentPosition().z - offset);
    }
}

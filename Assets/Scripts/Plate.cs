using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private float _speed;

    private Coroutine _moveJob;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private IEnumerator Move(Vector3 _targetPosition)
    {
        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime * _speed);
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.transform.parent = gameObject.transform;
            if (_moveJob != null)
            {
                StopCoroutine(_moveJob);
                _moveJob = null;
            }
            _moveJob = StartCoroutine(Move(_endPosition));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.transform.parent = null;
            if (_moveJob != null)
            {
                StopCoroutine(_moveJob);
                _moveJob = null;
            }
            _moveJob = StartCoroutine(Move(_startPosition));
        }
    }
}

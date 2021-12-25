using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriedEgg : MonoBehaviour
{
    [SerializeField] private Vector3 _targetWidth;
    [SerializeField] private float _speed;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        StartCoroutine(Deliquesce());
    }

    private IEnumerator Deliquesce()
    {
        while (_transform.localScale.x < _targetWidth.x)
        {
            _transform.localScale = Vector3.Lerp(_transform.localScale, _targetWidth, Time.deltaTime * _speed);
            yield return null;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(Deliquesce());
    }
}

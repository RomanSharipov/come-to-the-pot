using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ch.sycoforge.Decal;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _delayBeforeSwichOnControl;
    [SerializeField] private int _health;
    [SerializeField] private EasyDecal _crackEgg;    [SerializeField] private FriedEgg _friedEgg;    [SerializeField] private GameObject _shardsTemplate;

    private PlayerMovement _playerMovement;
    private PlayerInput _playerInput;
    private Transform _transform;
    private MeshRenderer _meshRenderer;
    private MeshCollider _meshCollider;
    private Vector3 directionToface;
    private Quaternion _crackEggRotation;
    public void Init()
    {
        _transform = GetComponent<Transform>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshCollider = GetComponent<MeshCollider>();
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

    public void TakeDamage(Vector3 collisionPoint)
    {
        if (_health > 0)
        {
            _health--;
            EasyDecal.ProjectAt(_crackEgg.gameObject, _transform.gameObject, collisionPoint, GetCrackRotation(collisionPoint));
        }
        else
        {
            Die();
        }
    }

    private Quaternion GetCrackRotation(Vector3 collisionPoint)
    {
        directionToface = _transform.localPosition - collisionPoint;
        return Quaternion.LookRotation(directionToface) * Quaternion.Euler(90, 0, 0);
    }

    private void Die()
    {
        _meshRenderer.enabled = false;
        _meshCollider.enabled = false;
        Instantiate(_shardsTemplate, _transform.position, _transform.rotation);
        Instantiate(_friedEgg, _transform.position, Quaternion.identity);
    }
}

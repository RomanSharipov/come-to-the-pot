using UnityEngine;
using UnityEngine.Events;


public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    public event UnityAction<Vector2> Roll;

    private Vector2 _direction = new Vector2();

    private void FixedUpdate()
    {
        _direction = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        Roll?.Invoke(_direction);
    }
}
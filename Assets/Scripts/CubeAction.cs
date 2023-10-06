using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class CubeAction : MonoBehaviour
{
    private readonly float _pushForce = 15f;

    private IInputMode _inputMode;
    private Rigidbody _rigidbody;

    public void Init()
    {
        _inputMode.OnPushCube += Push;
        _inputMode.OnPushCube += ResetComponent;

        _inputMode.OnMoveCube += Move;

        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Push()
    {
        Vector3 forceDirection = transform.forward;
        _rigidbody.AddForce(forceDirection * _pushForce, ForceMode.Impulse);
    }

    private void Move(Vector3 targetPosition)
    {
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(targetPosition.x, currentPosition.y, currentPosition.z);
    }

    private void ResetComponent()
    {
        _inputMode.OnPushCube -= Push;
        _inputMode.OnPushCube -= ResetComponent;

        _inputMode.OnMoveCube -= Move;

        Destroy(this);
    }

    [Inject]
    public void Construct(IInputMode inputMode)
    {
        _inputMode = inputMode;
    }
}

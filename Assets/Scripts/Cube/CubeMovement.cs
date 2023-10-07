using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class CubeMovement : MonoBehaviour
{
    private readonly float _pushForce = 15f;

    private IInputMode _inputMode;
    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init()
    {
        _inputMode.OnPushCube += Push;
        _inputMode.OnMoveCube += SetPosition;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX;

        enabled = true;
    }

    public void ResetMovement()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void Push()
    {
        Vector3 forceDirection = Vector3.forward;
        _rigidbody.AddForce(forceDirection * _pushForce, ForceMode.Impulse);

        ResetComponent();
        enabled = false;
    }

    private void SetPosition(Vector3 targetPosition)
    {
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(targetPosition.x, currentPosition.y, currentPosition.z);
    }

    private void ResetComponent()
    {
        _inputMode.OnPushCube -= Push;
        _inputMode.OnMoveCube -= SetPosition;
    }

    [Inject]
    public void Construct(IInputMode inputMode)
    {
        _inputMode = inputMode;
    }
}

using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private CubeFactory _cubeFactory;

    private IInputMode _inputMode;

    private void Awake()
    {
        StartCoroutine(_cubeFactory.CreateCubeWithDelay());

        _inputMode.Init();
        _inputMode.OnPushCube += OnPushCube;
    }

    private void OnPushCube()
    {
        StartCoroutine(_cubeFactory.CreateCubeWithDelay());
    }

    [Inject]
    public void Construct(IInputMode inputMode)
    {
        _inputMode = inputMode;
    }
}

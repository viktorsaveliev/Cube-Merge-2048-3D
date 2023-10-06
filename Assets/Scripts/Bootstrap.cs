using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private IInputMode _inputMode;
    private CubeSpawner _cubeSpawner;

    private void Awake()
    {
        _inputMode.Init();
        _cubeSpawner.Init();
    }

    [Inject]
    public void Construct(IInputMode inputMode, CubeSpawner cubeSpawner)
    {
        _inputMode = inputMode;
        _cubeSpawner = cubeSpawner;
    }
}

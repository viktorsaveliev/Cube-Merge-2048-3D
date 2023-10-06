using Zenject;

public class CubeSpawner
{
    private IInputMode _inputMode;
    private CubeFactory _cubeFactory;

    public void Init()
    {
        _cubeFactory.CreateCube();
        _inputMode.OnPushCube += OnPushCube;
    }

    private void OnPushCube()
    {
        _cubeFactory.CreateCube();
    }

    [Inject]
    public void Construct(IInputMode inputMode, CubeFactory cubeFactory)
    {
        _inputMode = inputMode;
        _cubeFactory = cubeFactory;
    }
}

using Zenject;

public class CubeSpawner
{
    private IInputMode _inputMode;
    private CubeFactory _cubeFactory;

    public void Init()
    {
        _cubeFactory.CreatePool();
        _cubeFactory.ShowFreeCube();
        _inputMode.OnPushCube += OnPushCube;
    }

    private void OnPushCube()
    {
        _cubeFactory.ShowFreeCube();
    }

    [Inject]
    public void Construct(IInputMode inputMode, CubeFactory cubeFactory)
    {
        _inputMode = inputMode;
        _cubeFactory = cubeFactory;
    }
}

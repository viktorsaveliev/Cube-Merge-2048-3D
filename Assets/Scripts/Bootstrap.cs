using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private IInputMode _inputMode;
    private CubeSpawner _cubeSpawner;
    private ScoreView _scoreView;

    private void Awake()
    {
        _inputMode.Init();
        _cubeSpawner.Init();
        _scoreView.Init();
    }

    [Inject]
    public void Construct(IInputMode inputMode, CubeSpawner cubeSpawner, ScoreView scoreView)
    {
        _inputMode = inputMode;
        _cubeSpawner = cubeSpawner;
        _scoreView = scoreView;
    }
}

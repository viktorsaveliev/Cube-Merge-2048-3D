using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private IInputMode _inputMode;
    private CubeSpawner _cubeSpawner;
    private ScoreView _scoreView;
    private LoseScreen _loseScreen;

    private void Awake()
    {
        _inputMode.Init();
        _cubeSpawner.Init();
        _scoreView.Init();
        _loseScreen.Init();
    }

    [Inject]
    public void Construct(IInputMode inputMode, 
        CubeSpawner cubeSpawner, 
        ScoreView scoreView,
        LoseScreen loseScreen)
    {
        _inputMode = inputMode;
        _cubeSpawner = cubeSpawner;
        _scoreView = scoreView;
        _loseScreen = loseScreen;
    }
}

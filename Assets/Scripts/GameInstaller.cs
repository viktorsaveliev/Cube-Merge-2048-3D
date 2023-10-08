using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private CubeFactory _cubeFactory;
    [SerializeField] private ScoreView _scoreView;

    [SerializeField] private LoseArea _loseArea;
    [SerializeField] private LoseScreen _loseScreen;

    private readonly IInputMode _inputMode = new InputPC();

    public override void InstallBindings()
    {
        Container.Bind<IInputMode>().FromInstance(_inputMode).AsSingle();
        Container.Bind<CubeFactory>().FromInstance(_cubeFactory).AsSingle();
        Container.Bind<ScoreView>().FromInstance(_scoreView).AsSingle();

        Container.Bind<LoseArea>().FromInstance(_loseArea).AsSingle();
        Container.Bind<LoseScreen>().FromInstance(_loseScreen).AsSingle();

        Container.Bind<CubeSpawner>().FromNew().AsSingle();
        Container.Bind<ScoreCounter>().FromNew().AsSingle();
    }
}

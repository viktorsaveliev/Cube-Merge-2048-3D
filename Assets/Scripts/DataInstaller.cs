using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller
{
    [SerializeField] private CubeFactory _cubeFactory;

    private readonly IInputMode _inputMode = new InputPC();

    public override void InstallBindings()
    {
        Container.Bind<IInputMode>().FromInstance(_inputMode).AsSingle();
        Container.Bind<CubeFactory>().FromInstance(_cubeFactory).AsSingle();
        Container.Bind<CubeSpawner>().FromNew().AsSingle();
    }
}

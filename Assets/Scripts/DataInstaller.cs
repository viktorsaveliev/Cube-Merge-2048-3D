using Zenject;

public class DataInstaller : MonoInstaller
{
    private readonly IInputMode _inputMode = new InputPC();

    public override void InstallBindings()
    {
        Container.Bind<IInputMode>().FromInstance(_inputMode).AsSingle();
    }
}

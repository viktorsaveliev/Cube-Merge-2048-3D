using UnityEngine;

[RequireComponent(typeof(CubeMovement), typeof(CubeMerge), typeof(CubeView))]
public class Cube : MonoBehaviour
{
    private CubeMovement _movement;
    private CubeMerge _cubeMerge;
    private CubeView _view;

    private void Awake()
    {
        _cubeMerge = GetComponent<CubeMerge>();
        _movement = GetComponent<CubeMovement>();
        _view = GetComponent<CubeView>();
    }
     
    public void Init()
    {
        _movement.Init();
    }

    public void ResetData()
    {
        _cubeMerge.ResetData();
        _movement.ResetMovement();
        _view.UpdateView();
    }
}

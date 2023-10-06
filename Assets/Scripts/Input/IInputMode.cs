using System;
using UnityEngine;

public interface IInputMode
{
    public event Action OnPushCube;
    public event Action<Vector3> OnMoveCube;

    public void CheckInput();
    public void Init();
}

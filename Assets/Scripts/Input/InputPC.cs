using System;
using UnityEngine;

public class InputPC : IInputMode
{
    public event Action OnPushCube;
    public event Action<Vector3> OnMoveCube;

    private Camera _camera;

    private readonly float _antiflood = 0.5f;
    private float _currentFloodTime;

    public void CheckInput()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            if (Time.time <= _currentFloodTime) return;

            OnPushCube?.Invoke();

            _currentFloodTime = Time.time + _antiflood;
        }

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            Vector3 targetPosition = hit.point + Vector3.up;
            OnMoveCube?.Invoke(targetPosition);
        }
    }

    public void Init()
    {
        _camera = Camera.main;
    }
}

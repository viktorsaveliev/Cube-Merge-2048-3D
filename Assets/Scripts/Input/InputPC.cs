using System;
using UnityEngine;

public class InputPC : IInputMode
{
    public event Action OnPushCube;
    public event Action<Vector3> OnMoveCube;

    private Camera _camera;

    private readonly float _antiflood = 0.5f;
    private readonly float _limitPosX = 3f;

    private float _currentFloodTime;
    private LayerMask _groundMask;

    private bool _isAim;

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _isAim = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            if (Time.time <= _currentFloodTime) return;

            OnPushCube?.Invoke();
            _isAim = false;

            _currentFloodTime = Time.time + _antiflood;
        }

        if (_isAim)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundMask))
            {
                Vector3 targetPosition = FixEdges(hit.point + Vector3.up);
                OnMoveCube?.Invoke(targetPosition);
            }
        }
    }

    public void Init()
    {
        _camera = Camera.main;
        _groundMask = LayerMask.GetMask("Ground");
    }

    private Vector3 FixEdges(Vector3 position)
    {
        if (position.x < -_limitPosX)
        {
            position.x = -_limitPosX;
        }
        else if(position.x > _limitPosX)
        {
            position.x = _limitPosX;
        }

        return position;
    }
}

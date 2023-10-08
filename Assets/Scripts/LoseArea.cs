using System;
using UnityEngine;

public class LoseArea : MonoBehaviour
{
    public event Action OnGameOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CubeMovement cube) && !cube.enabled)
        {
            OnGameOver?.Invoke();
        }
    }
}

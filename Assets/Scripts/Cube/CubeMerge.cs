using System;
using UnityEngine;

public class CubeMerge : MonoBehaviour
{
    public event Action<CubeMerge> OnCubeMerged;

    private int _currentLevel;
    private int _currentNumeric = 2;

    public int CurrentLevel => _currentLevel;
    public int CurrentNumeric => _currentNumeric;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out CubeMerge cube))
        {
            TryMerge(cube);
        }
    }

    public bool TryMerge(CubeMerge target)
    {
        if (target.CurrentLevel != _currentLevel) return false;

        UpdateLevel();
        OnCubeMerged?.Invoke(target);

        return true;
    }

    public void UpdateLevel()
    {
        _currentLevel++;
        _currentNumeric *= 2;
    }
}

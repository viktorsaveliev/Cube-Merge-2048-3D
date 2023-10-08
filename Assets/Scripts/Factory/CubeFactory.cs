using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CubeFactory : MonoBehaviour
{
    public event Action OnCubeSpawned;

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _cubesContainer;

    [Inject] private readonly DiContainer _diContainer;

    private readonly List<Cube> _cubesPool = new();

    private const int MAX_CUBES = 30;

    private const float _delayForSpawn = 0.3f;
    private readonly WaitForSeconds _delayCache = new(_delayForSpawn);

    public void CreatePool()
    {
        for (int i = 0; i < MAX_CUBES; i++)
        {
            _cubesPool.Add(CreateCube());
        }
    }

    public void ShowFreeCube()
    {
        bool full = false;

        foreach (var cube in _cubesPool)
        {
            if (cube.gameObject.activeSelf) continue;
            StartCoroutine(ShowCubeWithDelay(cube));
            full = true;
            break;
        }

        if (!full)
        {
            CreatePool();
            ShowFreeCube();
            throw new Exception("Pool increased");
        }
    }

    private IEnumerator ShowCubeWithDelay(Cube cube)
    {
        yield return _delayCache;

        cube.ResetData();
        cube.Init();

        cube.transform.SetPositionAndRotation(_startPosition.position, Quaternion.Euler(0, 0, 0));
        cube.gameObject.SetActive(true);

        Vector3 cubeScale = cube.transform.localScale;
        cube.transform.localScale = Vector3.zero;
        cube.transform.DOScale(cubeScale, 0.5f).SetEase(Ease.OutBack);

        OnCubeSpawned?.Invoke();
    }

    private Cube CreateCube()
    {
        GameObject cubeObject = _diContainer.InstantiatePrefab(
            _cubePrefab, _startPosition.position, Quaternion.identity, _cubesContainer);

        Cube cube = cubeObject.GetComponent<Cube>();

        cube.gameObject.SetActive(false);
        return cube;
    }
}
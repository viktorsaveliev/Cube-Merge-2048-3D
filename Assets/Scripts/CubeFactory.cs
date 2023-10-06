using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class CubeFactory : MonoBehaviour
{
    public event Action OnCubeCreated;

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _startPosition;

    [Inject] private readonly DiContainer _container;

    private const float _delayForSpawn = 0.3f;
    private readonly WaitForSeconds _delayCache = new(_delayForSpawn);

    public void CreateCube()
    {
        StartCoroutine(CreateCubeWithDelay());
    }

    private IEnumerator CreateCubeWithDelay()
    {
        yield return _delayCache;
        CreateCubeNonLazy();
    }

    private void CreateCubeNonLazy()
    {
        GameObject cubeObject = _container.InstantiatePrefab(
            _cubePrefab, _startPosition.position, Quaternion.identity, null);

        CubeMovement cube = cubeObject.GetComponent<CubeMovement>();
        cube.Init();

        Vector3 cubeScale = cube.transform.localScale;
        cube.transform.localScale = Vector3.zero;
        cube.transform.DOScale(cubeScale, 0.5f).SetEase(Ease.OutBack);

        OnCubeCreated?.Invoke();
    }
}
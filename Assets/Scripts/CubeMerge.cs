using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class CubeMerge : MonoBehaviour
{
    public bool IsMerge;

    private Rigidbody _rigidbody;
    private int _currentLevel;

    private readonly float _moveDuration = 0.2f;
    private readonly float _lookAtDuration = 0.2f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public int CurrentLevel => _currentLevel;

    public bool TryMerge(CubeMerge target)
    {
        if (target.CurrentLevel != _currentLevel || IsMerge || target.IsMerge) return false;

        _currentLevel++;

        IsMerge = true;
        target.IsMerge = true;

        MergeAnimation(target);

        return true;
    }

    private void MergeAnimation(CubeMerge target)
    {
        float lerpFactor = 0.5f;
        Vector3 positionBetweenObjects = Vector3.Lerp(transform.position, target.transform.position, lerpFactor);

        transform.DOShakeScale(0.3f, 0.5f);

        target.transform.DOShakeScale(0.3f, 0.5f);
        target.transform.DOLookAt(transform.position, _lookAtDuration).OnComplete(() =>
        {
            transform.DOMove(positionBetweenObjects, _moveDuration);
            target.transform.DOMove(positionBetweenObjects, _moveDuration)
            .OnComplete(() =>
            {
                _rigidbody.constraints = RigidbodyConstraints.None;

                IsMerge = false;
                target.IsMerge = false;

                Destroy(target.gameObject);
            });
        });
    }
}

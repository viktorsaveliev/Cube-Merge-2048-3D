using UnityEngine;

[RequireComponent(typeof(CubeMerge))]
public class CubeCollision : MonoBehaviour
{
    private CubeMerge _cubeMerge;

    private void Awake()
    {
        _cubeMerge = GetComponent<CubeMerge>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out CubeMerge cube))
        {
            _cubeMerge.TryMerge(cube);
        }
    }
}

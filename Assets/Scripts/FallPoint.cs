using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FallPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}

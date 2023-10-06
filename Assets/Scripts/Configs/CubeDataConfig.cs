using UnityEngine;

[CreateAssetMenu(fileName = "CubeDataConfig", menuName = "Game/CubeDataConfig")]
public class CubeDataConfig : ScriptableObject
{
    [SerializeField] private Material[] _materials;
    public Material[] Materials => _materials;
}

using TMPro;
using UnityEngine;

[RequireComponent(typeof(CubeMerge))]
public class CubeView : MonoBehaviour
{
    [SerializeField] private CubeDataConfig _dataConfig;

    [SerializeField] private TMP_Text[] _numbers;
    [SerializeField] private ParticleSystem _mergeFX;

    private Renderer _particleRenderer;
    private CubeMerge _cubeMerge;
    private Rigidbody _rigidbody;
    private MeshRenderer _meshRenderer;

    private CubeView _targetView;

    private readonly float _jumpForce = 4.5f;

    private void Awake()
    {
        _cubeMerge = GetComponent<CubeMerge>();
        _cubeMerge.OnCubeMerged += OnCubeMerged;

        _rigidbody = GetComponent<Rigidbody>();
        _particleRenderer = _mergeFX.GetComponent<Renderer>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void UpdateColor()
    {
        if (_cubeMerge.CurrentLevel < _dataConfig.Materials.Length)
        {
            _meshRenderer.material = _dataConfig.Materials[_cubeMerge.CurrentLevel];
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdateView()
    {
        UpdateColor();
        UpdateNumbers();
    }

    private void UpdateNumbers()
    {
        foreach (var number in _numbers)
        {
            number.text = $"{_cubeMerge.CurrentNumeric}";
        }
    }

    private void OnCubeMerged(CubeMerge target)
    {
        _targetView = target.GetComponent<CubeView>();
        _targetView.Hide();

        MergeAnimation();
        UpdateColor();
        UpdateNumbers();

        _particleRenderer.material = _dataConfig.Materials[_cubeMerge.CurrentLevel];
        _mergeFX.Play();
    }

    private void MergeAnimation()
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}

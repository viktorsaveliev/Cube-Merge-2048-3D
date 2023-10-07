using TMPro;
using UnityEngine;
using Zenject;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreUI;

    private ScoreCounter _scoreCounter;

    public void Init()
    {
        _scoreCounter.OnScoreChanged += UpdateScore;
    }

    private void UpdateScore(int score)
    {
        _scoreUI.text = $"{score}";
    }

    [Inject]
    public void Construct(ScoreCounter score)
    {
        _scoreCounter = score;
    }
}

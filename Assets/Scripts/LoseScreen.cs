using TMPro;
using UnityEngine;
using Zenject;
using DG.Tweening;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private GameObject _loseUI;

    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _scoreNumeric;
    [SerializeField] private TMP_Text _restartText;

    private readonly float _backgroundFadeDuration = 1f;

    public readonly float _targetFontSize = 36f;
    public readonly float _fontSizeDuration = 0.5f;

    private LoseArea _loseArea;
    private ScoreCounter _scoreCounter;

    public void Init()
    {
        _loseArea.OnGameOver += ShowLoseScreen;
    }

    private void ShowLoseScreen()
    {
        _loseUI.SetActive(true);

        _scoreNumeric.text = $"{_scoreCounter.Score}";
        _background.DOFade(1, _backgroundFadeDuration);

        DOTween.To(() => _restartText.fontSize, newSize => _restartText.fontSize = newSize, _targetFontSize, _fontSizeDuration)
            .SetLoops(-1, LoopType.Yoyo);
    }

    [Inject]
    public void Construct(LoseArea area, ScoreCounter score)
    {
        _scoreCounter = score;
        _loseArea = area;
    }
}

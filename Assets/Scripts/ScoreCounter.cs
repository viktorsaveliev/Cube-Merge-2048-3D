using System;

public class ScoreCounter
{
    public event Action<int> OnScoreChanged;

    private int _score = 0;
    public int Score => _score;

    public void AddScore(int amount)
    {
        _score += amount;
        OnScoreChanged?.Invoke(_score);
    }
}

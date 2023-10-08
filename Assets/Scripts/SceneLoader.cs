using DG.Tweening;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public enum Scene
    {
        Level
    }

    public void LoadLevel()
    {
        ResetData();
        SceneManager.LoadSceneAsync((int) Scene.Level, LoadSceneMode.Single);
    }

    private void ResetData()
    {
        DOTween.Clear();
    }
}

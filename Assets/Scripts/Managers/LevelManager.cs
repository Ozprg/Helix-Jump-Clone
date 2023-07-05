using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.Instance.onLevelFailed += OnLevelFailed;
        EventManager.Instance.onLevelCompleted += OnLevelCompleted;
    }
    private void OnDisable()
    {
        EventManager.Instance.onLevelFailed -= OnLevelFailed;
        EventManager.Instance.onLevelCompleted -= OnLevelCompleted;
    }

    private void OnLevelCompleted()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
            return;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }        
    }

    private void OnLevelFailed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
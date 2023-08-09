using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void OnGameStarted()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnLevelCompleted()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(1);
            return;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }        
    }
    public void OnLevelFailed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
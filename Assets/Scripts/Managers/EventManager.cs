using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Action onLevelFailed;
    public Action onLevelCompleted;
    public Action onPointCollected;

    #region Singleton
    public static EventManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }
    #endregion
    public void LevelFailed()
    {
        onLevelFailed?.Invoke();
    }
    public void LevelCompleted()
    {
        onLevelCompleted?.Invoke();
    }
    public void PointCollected()
    {
        onPointCollected?.Invoke();
    }
}
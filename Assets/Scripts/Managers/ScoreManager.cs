using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float totalScore;
    public float TotalScore { get{ return totalScore; } set { totalScore = value; } }
    public static ScoreManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void OnEnable()
    {
        EventManager.Instance.onPointCollected += OnPointCollected;
    }
    void Start()
    {
        totalScore = 0;
    }
    private void OnDisable()
    {
        EventManager.Instance.onPointCollected -= OnPointCollected;
    }
    private void OnPointCollected()
    {
       totalScore += 10;
    }
}
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Update()
    {
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {
        scoreText.text = "Total Score : " + ScoreManager.Instance.TotalScore.ToString();
    }
}

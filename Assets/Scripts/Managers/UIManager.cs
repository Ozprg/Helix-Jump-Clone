using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject restartButton;

    private void OnEnable()
    {
        EventManager.Instance.onLevelCompleted += EnableNextLevelButton;
        EventManager.Instance.onLevelFailed += EnableRestartButton;
    }
    private void OnDisable()
    {
        EventManager.Instance.onLevelCompleted -= EnableNextLevelButton;
        EventManager.Instance.onLevelFailed -= EnableRestartButton;
    }
    private void Awake()
    {
        nextLevelButton.SetActive(false);
        restartButton.SetActive(false);
    }
    private void Update()
    {
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {
        scoreText.text = "Total Score : " + ScoreManager.Instance.TotalScore.ToString();
    }
    private void EnableNextLevelButton()
    {
        nextLevelButton.SetActive(true);
    }
    private void EnableRestartButton()
    {
        restartButton.SetActive(true);
    }
}

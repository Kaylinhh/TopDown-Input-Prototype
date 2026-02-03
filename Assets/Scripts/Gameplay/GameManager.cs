using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Timer Settings")]
    public float gameTime = 30f;
    public TMP_Text timerText;
    public GameObject gameOverPanel;

    [Header("Score / Highscore")]
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    private float currentTime;
    private bool isGameOver = false;
    public bool IsGameOver
    {
        get { return isGameOver; }
    }

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        currentTime = gameTime;
        UpdateTimerUI();

        if (highScoreText != null)
            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            GameOver();
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int seconds = Mathf.CeilToInt(currentTime);
            timerText.text = "Time left: " + seconds;
        }
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);

        int currentScore = ScoreManager.instance != null ? ScoreManager.instance.GetScore() : 0;
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
            highScore = currentScore;
        }

        // Update UI
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;
        if (highScoreText != null)
            highScoreText.text = "Highscore: " + highScore;
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

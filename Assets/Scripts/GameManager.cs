using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public TMP_Text timerText;
    public TMP_Text gameOverText;
    public Button restart;

    public int score = 0;
    public float timeLeft = 30f;

    private bool gameOver = false;

    void Start()
    {
        UpdateScoreText();
        UpdateTimerText();
    }

    void Update()
    {
        if (gameOver) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            gameOver = true;
            gameOverText.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
        }

        UpdateTimerText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void AddTime(float amount)
    {
        timeLeft += amount;
        UpdateTimerText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(timeLeft);
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
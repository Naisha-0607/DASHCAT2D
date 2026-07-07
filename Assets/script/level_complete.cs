using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public TMP_Text bestScoreText;

    void Start()
    {
        // Get score and time
        int score = PlayerPrefs.GetInt("CurrentScore", 0);
        float timeLeft = PlayerPrefs.GetFloat("TimeLeft", 0);

        scoreText.text = score.ToString();

        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Get the level that was completed
  // Global Best Score
int bestScore = PlayerPrefs.GetInt("BestScore", 0);

if (score > bestScore)
{
    bestScore = score;
    PlayerPrefs.SetInt("BestScore", bestScore);
    PlayerPrefs.Save();
}

bestScoreText.text = bestScore.ToString();
    }

   public void NextLevel()
{
    int current = PlayerPrefs.GetInt("CurrentLevel");
    Debug.Log("CurrentLevel from prefs: " + current);
    SceneManager.LoadScene(current + 1);
}
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
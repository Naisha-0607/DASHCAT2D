using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;

    private bool muted = false;

    private void Start()
{
    muted = PlayerPrefs.GetInt("Muted", 0) == 1;

    AudioListener.pause = muted;
}

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ToggleMute()
{
    muted = !muted;

    AudioListener.pause = muted;

    PlayerPrefs.SetInt("Muted", muted ? 1 : 0);
}
}
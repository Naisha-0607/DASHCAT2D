using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Reset Popup")]
    public GameObject resetPanel;

    void Start()
    {
        if (resetPanel != null)
            resetPanel.SetActive(false);

        if (PlayerPrefs.GetInt("HasSeenOpening", 0) == 0)
        {
            PlayerPrefs.SetInt("HasSeenOpening", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("OpeningScene");
        }
    }

    public void PlayGame()
    {
        int level = PlayerPrefs.GetInt("HighestUnlocked", 2);
        SceneManager.LoadScene(level);
    }

    public void OpenLevels()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    // ---------------- RESET ----------------

    public void OpenResetPopup()
    {
        resetPanel.SetActive(true);
    }

    public void CancelReset()
    {
        resetPanel.SetActive(false);
    }

    public void ConfirmReset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ---------------- QUIT ----------------

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
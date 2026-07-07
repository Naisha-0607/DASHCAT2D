using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouLostManager : MonoBehaviour
{
    public TMP_Text reasonText;

    void Start()
    {
        reasonText.text = PlayerPrefs.GetString("LoseReason");
    }

    public void Replay()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
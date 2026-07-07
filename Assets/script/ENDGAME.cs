using UnityEngine;
using UnityEngine.SceneManagement;

public class ENDGAME : MonoBehaviour
{
    void Start()
{
    Time.timeScale = 1f;
}
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("level_1");
    }
}
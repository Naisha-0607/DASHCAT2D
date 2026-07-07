using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void Play()
    {
        int level = PlayerPrefs.GetInt("HighestUnlocked", 2);
        SceneManager.LoadScene(level);
    }
}
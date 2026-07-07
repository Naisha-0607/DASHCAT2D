using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;

    private int currentLives;

    public Image[] hearts;

    void Start()
    {
        currentLives = maxLives;

        UpdateHearts();
    }
    public static PlayerHealth Instance;

void Awake()
{
    Instance = this;
}
public void AddLife()
{
    if (currentLives < maxLives)
    {
        currentLives++;
        UpdateHearts();
    }
}
public int GetCurrentLives()
{
    return currentLives;
}

    public void TakeDamage()
    {
        currentLives--;

        UpdateHearts();

        if(currentLives <= 0)
        {
            PlayerPrefs.SetString("LoseReason", "No Lives Left");
SceneManager.LoadScene("YouLost");
        }
    }

    void UpdateHearts()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentLives;
        }
    }
}